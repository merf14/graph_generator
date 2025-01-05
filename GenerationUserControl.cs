using iTextSharp.xmp.impl;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace trps_app1
{
    public partial class GenerationUserControl : UserControl
    {
        public MainUserControl MainUC;
        public string generationID;
        public GenerationUserControl(string generationID, MainUserControl MainUC)
        {
            InitializeComponent();
            this.MainUC = MainUC;
            this.generationID = generationID;
            showInfo();
        }

        public void showInfo()
        {

            string pathGenerations = @"data\generations.xml";
            FileInfo fileGenerations = new FileInfo(pathGenerations);
            if (fileGenerations.Exists)
            {
                XDocument xdocGeneration = XDocument.Load(pathGenerations);

                var generationXML = xdocGeneration.Element("generations")?
                    .Elements("generation")
                    .FirstOrDefault(p => p.Attribute("generationID")?.Value == generationID);

                XElement? name = generationXML.Element("name");
                XElement? date = generationXML.Element("date");
                XElement? nGraphs = generationXML.Element("nGraphs");
                XElement? nVertexes = generationXML.Element("nVertexes");
                XElement? textTemplate = generationXML.Element("textTemplate");

                labelName.Text = name.Value + " от " + date.Value;
                labelNGraphs.Text += nGraphs.Value;
                labelNVertexes.Text += nVertexes.Value;
                TB_template.Text = textTemplate.Value;


                string pathGraphs = @"data\graphs.xml";
                FileInfo fileGraphs = new FileInfo(pathGraphs);
                if (fileGraphs.Exists)
                {
                    XDocument xdocGraphs = XDocument.Load(pathGraphs);

                    var graphXML = xdocGraphs.Element("graphs");
                    var graphs = graphXML.Elements("graph")
                                    .Where(p => p.Attribute("generationID")?.Value == generationID)
                                    .Select(p => new
                                    {
                                        graphID = p.Attribute("graphID")?.Value,
                                        weightsMatrix = p.Element("weightsMatrix")?.Value,
                                        shortestPathLength = p.Element("shortestPathLength")?.Value,
                                        shortestPath = p.Element("shortestPath")?.Value
                                    });

                    foreach (var graph in graphs)
                    {
                        createGraphPanel(Int32.Parse(nVertexes.Value), graph.graphID, graph.weightsMatrix, graph.shortestPathLength, graph.shortestPath);
                    }
                }
            }

        }

        private void createGraphPanel(int nVertexes, string graphID, string weightsMatrix, string shortestPathLength, string shortestPath)
        {
            int width = (nVertexes) * 36 + 62;
            int height = (nVertexes + 1) * 25;

            Panel panelGraph = new Panel();
            System.Windows.Forms.Label labelLength = new System.Windows.Forms.Label();
            System.Windows.Forms.Label labelPath = new System.Windows.Forms.Label();
            DataGridView matrix = new DataGridView();
            System.Windows.Forms.Label labelNumber = new System.Windows.Forms.Label();
            System.Windows.Forms.Label labelGeneration = new System.Windows.Forms.Label();

            panelGraph.BackColor = SystemColors.ControlLightLight;
            panelGraph.Name = "panelGraph" + graphID;
            panelGraph.Size = new Size(860, height + 60);
            panelGraph.Visible = true;

            labelLength.AutoSize = true;
            labelLength.Location = new Point(width + 20, 108);
            labelLength.Name = "labelLength" + graphID;
            //labelLength.Size = new Size(233, 25);
            labelLength.Text = "Длина кратчайшего пути: " + shortestPathLength;

            labelPath.AutoSize = true;
            labelPath.Location = new Point(width + 20, 37);
            labelPath.Name = "labelPath" + graphID;
            //labelPath.Size = new Size(168, 25);
            labelPath.Text = "Кратчайший путь: " + Environment.NewLine + shortestPath;

            labelNumber.AutoSize = true;
            labelNumber.Location = new Point(3, 0);
            labelNumber.Name = "labelNumber" + graphID;
            labelNumber.Size = new Size(120, 25);
            labelNumber.Text = "Вариант №" + graphID;

            matrix.BackgroundColor = Color.White;
            matrix.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            matrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            matrix.GridColor = SystemColors.ControlDarkDark;
            matrix.Location = new Point(14, 37);
            matrix.Name = "matrix" + graphID;
            matrix.RowTemplate.Height = 25;
            matrix.Size = new Size(width, height);
            matrix.RowHeadersWidth = 60;
            matrix.Font = new Font("Segoe UI Semibold", 11);
            matrix.ReadOnly = true;
            matrix.Enabled = false; ;
            matrix.AllowUserToResizeRows = false;
            matrix.AllowUserToResizeColumns = false;
            matrix.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            matrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            matrix.RowsDefaultCellStyle.SelectionBackColor = SystemColors.ControlLightLight;

            for (int i = 0; i < nVertexes; i++)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column.HeaderText = "x" + i.ToString();
                column.MinimumWidth = 36;
                column.Name = "x" + i.ToString();
                column.ReadOnly = true;
                column.Resizable = DataGridViewTriState.False;
                column.Width = 36;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                matrix.Columns.Add(column);
            }

            matrix.AllowUserToAddRows = false;

            string[] arr = weightsMatrix.Split(new char[] { ',' });

            for (int i = 0; i < nVertexes; ++i)
            {
                string[] row_arr = arr.Skip(nVertexes * i).Take(nVertexes).ToArray();
                for (int j = 0; j < row_arr.Length; ++j)
                {
                    if (row_arr[j] == '0'.ToString())
                    {
                        row_arr[j] = ' '.ToString();
                    }
                }
                matrix.Rows.Add(row_arr);
                matrix.Rows[i].HeaderCell.Value = "x" + i.ToString();
            }

            panelGraph.Controls.Add(labelLength);
            panelGraph.Controls.Add(labelPath);
            panelGraph.Controls.Add(matrix);
            panelGraph.Controls.Add(labelNumber);
            panelGraphs.Controls.Add(panelGraph);
        }

        private void linkToMain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Visible = false;
            MainUC.showGenerations();
            MainUC.Visible = true;
        }

        private void buttonPDF_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "data", generationID.ToString() + ".pdf");
            if (!File.Exists(path))
            {
                DialogResult result = MessageBox.Show(
                "Файл не найден.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                var p = new Process();
                p.StartInfo = new ProcessStartInfo(path)
                {
                    UseShellExecute = true
                };
                p.Start();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите удалить генерацию " + labelName.Text + "?",
                "Удаление",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                Generation generation = new Generation();
                generation.delete(generationID);
                Visible = false;
                MainUC.showGenerations();
                MainUC.Visible = true;
            }
        }

        private void labelHide_Click(object sender, EventArgs e)
        {
            labelHide.Visible = false;
            groupParametrs.Height = 22;
            labelParametrs.Font = new Font("Segoe UI", 12F, FontStyle.Underline, GraphicsUnit.Point);
            labelParametrs.Cursor = Cursors.Hand;
            groupGraphs.Location = new Point(60, 144);
            groupGraphs.Size = new Size(894, 515);
        }

        private void labelParametrs_Click(object sender, EventArgs e)
        {
            groupParametrs.Height = 267;
            labelParametrs.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelHide.Visible = true;
            labelParametrs.Cursor = Cursors.Default;
            groupGraphs.Location = new Point(60, 389);
            groupGraphs.Size = new Size(894, 270);
        }
    }
}
