namespace InputDataForVolumePlanning
{
    partial class ResultOutput
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
            this.ResultList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ResultList
            // 
            this.ResultList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultList.FormattingEnabled = true;
            this.ResultList.HorizontalScrollbar = true;
            this.ResultList.ItemHeight = 15;
            this.ResultList.Location = new System.Drawing.Point(0, 0);
            this.ResultList.Name = "ResultList";
            this.ResultList.Size = new System.Drawing.Size(300, 400);
            this.ResultList.TabIndex = 0;
            // 
            // ResultOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ResultList);
            this.Name = "ResultOutput";
            this.Size = new System.Drawing.Size(300, 400);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox ResultList;
    }
}
