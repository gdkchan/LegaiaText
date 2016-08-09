using LegaiaText.Legaia;

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LegaiaText
{
    public partial class FormMain : Form
    {
        const string Version = "0.2";

        LProt Prot;

        string CurrFile;
        TreeNode CurrNode;
        bool HasNewText;

        public FormMain()
        {
            InitializeComponent();

            Text = "LegaiaText v" + Version;

            TextEdit.ForeColor = Color.Silver;

            TextEdit.AddHighlight(new HighlightParams("\\{TEXT\\}(.+?)\\{END\\}", Color.Black));
            TextEdit.AddHighlight(new HighlightParams("(\\\\x[0-9A-Fa-f]{2})", Color.Gray));

            //Needs to do this cause this shit is screwed
            TextEdit.AutoWordSelection = false;
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            UserOpen();
        }

        private void MenuSave_Click(object sender, EventArgs e)
        {
            UserSave();
        }

        private void MenuExport_Click(object sender, EventArgs e)
        {
            UserExport();
        }

        private void MenuImport_Click(object sender, EventArgs e)
        {
            UserImport();
        }

        private void MenuSearch_Click(object sender, EventArgs e)
        {
            UserSearch();
        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Legend of Legaia Text editor by gdkchan" + Environment.NewLine + "Icons from the Tango project",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ToolButtonOpen_Click(object sender, EventArgs e)
        {
            UserOpen();
        }

        private void ToolButtonSave_Click(object sender, EventArgs e)
        {
            UserSave();
        }

        private void ToolButtonExport_Click(object sender, EventArgs e)
        {
            UserExport();
        }

        private void ToolButtonImport_Click(object sender, EventArgs e)
        {
            UserImport();
        }

        private void ToolButtonSearch_Click(object sender, EventArgs e)
        {
            UserSearch();
        }

        private void UserOpen()
        {
            using (OpenFileDialog OpenDlg = new OpenFileDialog())
            {
                OpenDlg.Filter = "Data|*.dat";
                OpenDlg.FileName = "PROT.DAT";

                if (OpenDlg.ShowDialog() == DialogResult.OK)
                {
                    ShowStatus("Loading data, please wait...");

                    Open(OpenDlg.FileName);
                    CurrFile = OpenDlg.FileName;

                    ShowStatus("Loaded");
                }
            }
        }

        private void UserSave()
        {
            if (CurrFile != null)
            {
                if (CurrNode != null && HasNewText)
                {
                    SetData(CurrNode, Utils.Text2Data(TextEdit.Text));
                    HasNewText = false;
                }

                LProt.ToFile(Prot, CurrFile);

                ShowStatus("Saved at " + DateTime.Now.ToShortTimeString());
            }
        }

        private void UserExport()
        {
            if (TreeFiles.SelectedNode != null)
            {
                byte[] Data = GetData(TreeFiles.SelectedNode);

                using (SaveFileDialog SaveDlg = new SaveFileDialog())
                {
                    SaveDlg.Filter = "Binary|*.bin";

                    string BaseName = string.Empty;

                    switch (TreeFiles.SelectedNode.Level)
                    {
                        case 0: BaseName = "file"; break;
                        case 1: BaseName = "data"; break;
                        case 2: BaseName = "script"; break;
                    }

                    SaveDlg.FileName = string.Format("{0}_{1:D5}", BaseName, TreeFiles.SelectedNode.Index);

                    if (SaveDlg.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(SaveDlg.FileName, Data);
                    }
                }
            }
        }

        private void UserImport()
        {
            if (TreeFiles.SelectedNode != null)
            {
                using (OpenFileDialog OpenDlg = new OpenFileDialog())
                {
                    OpenDlg.Filter = "Binary|*.bin";

                    string BaseName = string.Empty;

                    switch (TreeFiles.SelectedNode.Level)
                    {
                        case 0: BaseName = "file"; break;
                        case 1: BaseName = "data"; break;
                        case 2: BaseName = "script"; break;
                    }

                    OpenDlg.FileName = string.Format("{0}_{1:D5}", BaseName, TreeFiles.SelectedNode.Index);

                    if (OpenDlg.ShowDialog() == DialogResult.OK)
                    {
                        byte[] Data = File.ReadAllBytes(OpenDlg.FileName);

                        SetData(TreeFiles.SelectedNode, Data);
                    }
                }
            }
        }

        private void UserSearch()
        {
            SearchDialog Dlg = new SearchDialog();

            Dlg.OnTextEntered += SearchCallback;

            Dlg.ShowDialog();
        }

        private void SearchCallback(object sender, SearchEventArgs e)
        {
            string Results = string.Empty;

            int Matches = 0;

            ShowStatus("Searching, please wait...");

            for (int i = 0; i < Prot.Files.Length; i++)
            {
                LPack Pack = LPack.FromData(Prot.Files[i]);

                //Add Pack nodes if file is Pack
                if (Pack != null)
                {
                    for (int j = 0; j < Pack.Files.Length; j++)
                    {
                        LScript Script = LScript.FromData(Pack.Files[j].Data);

                        //Add Script nodes if file is Script
                        if (Script != null)
                        {
                            for (int k = 0; k < Script.Scripts.Length; k++)
                            {
                                string Text = Utils.Data2Text(Script.Scripts[k]);

                                if (Text.Contains(e.Text))
                                {
                                    Results += Environment.NewLine + string.Format("...at {0:D5}/{1:D5}/{2:D5}", i, j, k);

                                    if (++Matches == 10)
                                    {
                                        Results += Environment.NewLine + "...output truncated";

                                        i = Prot.Files.Length;
                                        j = Pack.Files.Length;

                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            ShowStatus("Ready");

            if (Results != string.Empty)
            {
                MessageBox.Show(
                    "Text found..." + Environment.NewLine + Results,
                    "Search",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "Sorry, the text you're looking for was not found...",
                    "Search",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void Open(string FileName)
        {
            Prot = LProt.FromFile(FileName);

            TreeNode[] ProtNodes = new TreeNode[Prot.Files.Length];

            for (int i = 0; i < Prot.Files.Length; i++)
            {
                LPack Pack = LPack.FromData(Prot.Files[i]);

                ProtNodes[i] = MakeNode(
                    "File",
                    i,
                    Pack != null ? 1 : 0,
                    Prot.Files[i].Length);

                //Add Pack nodes if file is Pack
                if (Pack != null)
                {
                    TreeNode[] PackNodes = new TreeNode[Pack.Files.Length];

                    for (int j = 0; j < Pack.Files.Length; j++)
                    {
                        LScript Script = LScript.FromData(Pack.Files[j].Data);

                        PackNodes[j] = MakeNode(
                            "Data",
                            j, 
                            Script != null ? 1 : 0, 
                            Pack.Files[j].Data.Length);

                        //Add Script nodes if file is Script
                        if (Script != null)
                        {
                            for (int k = 0; k < Script.Scripts.Length; k++)
                            {
                                PackNodes[j].Nodes.Add(MakeNode("Script", k, 2, Script.Scripts[k].Length));
                            }
                        }
                    }

                    ProtNodes[i].Nodes.AddRange(PackNodes);
                }
            }

            TreeFiles.Nodes.Clear();
            TreeFiles.Nodes.AddRange(ProtNodes);

            CurrNode = null;
            HasNewText = false;
            TextEdit.Text = string.Empty;
        }

        private TreeNode MakeNode(string Name, int Index, int IconIdx, int Length)
        {
            Name = string.Format("{0} {1:D5} ({2})", Name, Index, Utils.SizeString(Length));

            return new TreeNode(Name, IconIdx, IconIdx);
        }

        private void TreeFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 2)
            {
                if (CurrNode != null && HasNewText)
                {
                    SetData(CurrNode, Utils.Text2Data(TextEdit.Text));
                }

                TextEdit.Text = Utils.Data2Text(GetData(e.Node));

                CurrNode = e.Node;
                HasNewText = false;
            }
        }

        private byte[] GetData(TreeNode Node)
        {
            byte[] File = Prot.Files[GetDepthIndex(Node, 0)];

            if (Node.Level > 0)
            {
                LPack Pack = LPack.FromData(File);

                if (Node.Level > 1)
                {
                    byte[] Data = Pack.Files[GetDepthIndex(Node, 1)].Data;
                    LScript Script = LScript.FromData(Data);

                    return Script.Scripts[Node.Index];
                }

                return Pack.Files[Node.Index].Data;
            }

            return File;
        }

        private void SetData(TreeNode Node, byte[] New)
        {
            ShowStatus("Inserting new data, please wait...");

            byte[] File = Prot.Files[GetDepthIndex(Node, 0)];

            if (Node.Level > 0)
            {
                LPack Pack = LPack.FromData(File);

                if (Node.Level > 1)
                {
                    byte[] Data = Pack.Files[GetDepthIndex(Node, 1)].Data;
                    LScript Script = LScript.FromData(Data);

                    Script.Scripts[Node.Index] = New;

                    New = LScript.ToData(Script);
                    Node = Node.Parent;
                }

                Pack.Files[Node.Index].Data = New;

                New = LPack.ToData(Pack);
                Node = Node.Parent;
            }

            Prot.Files[Node.Index] = New;

            ShowStatus("Ready");
        }

        private int GetDepthIndex(TreeNode Node, int Depth)
        {
            while (Node.Level > Depth) Node = Node.Parent;

            return Node.Index;
        }

        private void TextEdit_TextChanged(object sender, EventArgs e)
        {
            HasNewText = true;
        }

        private void TextEdit_SelectionChanged(object sender, EventArgs e)
        {
            LabelSel.Text = string.Format("SEL: {0,4}", TextEdit.SelectionLength);
        }

        private void ShowStatus(string Status)
        {
            LabelStatus.Text = Status;

            Refresh();
            Application.DoEvents();
        }
    }
}
