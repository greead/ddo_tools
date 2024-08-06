namespace ThievesTools {
    partial class InGameUI {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btnOpenWiki = new Button();
            lstDebugOut = new ListBox();
            btnRunDebug = new Button();
            SuspendLayout();
            // 
            // btnOpenWiki
            // 
            btnOpenWiki.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnOpenWiki.Location = new Point(12, 12);
            btnOpenWiki.Name = "btnOpenWiki";
            btnOpenWiki.Size = new Size(376, 23);
            btnOpenWiki.TabIndex = 1;
            btnOpenWiki.Text = "Open the Wiki for the Current Active Quest";
            btnOpenWiki.UseVisualStyleBackColor = true;
            btnOpenWiki.Click += btnOpenWiki_Click;
            // 
            // lstDebugOut
            // 
            lstDebugOut.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstDebugOut.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstDebugOut.FormattingEnabled = true;
            lstDebugOut.HorizontalScrollbar = true;
            lstDebugOut.Location = new Point(12, 156);
            lstDebugOut.Name = "lstDebugOut";
            lstDebugOut.ScrollAlwaysVisible = true;
            lstDebugOut.Size = new Size(376, 116);
            lstDebugOut.TabIndex = 2;
            // 
            // btnRunDebug
            // 
            btnRunDebug.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnRunDebug.Location = new Point(12, 127);
            btnRunDebug.Name = "btnRunDebug";
            btnRunDebug.Size = new Size(376, 23);
            btnRunDebug.TabIndex = 3;
            btnRunDebug.Text = "Run Debug";
            btnRunDebug.UseVisualStyleBackColor = true;
            btnRunDebug.Click += btnRunDebug_Click;
            // 
            // InGameUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 287);
            ControlBox = false;
            Controls.Add(btnRunDebug);
            Controls.Add(lstDebugOut);
            Controls.Add(btnOpenWiki);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(400, 200);
            Name = "InGameUI";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "InGameUI";
            ResumeLayout(false);
        }

        #endregion
        private Button btnOpenWiki;
        private ListBox lstDebugOut;
        private Button btnRunDebug;
    }
}