﻿namespace trps_app1
{
    partial class GenerationUserControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerationUserControl));
            linkToMain = new LinkLabel();
            labelName = new Label();
            groupParametrs = new GroupBox();
            labelHide = new Label();
            TB_template = new TextBox();
            labelTemplate = new Label();
            labelNGraphs = new Label();
            labelParametrs = new Label();
            labelNVertexes = new Label();
            groupGraphs = new GroupBox();
            labelGeneration = new Label();
            panelGraphs = new FlowLayoutPanel();
            buttonPDF = new Button();
            buttonDelete = new Button();
            groupParametrs.SuspendLayout();
            groupGraphs.SuspendLayout();
            SuspendLayout();
            // 
            // linkToMain
            // 
            linkToMain.ActiveLinkColor = Color.FromArgb(10, 120, 0);
            linkToMain.AutoSize = true;
            linkToMain.LinkColor = Color.FromArgb(10, 60, 0);
            linkToMain.Location = new Point(52, 33);
            linkToMain.Name = "linkToMain";
            linkToMain.Size = new Size(142, 15);
            linkToMain.TabIndex = 1;
            linkToMain.TabStop = true;
            linkToMain.Text = "← Вернуться на главную";
            linkToMain.LinkClicked += linkToMain_LinkClicked;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI Semibold", 16.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelName.ForeColor = Color.FromArgb(10, 60, 0);
            labelName.Location = new Point(52, 68);
            labelName.Name = "labelName";
            labelName.Size = new Size(227, 30);
            labelName.TabIndex = 11;
            labelName.Text = "Название генерации";
            // 
            // groupParametrs
            // 
            groupParametrs.BackColor = SystemColors.Control;
            groupParametrs.Controls.Add(labelHide);
            groupParametrs.Controls.Add(TB_template);
            groupParametrs.Controls.Add(labelTemplate);
            groupParametrs.Controls.Add(labelNGraphs);
            groupParametrs.Controls.Add(labelParametrs);
            groupParametrs.Controls.Add(labelNVertexes);
            groupParametrs.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupParametrs.ForeColor = SystemColors.ControlText;
            groupParametrs.Location = new Point(60, 116);
            groupParametrs.Name = "groupParametrs";
            groupParametrs.Size = new Size(894, 267);
            groupParametrs.TabIndex = 13;
            groupParametrs.TabStop = false;
            groupParametrs.Text = "                ";
            // 
            // labelHide
            // 
            labelHide.AutoSize = true;
            labelHide.Cursor = Cursors.Hand;
            labelHide.Font = new Font("Segoe UI", 9.75F, FontStyle.Underline, GraphicsUnit.Point);
            labelHide.ForeColor = Color.FromArgb(10, 60, 0);
            labelHide.Location = new Point(837, 14);
            labelHide.Name = "labelHide";
            labelHide.Size = new Size(51, 17);
            labelHide.TabIndex = 4;
            labelHide.Text = "Скрыть";
            labelHide.Click += labelHide_Click;
            // 
            // TB_template
            // 
            TB_template.BackColor = Color.WhiteSmoke;
            TB_template.BorderStyle = BorderStyle.FixedSingle;
            TB_template.Cursor = Cursors.IBeam;
            TB_template.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TB_template.Location = new Point(12, 130);
            TB_template.Multiline = true;
            TB_template.Name = "TB_template";
            TB_template.ReadOnly = true;
            TB_template.ScrollBars = ScrollBars.Vertical;
            TB_template.Size = new Size(866, 117);
            TB_template.TabIndex = 12;
            // 
            // labelTemplate
            // 
            labelTemplate.AutoSize = true;
            labelTemplate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelTemplate.Location = new Point(6, 99);
            labelTemplate.Name = "labelTemplate";
            labelTemplate.Size = new Size(117, 21);
            labelTemplate.TabIndex = 11;
            labelTemplate.Text = "Шаблон текста";
            // 
            // labelNGraphs
            // 
            labelNGraphs.AutoSize = true;
            labelNGraphs.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelNGraphs.Location = new Point(6, 29);
            labelNGraphs.Name = "labelNGraphs";
            labelNGraphs.Size = new Size(179, 21);
            labelNGraphs.TabIndex = 9;
            labelNGraphs.Text = "Количество вариантов: ";
            // 
            // labelParametrs
            // 
            labelParametrs.AutoSize = true;
            labelParametrs.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelParametrs.ForeColor = Color.FromArgb(10, 60, 0);
            labelParametrs.Location = new Point(6, 0);
            labelParametrs.Name = "labelParametrs";
            labelParametrs.Size = new Size(92, 21);
            labelParametrs.TabIndex = 5;
            labelParametrs.Text = "Параметры";
            labelParametrs.Click += labelParametrs_Click;
            // 
            // labelNVertexes
            // 
            labelNVertexes.AutoSize = true;
            labelNVertexes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelNVertexes.Location = new Point(6, 64);
            labelNVertexes.Name = "labelNVertexes";
            labelNVertexes.Size = new Size(215, 21);
            labelNVertexes.TabIndex = 3;
            labelNVertexes.Text = "Количество вершин графов: ";
            // 
            // groupGraphs
            // 
            groupGraphs.BackColor = SystemColors.Control;
            groupGraphs.Controls.Add(labelGeneration);
            groupGraphs.Controls.Add(panelGraphs);
            groupGraphs.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupGraphs.ForeColor = SystemColors.ControlText;
            groupGraphs.Location = new Point(60, 389);
            groupGraphs.Name = "groupGraphs";
            groupGraphs.Size = new Size(894, 270);
            groupGraphs.TabIndex = 14;
            groupGraphs.TabStop = false;
            groupGraphs.Text = "               ";
            // 
            // labelGeneration
            // 
            labelGeneration.AutoSize = true;
            labelGeneration.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelGeneration.ForeColor = Color.FromArgb(10, 60, 0);
            labelGeneration.Location = new Point(6, 0);
            labelGeneration.Name = "labelGeneration";
            labelGeneration.Size = new Size(87, 21);
            labelGeneration.TabIndex = 8;
            labelGeneration.Text = "Генерация";
            // 
            // panelGraphs
            // 
            panelGraphs.AutoScroll = true;
            panelGraphs.Dock = DockStyle.Fill;
            panelGraphs.Location = new Point(3, 29);
            panelGraphs.MaximumSize = new Size(888, 10000);
            panelGraphs.Name = "panelGraphs";
            panelGraphs.Size = new Size(888, 238);
            panelGraphs.TabIndex = 11;
            // 
            // buttonPDF
            // 
            buttonPDF.BackColor = SystemColors.ControlLight;
            buttonPDF.FlatAppearance.BorderColor = Color.FromArgb(10, 60, 0);
            buttonPDF.FlatAppearance.MouseDownBackColor = SystemColors.ActiveBorder;
            buttonPDF.FlatAppearance.MouseOverBackColor = SystemColors.ScrollBar;
            buttonPDF.FlatStyle = FlatStyle.Flat;
            buttonPDF.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            buttonPDF.ForeColor = Color.FromArgb(10, 60, 0);
            buttonPDF.Image = (Image)resources.GetObject("buttonPDF.Image");
            buttonPDF.ImageAlign = ContentAlignment.TopCenter;
            buttonPDF.Location = new Point(860, 63);
            buttonPDF.Name = "buttonPDF";
            buttonPDF.Size = new Size(42, 42);
            buttonPDF.TabIndex = 2;
            buttonPDF.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonPDF.UseVisualStyleBackColor = false;
            buttonPDF.Click += buttonPDF_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = SystemColors.ControlLight;
            buttonDelete.FlatAppearance.BorderColor = Color.FromArgb(10, 60, 0);
            buttonDelete.FlatAppearance.MouseDownBackColor = SystemColors.ActiveBorder;
            buttonDelete.FlatAppearance.MouseOverBackColor = SystemColors.ScrollBar;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDelete.ForeColor = Color.FromArgb(10, 60, 0);
            buttonDelete.Image = (Image)resources.GetObject("buttonDelete.Image");
            buttonDelete.ImageAlign = ContentAlignment.BottomCenter;
            buttonDelete.Location = new Point(912, 63);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(42, 42);
            buttonDelete.TabIndex = 3;
            buttonDelete.TextAlign = ContentAlignment.MiddleLeft;
            buttonDelete.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // GenerationUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonDelete);
            Controls.Add(buttonPDF);
            Controls.Add(groupGraphs);
            Controls.Add(groupParametrs);
            Controls.Add(labelName);
            Controls.Add(linkToMain);
            Name = "GenerationUserControl";
            Size = new Size(1014, 719);
            groupParametrs.ResumeLayout(false);
            groupParametrs.PerformLayout();
            groupGraphs.ResumeLayout(false);
            groupGraphs.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel linkToMain;
        private Label labelName;
        private GroupBox groupParametrs;
        private TextBox TB_template;
        private Label labelTemplate;
        private Label labelNGraphs;
        private Label labelParametrs;
        private Label labelNVertexes;
        private GroupBox groupGraphs;
        private Label labelGeneration;
        private FlowLayoutPanel panelGraphs;
        private Button buttonPDF;
        private Button buttonDelete;
        private Label labelHide;
    }
}
