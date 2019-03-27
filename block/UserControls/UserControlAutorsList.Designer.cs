namespace block
{
    partial class UserControlAutorsList
    {
        /// <summary> 
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelPopular = new System.Windows.Forms.Label();
            this.labelAll = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPopular
            // 
            this.labelPopular.AutoSize = true;
            this.labelPopular.Location = new System.Drawing.Point(9, 9);
            this.labelPopular.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPopular.Name = "labelPopular";
            this.labelPopular.Size = new System.Drawing.Size(171, 17);
            this.labelPopular.TabIndex = 13;
            this.labelPopular.Text = "ПОПУЛЯРНЫЕ АВТОРЫ";
            this.labelPopular.Click += new System.EventHandler(this.labelPopular_Click);
            // 
            // labelAll
            // 
            this.labelAll.AutoSize = true;
            this.labelAll.Location = new System.Drawing.Point(131, 180);
            this.labelAll.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAll.Name = "labelAll";
            this.labelAll.Size = new System.Drawing.Size(82, 17);
            this.labelAll.TabIndex = 14;
            this.labelAll.Text = "все авторы";
            // 
            // UserControlAutorsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelAll);
            this.Controls.Add(this.labelPopular);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserControlAutorsList";
            this.Size = new System.Drawing.Size(217, 207);
            this.Load += new System.EventHandler(this.UserControlAutorsList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPopular;
        private System.Windows.Forms.Label labelAll;
    }
}
