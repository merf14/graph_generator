using iTextSharp.xmp.impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using trps_app1.Properties;
using static System.Net.Mime.MediaTypeNames;

namespace trps_app1
{
    public partial class MainUserControl : UserControl
    {
        public CreationUserControl CreationUC;
        public MainForm MainForm;
        public MainUserControl()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Visible = false;
            CreationUC.Visible = true;
        }

        public void showGenerations()
        {
            panelGenerations.Controls.Clear();

            string pathGenerations = @"data\generations.xml";
            FileInfo fileGenerations = new FileInfo(pathGenerations);
            if (fileGenerations.Exists)
            {
                XDocument xdoc = XDocument.Load(pathGenerations);
                XElement? root = xdoc.Element("generations");
                if (root is not null)
                {
                    foreach (XElement generationXML in root.Elements("generation"))
                    {

                        XAttribute? generationID = generationXML.Attribute("generationID");
                        XElement? name = generationXML.Element("name");
                        XElement? date = generationXML.Element("date");

                        createGenPanel(generationID.Value, name.Value, date.Value);
                    }
                }
            }
        }

        private void createGenPanel(string generationID, string name, string date)
        {
            Panel panel = new Panel();
            panel.Name = generationID;
            panel.Visible = true;
            panel.Width = 284;
            panel.Height = 220;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);
            panel.Click += new EventHandler(panelClick);
            panel.Cursor = Cursors.Hand;
            panel.MouseEnter += new EventHandler(panelMouseMove);
            panel.MouseLeave += new EventHandler(panelMouseLeave);

            Panel innerPanel = new Panel();
            innerPanel.Name = "innerPanel" + generationID;
            innerPanel.Visible = true;
            innerPanel.Width = 284;
            innerPanel.Height = 55;
            innerPanel.BorderStyle = BorderStyle.FixedSingle;
            innerPanel.BackColor = Color.FromArgb(10, 60, 0);
            innerPanel.Cursor = Cursors.Hand;
            innerPanel.Click += new EventHandler(iPanelClick);
            innerPanel.MouseEnter += new EventHandler(iPanelMouseMove);
            innerPanel.MouseLeave += new EventHandler(iPanelMouseLeave);

            panel.Controls.Add(innerPanel);

            Label label = new Label();
            label.Name = "label" + generationID;
            label.Visible = true;
            label.AutoSize = true;
            label.Text = name + Environment.NewLine + "от " + date;
            label.Font = new Font("Segoe UI Semibold", 14, FontStyle.Bold);
            label.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            label.Location = new Point(16, 63);
            label.Cursor = Cursors.Hand;
            label.Click += new EventHandler(labelClick);
            label.MouseEnter += new EventHandler(labelMouseMove);
            label.MouseLeave += new EventHandler(labelMouseLeave);

            Button delete = new Button();
            delete.FlatStyle = FlatStyle.Flat;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUserControl));
            delete.Image = (System.Drawing.Image)resources.GetObject("trash_can");
            delete.Name = "delete" + generationID;
            delete.Visible = true;
            delete.Size = new Size(44, 40);
            delete.Text = "";
            delete.Font = new Font("Segoe UI Semibold", 11);
            delete.ForeColor = Color.FromKnownColor(KnownColor.ControlLightLight);
            delete.Location = new Point(237, 177);
            delete.Cursor = Cursors.Hand;
            delete.Click += new EventHandler(deleteClick);
            delete.MouseEnter += new EventHandler(deleteMouseMove);
            delete.MouseLeave += new EventHandler(deletelMouseLeave);
            delete.UseVisualStyleBackColor = true;
            delete.FlatAppearance.MouseDownBackColor = Color.FromArgb(240, 255, 240);
            delete.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 255, 240);
            delete.FlatAppearance.BorderSize = 0;
            delete.TabIndex = 2;

            panel.Controls.Add(label);
            panel.Controls.Add(delete);

            panelGenerations.Controls.Add(panel);
            panel.BringToFront();
        }

        private void deleteClick(object sender, EventArgs e)
        {
            Button delete = sender as Button;
            string name = delete.Name;
            string id = name.Substring(6, name.Length - 6);
            Control panel = panelGenerations.Controls[id];
            Control label = panel.Controls["label"+id];
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите удалить генерацию "+ label.Text+"?",
                "Удаление",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                Generation generation = new Generation();
                generation.delete(id);
                showGenerations();
            }
        }
        private void deleteMouseMove(object sender, EventArgs e)
        {
            Button delete = sender as Button;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUserControl));
            delete.Image = (System.Drawing.Image)resources.GetObject("trash_can_red");
            string name = delete.Name;
            name = name.Substring(6, name.Length - 6);
            Control panel = panelGenerations.Controls[name];
            panel.BackColor = Color.FromArgb(240, 255, 240);
        }

        private void deletelMouseLeave(object sender, EventArgs e)
        {
            Button delete = sender as Button;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUserControl));
            delete.Image = (System.Drawing.Image)resources.GetObject("trash_can");
            string name = delete.Name;
            name = name.Substring(6, name.Length - 6);
            Control panel = panelGenerations.Controls[name];
            if (panel != null)
            {
                panel.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);
            }
        }
        private void panelClick(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            Visible = false;
            MainForm.createGenerationUC(panel.Name);
        }

        private void panelMouseMove(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.BackColor = Color.FromArgb(240, 255, 240);
        }

        private void panelMouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);
        }

        private void iPanelClick(object sender, EventArgs e)
        {
            Panel iPanel = sender as Panel;
            string name = iPanel.Name;
            name = name.Substring(10, name.Length - 10);
            Visible = false;
            MainForm.createGenerationUC(name);
        }

        private void iPanelMouseMove(object sender, EventArgs e)
        {
            Panel iPanel = sender as Panel;
            string name = iPanel.Name;
            name = name.Substring(10, name.Length - 10);
            Control panel = panelGenerations.Controls[name];
            panel.BackColor = Color.FromArgb(240, 255, 240);
        }

        private void iPanelMouseLeave(object sender, EventArgs e)
        {
            Panel iPanel = sender as Panel;
            string name = iPanel.Name;
            name = name.Substring(10, name.Length - 10);
            Control panel = panelGenerations.Controls[name];
            panel.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);
        }

        private void labelClick(object sender, EventArgs e)
        {
            Label label = sender as Label;
            string name = label.Name;
            name = name.Substring(5, name.Length - 5);
            Visible = false;
            MainForm.createGenerationUC(name);
        }

        private void labelMouseMove(object sender, EventArgs e)
        {
            Label label = sender as Label;
            string name = label.Name;
            name = name.Substring(5, name.Length - 5);
            Control panel = panelGenerations.Controls[name];
            panel.BackColor = Color.FromArgb(240, 255, 240);
        }

        private void labelMouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            string name = label.Name;
            name = name.Substring(5, name.Length - 5);
            Control panel = panelGenerations.Controls[name];
            panel.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);
        }


    }
}
