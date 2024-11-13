namespace trps_app1
{
    partial class MainForm
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
            creationUserControl1 = new CreationUserControl();
            mainUserControl1 = new MainUserControl();
            SuspendLayout();
            // 
            // creationUserControl1
            // 
            creationUserControl1.Dock = DockStyle.Fill;
            creationUserControl1.Location = new Point(0, 0);
            creationUserControl1.Name = "creationUserControl1";
            creationUserControl1.Size = new Size(1014, 920);
            creationUserControl1.TabIndex = 0;
            creationUserControl1.Visible = false;
            // 
            // mainUserControl1
            // 
            mainUserControl1.Dock = DockStyle.Fill;
            mainUserControl1.Location = new Point(0, 0);
            mainUserControl1.Name = "mainUserControl1";
            mainUserControl1.Size = new Size(1014, 920);
            mainUserControl1.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1014, 920);
            Controls.Add(mainUserControl1);
            Controls.Add(creationUserControl1);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private CreationUserControl creationUserControl1;
        private MainUserControl mainUserControl1;
    }
}