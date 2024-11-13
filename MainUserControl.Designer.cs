namespace trps_app1
{
    partial class MainUserControl
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
            buttonCreate = new Button();
            groupGenerations = new GroupBox();
            panelGenerations = new FlowLayoutPanel();
            groupGenerations.SuspendLayout();
            SuspendLayout();
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
            buttonCreate.Location = new Point(60, 64);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(221, 56);
            buttonCreate.TabIndex = 0;
            buttonCreate.Text = "Создать генерацию";
            buttonCreate.UseVisualStyleBackColor = false;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // groupGenerations
            // 
            groupGenerations.Controls.Add(panelGenerations);
            groupGenerations.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupGenerations.ForeColor = Color.FromArgb(10, 60, 0);
            groupGenerations.Location = new Point(60, 139);
            groupGenerations.Name = "groupGenerations";
            groupGenerations.Size = new Size(894, 716);
            groupGenerations.TabIndex = 1;
            groupGenerations.TabStop = false;
            groupGenerations.Text = "Ваши генерации";
            // 
            // panelGenerations
            // 
            panelGenerations.AutoScroll = true;
            panelGenerations.Dock = DockStyle.Fill;
            panelGenerations.Location = new Point(3, 25);
            panelGenerations.Name = "panelGenerations";
            panelGenerations.Size = new Size(888, 688);
            panelGenerations.TabIndex = 0;
            // 
            // MainUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonCreate);
            Controls.Add(groupGenerations);
            Name = "MainUserControl";
            Size = new Size(1014, 920);
            groupGenerations.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button buttonCreate;
        private GroupBox groupGenerations;
        private FlowLayoutPanel panelGenerations;
    }
}
