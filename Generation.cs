using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using static System.Net.Mime.MediaTypeNames;

namespace trps_app1
{
    public partial class Generation
    {
        private int nGraphs;
        private int nVertexes;
        private int nChanges=2;
        private int maxPath=20;
        private string name;
        private DateTime date;
        private string textTemplate;
        private Graph[] graphs;

        public Guid generationID;

        public Generation(int nGraphs, int nVertexes, string name, string textTemplate)
        {
            this.nGraphs = nGraphs;
            this.nVertexes = nVertexes;
            this.name = name;
            this.date = DateTime.Now;
            this.textTemplate = textTemplate;
            this.graphs = new Graph[nGraphs];
            this.generationID = Guid.NewGuid();

            for (int i = 0; i < nGraphs; i++)
            {
                Graph graph = new Graph(nVertexes, nChanges, maxPath);
                graphs[i] = graph;
            }

            updateXML();
            createPDF();
        }

        private void updateXML()
        {
            createFiles();

            string pathGenerations = @"data\generations.xml";
            XDocument xdocGenerations = XDocument.Load(pathGenerations);
            XElement? generations = xdocGenerations.Element("generations");
            generations.Add(new XElement("generation",
                new XAttribute("generationID", generationID),
                new XElement("name", name),
                new XElement("date", date.ToString("G")),
                new XElement("nGraphs", nGraphs),
                new XElement("nVertexes", nVertexes),
                new XElement("textTemplate", textTemplate)));
            xdocGenerations.Save(pathGenerations);

            string pathGraphs = @"data\graphs.xml";
            XDocument xdocGraphs = XDocument.Load(pathGraphs);
            XElement? graphsX = xdocGraphs.Element("graphs");
            for (int i = 0; i < nGraphs; i++)
            {
                Graph graph = graphs[i];
                string weightsStr = "";
                for (int j = 0; j < nVertexes; j++)
                {
                    for (int k = 0; k < nVertexes; k++)
                    {
                        weightsStr += graph.weightsMatrix[j, k] + ",";
                    }
                }

                string pathStr = "";
                for (int j = 0; j < graph.shortestPath.Count(); j++)
                {
                    pathStr += "x"+ graph.shortestPath[j]+"-";
                }

                graphsX.Add(new XElement("graph",
                     new XAttribute("generationID", generationID),
                     new XAttribute("graphID", i+1),
                     new XElement("weightsMatrix", weightsStr),
                     new XElement("shortestPathLength", graph.shortestPathLength),
                     new XElement("shortestPath", pathStr.Remove(pathStr.Length - 1))));
            }
            xdocGraphs.Save(pathGraphs);
        }

        private void createFiles()
        {
            string dirName = "data";
            if (!Directory.Exists(dirName))
                Directory.CreateDirectory(dirName);

            string pathGenerations = @"data\generations.xml";
            FileInfo fileGenerations = new FileInfo(pathGenerations);
            if (!fileGenerations.Exists)
            {
                XDocument xdocGenerations = new XDocument();
                XElement generations = new XElement("generations");
                xdocGenerations.Add(generations);
                xdocGenerations.Save(pathGenerations);
            }

            string pathGraphs = @"data\graphs.xml";
            FileInfo fileGraphs = new FileInfo(pathGraphs);
            if (!fileGraphs.Exists)
            {
                XDocument xdocGraphs = new XDocument();
                XElement graphs = new XElement("graphs");
                xdocGraphs.Add(graphs);
                xdocGraphs.Save(pathGraphs);
            }
        }

        private void createPDF()
        {
            string path = @"data\" + generationID.ToString() + ".pdf";

            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            FileStream stream = new FileStream(path, System.IO.FileMode.Create);
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, stream);

            doc.Open();

            PdfContentByte canvas = writer.DirectContent;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);

            iTextSharp.text.Paragraph textTemplatePDF = new iTextSharp.text.Paragraph(textTemplate, font);
            textTemplatePDF.Alignment = iTextSharp.text.Element.ALIGN_LEFT;

            float varHeight = 0;

            for (int i = 0; i < nGraphs; i ++)
            {           
                iTextSharp.text.Paragraph number = new iTextSharp.text.Paragraph("Вариант №"+(i+1).ToString(), font);
                number.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                

                canvas.SetLineDash(0f);
                PdfPTable table = new PdfPTable(nVertexes + 1);
                table.WidthPercentage = nVertexes*5;
                table.AddCell("");

                for (int j = 0; j < nVertexes; j++)
                {
                    table.AddCell("x"+ j.ToString());
                }

                for (int row = 0; row < nVertexes; row++)
                {
                    table.AddCell("x" + row.ToString());

                    for (int col = 0; col < nVertexes; col++)
                    {
                        string val = graphs[i].weightsMatrix[row, col].ToString();
                        if (val == '0'.ToString())
                        {
                            val = ' '.ToString();
                        }
                        table.AddCell(val);
                    }
                }
                table.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                table.KeepTogether = true;

                float height = writer.GetVerticalPosition(true) - 12 * 6 - 15 * nVertexes;

                if (writer.GetVerticalPosition(true) < varHeight)
                {
                    doc.NewPage();
                }

                doc.Add(number);
                //doc.Add(new iTextSharp.text.Paragraph("\n"));
                doc.Add(textTemplatePDF);
                doc.Add(new iTextSharp.text.Paragraph("\n"));
                doc.Add(table);
                doc.Add(new iTextSharp.text.Paragraph("\n"));

                canvas.SetLineDash(5f, 3f);
                canvas.SetColorStroke(BaseColor.BLACK);
                float yPosition = writer.GetVerticalPosition(true);
                canvas.MoveTo(36, yPosition);
                canvas.LineTo(PageSize.A4.Width, yPosition);
                canvas.Stroke();

                if (varHeight == 0){
                    varHeight = PageSize.A4.Height - yPosition - doc.TopMargin + doc.BottomMargin;
                }             

                //doc.Add(new iTextSharp.text.Paragraph("\n"));
            }

            doc.Close();
        }
    }
}
