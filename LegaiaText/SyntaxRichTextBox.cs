using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LegaiaText
{
    struct HighlightParams
    {
        public string RegExp;
        public Color HlColor;

        public HighlightParams(string RegExp, Color HlColor)
        {
            this.RegExp = RegExp;
            this.HlColor = HlColor;
        }
    }

    class SyntaxRichTextBox : RichTextBox
    {
        public List<HighlightParams> Highlight;

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                Rtf = string.Empty;
                base.Text = value;
                HighlightText();
            }
        }

        public void AddHighlight(HighlightParams HP)
        {
            Highlight.Add(HP);
        }

        public SyntaxRichTextBox()
        {
            Highlight = new List<HighlightParams>();
        }

        private void DelayedHighlightText(object sender, EventArgs e)
        {
            HighlightText();
        }

        private void HighlightText()
        {
            if (Highlight == null) return;

            int SelStart = SelectionStart;
            int SelLength = SelectionLength;

            foreach (HighlightParams HP in Highlight)
            {
                if (HP.RegExp != null)
                {
                    MatchCollection RegExpMatches = Regex.Matches(Text, HP.RegExp);

                    foreach (Match RegExpMatch in RegExpMatches)
                    {
                        if (RegExpMatch.Groups.Count > 1)
                        {
                            Group g = RegExpMatch.Groups[1];

                            Select(g.Index, g.Length);
                            SelectionColor = HP.HlColor;
                        }
                    }
                }
            }

            Select(SelStart, SelLength);
        }
    }
}
