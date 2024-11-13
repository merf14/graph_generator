namespace trps_app1
{
    partial class CreationUserControl
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
            linkToMain = new LinkLabel();
            buttonCreate = new Button();
            TB_Name = new TextBox();
            labelName = new Label();
            groupBox1 = new GroupBox();
            TB_template = new TextBox();
            labelTemplate = new Label();
            nGraphsBox = new NumericUpDown();
            labelNGraphs = new Label();
            labelParametrs = new Label();
            nVertexesBox = new NumericUpDown();
            labelNVertexes = new Label();
            labelHeader = new Label();
            labelMessage = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nGraphsBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nVertexesBox).BeginInit();
            SuspendLayout();
            // 
            // linkToMain
            // 
            linkToMain.ActiveLinkColor = Color.FromArgb(10, 120, 0);
            linkToMain.AutoSize = true;
            linkToMain.LinkColor = Color.FromArgb(10, 60, 0);
            linkToMain.Location = new Point(66, 42);
            linkToMain.Name = "linkToMain";
            linkToMain.Size = new Size(142, 15);
            linkToMain.TabIndex = 8;
            linkToMain.TabStop = true;
            linkToMain.Text = "← Вернуться на главную";
            linkToMain.LinkClicked += linkToMain_LinkClicked;
            // 
            // buttonCreate
            // 
            buttonCreate.BackColor = SystemColors.ControlLight;
            buttonCreate.FlatAppearance.BorderColor = Color.FromArgb(10, 60, 0);
            buttonCreate.FlatAppearance.MouseDownBackColor = SystemColors.ActiveBorder;
            buttonCreate.FlatAppearance.MouseOverBackColor = SystemColors.ScrollBar;
            buttonCreate.FlatStyle = FlatStyle.Flat;
            buttonCreate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonCreate.ForeColor = Color.FromArgb(10, 60, 0);
            buttonCreate.Location = new Point(754, 691);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(200, 50);
            buttonCreate.TabIndex = 0;
            buttonCreate.Text = "Сгенерировать";
            buttonCreate.UseVisualStyleBackColor = false;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // TB_Name
            // 
            TB_Name.BackColor = Color.White;
            TB_Name.BorderStyle = BorderStyle.FixedSingle;
            TB_Name.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            TB_Name.Location = new Point(181, 139);
            TB_Name.Name = "TB_Name";
            TB_Name.Size = new Size(773, 33);
            TB_Name.TabIndex = 4;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelName.Location = new Point(66, 139);
            labelName.Name = "labelName";
            labelName.Size = new Size(95, 25);
            labelName.TabIndex = 5;
            labelName.Text = "Название";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(TB_template);
            groupBox1.Controls.Add(labelTemplate);
            groupBox1.Controls.Add(nGraphsBox);
            groupBox1.Controls.Add(labelNGraphs);
            groupBox1.Controls.Add(labelParametrs);
            groupBox1.Controls.Add(nVertexesBox);
            groupBox1.Controls.Add(labelNVertexes);
            groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.ForeColor = SystemColors.ControlText;
            groupBox1.Location = new Point(60, 198);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(894, 444);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "                ";
            // 
            // TB_template
            // 
            TB_template.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TB_template.Location = new Point(275, 143);
            TB_template.Multiline = true;
            TB_template.Name = "TB_template";
            TB_template.Size = new Size(584, 261);
            TB_template.TabIndex = 12;
            // 
            // labelTemplate
            // 
            labelTemplate.AutoSize = true;
            labelTemplate.Location = new Point(6, 143);
            labelTemplate.Name = "labelTemplate";
            labelTemplate.Size = new Size(142, 25);
            labelTemplate.TabIndex = 11;
            labelTemplate.Text = "Шаблон текста";
            // 
            // nGraphsBox
            // 
            nGraphsBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nGraphsBox.Location = new Point(275, 37);
            nGraphsBox.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nGraphsBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nGraphsBox.Name = "nGraphsBox";
            nGraphsBox.Size = new Size(76, 29);
            nGraphsBox.TabIndex = 10;
            nGraphsBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelNGraphs
            // 
            labelNGraphs.AutoSize = true;
            labelNGraphs.Location = new Point(6, 39);
            labelNGraphs.Name = "labelNGraphs";
            labelNGraphs.Size = new Size(211, 25);
            labelNGraphs.TabIndex = 9;
            labelNGraphs.Text = "Количество вариантов";
            // 
            // labelParametrs
            // 
            labelParametrs.AutoSize = true;
            labelParametrs.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelParametrs.ForeColor = Color.FromArgb(10, 60, 0);
            labelParametrs.Location = new Point(6, 0);
            labelParametrs.Name = "labelParametrs";
            labelParametrs.Size = new Size(92, 21);
            labelParametrs.TabIndex = 8;
            labelParametrs.Text = "Параметры";
            // 
            // nVertexesBox
            // 
            nVertexesBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nVertexesBox.Location = new Point(275, 89);
            nVertexesBox.Maximum = new decimal(new int[] { 14, 0, 0, 0 });
            nVertexesBox.Minimum = new decimal(new int[] { 7, 0, 0, 0 });
            nVertexesBox.Name = "nVertexesBox";
            nVertexesBox.Size = new Size(76, 29);
            nVertexesBox.TabIndex = 2;
            nVertexesBox.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // labelNVertexes
            // 
            labelNVertexes.AutoSize = true;
            labelNVertexes.Location = new Point(6, 91);
            labelNVertexes.Name = "labelNVertexes";
            labelNVertexes.Size = new Size(254, 25);
            labelNVertexes.TabIndex = 3;
            labelNVertexes.Text = "Количество вершин графов";
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new Font("Segoe UI Semibold", 16.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelHeader.ForeColor = Color.FromArgb(10, 60, 0);
            labelHeader.Location = new Point(66, 82);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new Size(298, 30);
            labelHeader.TabIndex = 9;
            labelHeader.Text = "Создание новой генерации";
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelMessage.ForeColor = Color.FromArgb(192, 0, 0);
            labelMessage.Location = new Point(426, 709);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(305, 17);
            labelMessage.TabIndex = 10;
            labelMessage.Text = "Поле \"Название\" обязательно для заполнения.";
            labelMessage.Visible = false;
            // 
            // CreationUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelMessage);
            Controls.Add(labelHeader);
            Controls.Add(linkToMain);
            Controls.Add(groupBox1);
            Controls.Add(labelName);
            Controls.Add(TB_Name);
            Controls.Add(buttonCreate);
            Name = "CreationUserControl";
            Size = new Size(1014, 920);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nGraphsBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)nVertexesBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private LinkLabel linkToMain;
        private Button buttonCreate;
        private TextBox TB_Name;
        private Label labelName;
        private GroupBox groupBox1;
        private TextBox TB_template;
        private Label labelTemplate;
        private NumericUpDown nGraphsBox;
        private Label labelNGraphs;
        private Label labelParametrs;
        private NumericUpDown nVertexesBox;
        private Label labelNVertexes;
        private Label labelHeader;
        private Label labelMessage;
    }
}
