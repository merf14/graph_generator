using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using trps_app1;

namespace trps_app1
{
    public partial class CreationUserControl : UserControl
    {

        public MainUserControl MainUC;
        public MainForm MainForm;

        public CreationUserControl()
        {
            InitializeComponent();
        }
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (TB_Name.Text != "")
            {
                labelMessage.Visible = false;

                int nGraphs = Decimal.ToInt32(nGraphsBox.Value);
                int nVertexes = Decimal.ToInt32(nVertexesBox.Value);
                string name = TB_Name.Text;
                string textTemplate = TB_template.Text;

                Generation newGeneration = new Generation(nGraphs, nVertexes, name, textTemplate);

                MainForm.createGenerationUC(newGeneration.generationID.ToString());

                Visible = false;
            }
            else
            {
                labelMessage.Visible = true;
            }
        }

        private void linkToMain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Visible = false;
            MainUC.Visible = true;
        }
    }
}
