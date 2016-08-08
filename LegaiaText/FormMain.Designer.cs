namespace LegaiaText
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.MenuMain = new System.Windows.Forms.MenuStrip();
            this.MenuFileRoot = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_0 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOptionsRoot = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuImport = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.Tools = new System.Windows.Forms.ToolStrip();
            this.ToolButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonSave = new System.Windows.Forms.ToolStripButton();
            this.Tool_0 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolButtonExport = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonImport = new System.Windows.Forms.ToolStripButton();
            this.Tool_1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.LabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainContainer = new System.Windows.Forms.SplitContainer();
            this.TreeFiles = new System.Windows.Forms.TreeView();
            this.TreeIcons = new System.Windows.Forms.ImageList(this.components);
            this.TextEdit = new System.Windows.Forms.TextBox();
            this.MenuMain.SuspendLayout();
            this.Tools.SuspendLayout();
            this.Status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).BeginInit();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.Panel2.SuspendLayout();
            this.MainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuMain
            // 
            this.MenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileRoot,
            this.MenuOptionsRoot,
            this.MenuHelp});
            this.MenuMain.Location = new System.Drawing.Point(0, 0);
            this.MenuMain.Name = "MenuMain";
            this.MenuMain.Size = new System.Drawing.Size(784, 24);
            this.MenuMain.TabIndex = 0;
            // 
            // MenuFileRoot
            // 
            this.MenuFileRoot.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOpen,
            this.MenuSave,
            this.Menu_0,
            this.MenuClose});
            this.MenuFileRoot.Name = "MenuFileRoot";
            this.MenuFileRoot.Size = new System.Drawing.Size(37, 20);
            this.MenuFileRoot.Text = "&File";
            // 
            // MenuOpen
            // 
            this.MenuOpen.Name = "MenuOpen";
            this.MenuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MenuOpen.Size = new System.Drawing.Size(152, 22);
            this.MenuOpen.Text = "&Open";
            this.MenuOpen.Click += new System.EventHandler(this.MenuOpen_Click);
            // 
            // MenuSave
            // 
            this.MenuSave.Name = "MenuSave";
            this.MenuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuSave.Size = new System.Drawing.Size(152, 22);
            this.MenuSave.Text = "&Save";
            this.MenuSave.Click += new System.EventHandler(this.MenuSave_Click);
            // 
            // Menu_0
            // 
            this.Menu_0.Name = "Menu_0";
            this.Menu_0.Size = new System.Drawing.Size(149, 6);
            // 
            // MenuClose
            // 
            this.MenuClose.Name = "MenuClose";
            this.MenuClose.Size = new System.Drawing.Size(152, 22);
            this.MenuClose.Text = "&Close";
            // 
            // MenuOptionsRoot
            // 
            this.MenuOptionsRoot.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuExport,
            this.MenuImport,
            this.Menu_1,
            this.MenuSearch});
            this.MenuOptionsRoot.Name = "MenuOptionsRoot";
            this.MenuOptionsRoot.Size = new System.Drawing.Size(61, 20);
            this.MenuOptionsRoot.Text = "&Options";
            // 
            // MenuExport
            // 
            this.MenuExport.Name = "MenuExport";
            this.MenuExport.Size = new System.Drawing.Size(152, 22);
            this.MenuExport.Text = "&Export";
            this.MenuExport.Click += new System.EventHandler(this.MenuExport_Click);
            // 
            // MenuImport
            // 
            this.MenuImport.Name = "MenuImport";
            this.MenuImport.Size = new System.Drawing.Size(152, 22);
            this.MenuImport.Text = "&Import";
            this.MenuImport.Click += new System.EventHandler(this.MenuImport_Click);
            // 
            // Menu_1
            // 
            this.Menu_1.Name = "Menu_1";
            this.Menu_1.Size = new System.Drawing.Size(149, 6);
            // 
            // MenuSearch
            // 
            this.MenuSearch.Name = "MenuSearch";
            this.MenuSearch.Size = new System.Drawing.Size(152, 22);
            this.MenuSearch.Text = "&Search";
            this.MenuSearch.Click += new System.EventHandler(this.MenuSearch_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAbout});
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(44, 20);
            this.MenuHelp.Text = "&Help";
            // 
            // MenuAbout
            // 
            this.MenuAbout.Name = "MenuAbout";
            this.MenuAbout.Size = new System.Drawing.Size(152, 22);
            this.MenuAbout.Text = "&About";
            this.MenuAbout.Click += new System.EventHandler(this.MenuAbout_Click);
            // 
            // Tools
            // 
            this.Tools.AutoSize = false;
            this.Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolButtonOpen,
            this.ToolButtonSave,
            this.Tool_0,
            this.ToolButtonExport,
            this.ToolButtonImport,
            this.Tool_1,
            this.ToolButtonSearch});
            this.Tools.Location = new System.Drawing.Point(0, 24);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(784, 52);
            this.Tools.TabIndex = 1;
            this.Tools.Text = "toolStrip1";
            // 
            // ToolButtonOpen
            // 
            this.ToolButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonOpen.Image")));
            this.ToolButtonOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonOpen.Name = "ToolButtonOpen";
            this.ToolButtonOpen.Size = new System.Drawing.Size(52, 49);
            this.ToolButtonOpen.Click += new System.EventHandler(this.ToolButtonOpen_Click);
            // 
            // ToolButtonSave
            // 
            this.ToolButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonSave.Image")));
            this.ToolButtonSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonSave.Name = "ToolButtonSave";
            this.ToolButtonSave.Size = new System.Drawing.Size(52, 49);
            this.ToolButtonSave.Click += new System.EventHandler(this.ToolButtonSave_Click);
            // 
            // Tool_0
            // 
            this.Tool_0.Name = "Tool_0";
            this.Tool_0.Size = new System.Drawing.Size(6, 52);
            // 
            // ToolButtonExport
            // 
            this.ToolButtonExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonExport.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonExport.Image")));
            this.ToolButtonExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonExport.Name = "ToolButtonExport";
            this.ToolButtonExport.Size = new System.Drawing.Size(52, 49);
            this.ToolButtonExport.Click += new System.EventHandler(this.ToolButtonExport_Click);
            // 
            // ToolButtonImport
            // 
            this.ToolButtonImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonImport.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonImport.Image")));
            this.ToolButtonImport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonImport.Name = "ToolButtonImport";
            this.ToolButtonImport.Size = new System.Drawing.Size(52, 49);
            this.ToolButtonImport.Click += new System.EventHandler(this.ToolButtonImport_Click);
            // 
            // Tool_1
            // 
            this.Tool_1.Name = "Tool_1";
            this.Tool_1.Size = new System.Drawing.Size(6, 52);
            // 
            // ToolButtonSearch
            // 
            this.ToolButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonSearch.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonSearch.Image")));
            this.ToolButtonSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonSearch.Name = "ToolButtonSearch";
            this.ToolButtonSearch.Size = new System.Drawing.Size(52, 49);
            this.ToolButtonSearch.Click += new System.EventHandler(this.ToolButtonSearch_Click);
            // 
            // Status
            // 
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelStatus});
            this.Status.Location = new System.Drawing.Point(0, 539);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(784, 22);
            this.Status.TabIndex = 2;
            this.Status.Text = "statusStrip1";
            // 
            // LabelStatus
            // 
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(39, 17);
            this.LabelStatus.Text = "Ready";
            // 
            // MainContainer
            // 
            this.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainer.Location = new System.Drawing.Point(0, 76);
            this.MainContainer.Name = "MainContainer";
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.TreeFiles);
            // 
            // MainContainer.Panel2
            // 
            this.MainContainer.Panel2.Controls.Add(this.TextEdit);
            this.MainContainer.Size = new System.Drawing.Size(784, 463);
            this.MainContainer.SplitterDistance = 261;
            this.MainContainer.TabIndex = 3;
            // 
            // TreeFiles
            // 
            this.TreeFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TreeFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeFiles.FullRowSelect = true;
            this.TreeFiles.ImageIndex = 0;
            this.TreeFiles.ImageList = this.TreeIcons;
            this.TreeFiles.Location = new System.Drawing.Point(0, 0);
            this.TreeFiles.Name = "TreeFiles";
            this.TreeFiles.SelectedImageIndex = 0;
            this.TreeFiles.Size = new System.Drawing.Size(261, 463);
            this.TreeFiles.TabIndex = 4;
            this.TreeFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeFiles_AfterSelect);
            // 
            // TreeIcons
            // 
            this.TreeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeIcons.ImageStream")));
            this.TreeIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeIcons.Images.SetKeyName(0, "icon_unknown.png");
            this.TreeIcons.Images.SetKeyName(1, "icon_package.png");
            this.TreeIcons.Images.SetKeyName(2, "icon_text.png");
            // 
            // TextEdit
            // 
            this.TextEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextEdit.Location = new System.Drawing.Point(0, 0);
            this.TextEdit.Multiline = true;
            this.TextEdit.Name = "TextEdit";
            this.TextEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextEdit.Size = new System.Drawing.Size(519, 463);
            this.TextEdit.TabIndex = 0;
            this.TextEdit.TextChanged += new System.EventHandler(this.TextEdit_TextChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.MainContainer);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Tools);
            this.Controls.Add(this.MenuMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.MenuMain;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LegaiaText";
            this.MenuMain.ResumeLayout(false);
            this.MenuMain.PerformLayout();
            this.Tools.ResumeLayout(false);
            this.Tools.PerformLayout();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel2.ResumeLayout(false);
            this.MainContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).EndInit();
            this.MainContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuMain;
        private System.Windows.Forms.ToolStripMenuItem MenuFileRoot;
        private System.Windows.Forms.ToolStripMenuItem MenuOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuSave;
        private System.Windows.Forms.ToolStripSeparator Menu_0;
        private System.Windows.Forms.ToolStripMenuItem MenuClose;
        private System.Windows.Forms.ToolStrip Tools;
        private System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.SplitContainer MainContainer;
        private System.Windows.Forms.TreeView TreeFiles;
        private System.Windows.Forms.ImageList TreeIcons;
        private System.Windows.Forms.ToolStripMenuItem MenuOptionsRoot;
        private System.Windows.Forms.ToolStripMenuItem MenuExport;
        private System.Windows.Forms.ToolStripMenuItem MenuImport;
        private System.Windows.Forms.ToolStripSeparator Menu_1;
        private System.Windows.Forms.ToolStripMenuItem MenuSearch;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuAbout;
        private System.Windows.Forms.ToolStripButton ToolButtonOpen;
        private System.Windows.Forms.ToolStripButton ToolButtonSave;
        private System.Windows.Forms.ToolStripSeparator Tool_0;
        private System.Windows.Forms.ToolStripButton ToolButtonExport;
        private System.Windows.Forms.ToolStripButton ToolButtonImport;
        private System.Windows.Forms.ToolStripSeparator Tool_1;
        private System.Windows.Forms.ToolStripButton ToolButtonSearch;
        private System.Windows.Forms.ToolStripStatusLabel LabelStatus;
        private System.Windows.Forms.TextBox TextEdit;
    }
}

