using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trps_app1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mainUserControl1.showGenerations();
            mainUserControl1.Visible = true;
            mainUserControl1.CreationUC = creationUserControl1;
            mainUserControl1.MainForm = this;

            creationUserControl1.MainUC = mainUserControl1;
            creationUserControl1.MainForm = this;
        }

        public void createGenerationUC(string generationID)
        {
            GenerationUserControl generationUserControl = new GenerationUserControl(generationID, mainUserControl1);

            generationUserControl.Dock = DockStyle.Fill;
            generationUserControl.Location = new Point(0, 0);
            generationUserControl.Name = "generationUserControl1";
            generationUserControl.Size = new Size(860, 630);
            generationUserControl.TabIndex = 2;
            generationUserControl.Visible = true;

            Controls.Add(generationUserControl);
        }
    }
}
