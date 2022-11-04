namespace InputDataForVolumePlanning
{
    partial class IJTInput
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
            this.ItemsLabel = new System.Windows.Forms.Label();
            this.ItemsNumeric = new System.Windows.Forms.NumericUpDown();
            this.JobsNumeric = new System.Windows.Forms.NumericUpDown();
            this.JobsLabel = new System.Windows.Forms.Label();
            this.TactsNumeric = new System.Windows.Forms.NumericUpDown();
            this.TactsLabel = new System.Windows.Forms.Label();
            this.HeaderLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TactsNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemsLabel
            // 
            this.ItemsLabel.AutoSize = true;
            this.ItemsLabel.Location = new System.Drawing.Point(9, 30);
            this.ItemsLabel.Name = "ItemsLabel";
            this.ItemsLabel.Size = new System.Drawing.Size(53, 15);
            this.ItemsLabel.TabIndex = 0;
            this.ItemsLabel.Text = "Изделия";
            // 
            // ItemsNumeric
            // 
            this.ItemsNumeric.Location = new System.Drawing.Point(68, 28);
            this.ItemsNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.ItemsNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ItemsNumeric.Name = "ItemsNumeric";
            this.ItemsNumeric.Size = new System.Drawing.Size(120, 23);
            this.ItemsNumeric.TabIndex = 1;
            this.ItemsNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // JobsNumeric
            // 
            this.JobsNumeric.Location = new System.Drawing.Point(68, 57);
            this.JobsNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.JobsNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.JobsNumeric.Name = "JobsNumeric";
            this.JobsNumeric.Size = new System.Drawing.Size(120, 23);
            this.JobsNumeric.TabIndex = 3;
            this.JobsNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // JobsLabel
            // 
            this.JobsLabel.AutoSize = true;
            this.JobsLabel.Location = new System.Drawing.Point(9, 59);
            this.JobsLabel.Name = "JobsLabel";
            this.JobsLabel.Size = new System.Drawing.Size(48, 15);
            this.JobsLabel.TabIndex = 2;
            this.JobsLabel.Text = "Работы";
            // 
            // TactsNumeric
            // 
            this.TactsNumeric.Location = new System.Drawing.Point(68, 86);
            this.TactsNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.TactsNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TactsNumeric.Name = "TactsNumeric";
            this.TactsNumeric.Size = new System.Drawing.Size(120, 23);
            this.TactsNumeric.TabIndex = 5;
            this.TactsNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TactsLabel
            // 
            this.TactsLabel.AutoSize = true;
            this.TactsLabel.Location = new System.Drawing.Point(9, 88);
            this.TactsLabel.Name = "TactsLabel";
            this.TactsLabel.Size = new System.Drawing.Size(39, 15);
            this.TactsLabel.TabIndex = 4;
            this.TactsLabel.Text = "Такты";
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Location = new System.Drawing.Point(9, 9);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(113, 15);
            this.HeaderLabel.TabIndex = 6;
            this.HeaderLabel.Text = "Общее количество";
            // 
            // IJTInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.HeaderLabel);
            this.Controls.Add(this.TactsNumeric);
            this.Controls.Add(this.TactsLabel);
            this.Controls.Add(this.JobsNumeric);
            this.Controls.Add(this.JobsLabel);
            this.Controls.Add(this.ItemsNumeric);
            this.Controls.Add(this.ItemsLabel);
            this.Name = "IJTInput";
            this.Size = new System.Drawing.Size(203, 122);
            ((System.ComponentModel.ISupportInitialize)(this.ItemsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TactsNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label ItemsLabel;
        private NumericUpDown ItemsNumeric;
        private NumericUpDown JobsNumeric;
        private Label JobsLabel;
        private NumericUpDown TactsNumeric;
        private Label TactsLabel;
        private Label HeaderLabel;
    }
}
