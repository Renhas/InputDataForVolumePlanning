namespace InputDataForVolumePlanning
{
    partial class CoefficientsInput
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
            this.components = new System.ComponentModel.Container();
            this.MainComboBox = new System.Windows.Forms.ComboBox();
            this.SourceForComboBox = new System.Windows.Forms.BindingSource(this.components);
            this.SelectPanel = new System.Windows.Forms.Panel();
            this.ControlledCheckBox = new System.Windows.Forms.CheckBox();
            this.MinMaxLabel = new System.Windows.Forms.Label();
            this.MaxNumeric = new System.Windows.Forms.NumericUpDown();
            this.MinNumeric = new System.Windows.Forms.NumericUpDown();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.CoefsPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.SourceForComboBox)).BeginInit();
            this.SelectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinNumeric)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainComboBox
            // 
            this.MainComboBox.FormattingEnabled = true;
            this.MainComboBox.Location = new System.Drawing.Point(3, 5);
            this.MainComboBox.Name = "MainComboBox";
            this.MainComboBox.Size = new System.Drawing.Size(121, 23);
            this.MainComboBox.TabIndex = 0;
            this.MainComboBox.SelectedIndexChanged += new System.EventHandler(this.MainComboBox_SelectedIndexChanged);
            // 
            // SelectPanel
            // 
            this.SelectPanel.Controls.Add(this.ControlledCheckBox);
            this.SelectPanel.Controls.Add(this.MinMaxLabel);
            this.SelectPanel.Controls.Add(this.MaxNumeric);
            this.SelectPanel.Controls.Add(this.MainComboBox);
            this.SelectPanel.Controls.Add(this.MinNumeric);
            this.SelectPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SelectPanel.Location = new System.Drawing.Point(0, 0);
            this.SelectPanel.Name = "SelectPanel";
            this.SelectPanel.Size = new System.Drawing.Size(717, 34);
            this.SelectPanel.TabIndex = 2;
            // 
            // ControlledCheckBox
            // 
            this.ControlledCheckBox.AutoSize = true;
            this.ControlledCheckBox.Location = new System.Drawing.Point(565, 8);
            this.ControlledCheckBox.Name = "ControlledCheckBox";
            this.ControlledCheckBox.Size = new System.Drawing.Size(121, 19);
            this.ControlledCheckBox.TabIndex = 5;
            this.ControlledCheckBox.Text = "Контролируемое";
            this.ControlledCheckBox.UseVisualStyleBackColor = true;
            // 
            // MinMaxLabel
            // 
            this.MinMaxLabel.AutoSize = true;
            this.MinMaxLabel.Location = new System.Drawing.Point(130, 8);
            this.MinMaxLabel.Name = "MinMaxLabel";
            this.MinMaxLabel.Size = new System.Drawing.Size(177, 15);
            this.MinMaxLabel.TabIndex = 4;
            this.MinMaxLabel.Text = "Ограничения по нормо-часам";
            // 
            // MaxNumeric
            // 
            this.MaxNumeric.Location = new System.Drawing.Point(439, 5);
            this.MaxNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.MaxNumeric.Name = "MaxNumeric";
            this.MaxNumeric.Size = new System.Drawing.Size(120, 23);
            this.MaxNumeric.TabIndex = 2;
            this.MaxNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.MaxNumeric.ValueChanged += new System.EventHandler(this.MaxNumeric_ValueChanged);
            // 
            // MinNumeric
            // 
            this.MinNumeric.Location = new System.Drawing.Point(313, 6);
            this.MinNumeric.Name = "MinNumeric";
            this.MinNumeric.Size = new System.Drawing.Size(120, 23);
            this.MinNumeric.TabIndex = 1;
            this.MinNumeric.ValueChanged += new System.EventHandler(this.MinNumeric_ValueChanged);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.CoefsPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 34);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(717, 416);
            this.MainPanel.TabIndex = 3;
            // 
            // CoefsPanel
            // 
            this.CoefsPanel.AutoScroll = true;
            this.CoefsPanel.ColumnCount = 2;
            this.CoefsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.CoefsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.CoefsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.CoefsPanel.Location = new System.Drawing.Point(0, 0);
            this.CoefsPanel.Name = "CoefsPanel";
            this.CoefsPanel.RowCount = 2;
            this.CoefsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoefsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoefsPanel.Size = new System.Drawing.Size(434, 416);
            this.CoefsPanel.TabIndex = 3;
            // 
            // CoefficientsInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.SelectPanel);
            this.Name = "CoefficientsInput";
            this.Size = new System.Drawing.Size(717, 450);
            ((System.ComponentModel.ISupportInitialize)(this.SourceForComboBox)).EndInit();
            this.SelectPanel.ResumeLayout(false);
            this.SelectPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinNumeric)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox MainComboBox;
        private BindingSource SourceForComboBox;
        private Panel SelectPanel;
        private Panel MainPanel;
        private NumericUpDown MaxNumeric;
        private NumericUpDown MinNumeric;
        private TableLayoutPanel CoefsPanel;
        private Label MinMaxLabel;
        private CheckBox ControlledCheckBox;
    }
}
