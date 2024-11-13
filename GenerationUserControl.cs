using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
            Label labelLength = new Label();
            Label labelPath = new Label();
            DataGridView matrix = new DataGridView();
            Label labelNumber = new Label();
            Label labelGeneration = new Label();

            panelGraph.BackColor = SystemColors.ControlLightLight;
            panelGraph.Name = "panelGraph" + graphID;
            panelGraph.Size = new Size(860, height + 60);
            panelGraph.TabIndex = 10;
            panelGraph.Visible = true;

            labelLength.AutoSize = true;
            labelLength.Location = new Point(width + 20, 108);
            labelLength.Name = "labelLength" + graphID;
            //labelLength.Size = new Size(233, 25);
            labelLength.TabIndex = 12;
            labelLength.Text = "Длина кратчайшего пути: " + shortestPathLength;

            labelPath.AutoSize = true;
            labelPath.Location = new Point(width + 20, 37);
            labelPath.Name = "labelPath" + graphID;
            //labelPath.Size = new Size(168, 25);
            labelPath.TabIndex = 11;
            labelPath.Text = "Кратчайший путь: " + Environment.NewLine + shortestPath;

            labelNumber.AutoSize = true;
            labelNumber.Location = new Point(3, 0);
            labelNumber.Name = "labelNumber" + graphID;
            labelNumber.Size = new Size(120, 25);
            labelNumber.TabIndex = 9;
            labelNumber.Text = "Вариант №" + graphID;

            matrix.BackgroundColor = Color.White;
            matrix.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            matrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            matrix.GridColor = SystemColors.ControlDarkDark;
            matrix.Location = new Point(14, 37);
            matrix.Name = "matrix" + graphID;
            matrix.RowTemplate.Height = 25;
            matrix.Size = new Size(width, height);
            matrix.TabIndex = 10;
            matrix.RowHeadersWidth = 60;
            matrix.Font = new Font("Segoe UI Semibold", 11);
            matrix.ReadOnly = true;
            matrix.AllowUserToResizeRows = false;
            matrix.AllowUserToResizeColumns = false;
            matrix.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            matrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

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
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(path)
            {
                UseShellExecute = true
            };
            p.Start();
        }
    }
}
