namespace block
{
    partial class ArticleDetailsUserControl
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
            this.ArticleLabel = new System.Windows.Forms.Label();
            this.ArticleTextLabel = new System.Windows.Forms.Label();
            this.AuthorsNameLabel = new System.Windows.Forms.Label();
            this.ArticlePicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ArticlePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ArticleLabel
            // 
            this.ArticleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ArticleLabel.Location = new System.Drawing.Point(5, 5);
            this.ArticleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ArticleLabel.Name = "ArticleLabel";
            this.ArticleLabel.Size = new System.Drawing.Size(295, 28);
            this.ArticleLabel.TabIndex = 0;
            this.ArticleLabel.Text = "Заголовок";
            // 
            // ArticleTextLabel
            // 
            this.ArticleTextLabel.Location = new System.Drawing.Point(5, 214);
            this.ArticleTextLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ArticleTextLabel.Name = "ArticleTextLabel";
            this.ArticleTextLabel.Size = new System.Drawing.Size(456, 233);
            this.ArticleTextLabel.TabIndex = 2;
            this.ArticleTextLabel.Text = "Текст статьи";
            // 
            // AuthorsNameLabel
            // 
            this.AuthorsNameLabel.AutoSize = true;
            this.AuthorsNameLabel.Location = new System.Drawing.Point(308, 7);
            this.AuthorsNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AuthorsNameLabel.Name = "AuthorsNameLabel";
            this.AuthorsNameLabel.Size = new System.Drawing.Size(85, 17);
            this.AuthorsNameLabel.TabIndex = 3;
            this.AuthorsNameLabel.Text = "Имя автора";
            // 
            // ArticlePicture
            // 
            this.ArticlePicture.Location = new System.Drawing.Point(9, 37);
            this.ArticlePicture.Margin = new System.Windows.Forms.Padding(4);
            this.ArticlePicture.Name = "ArticlePicture";
            this.ArticlePicture.Size = new System.Drawing.Size(452, 160);
            this.ArticlePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ArticlePicture.TabIndex = 1;
            this.ArticlePicture.TabStop = false;
            this.ArticlePicture.Click += new System.EventHandler(this.ArticlePicture_Click);
            // 
            // ArticleDetailsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AuthorsNameLabel);
            this.Controls.Add(this.ArticleTextLabel);
            this.Controls.Add(this.ArticlePicture);
            this.Controls.Add(this.ArticleLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ArticleDetailsUserControl";
            this.Size = new System.Drawing.Size(475, 463);
            ((System.ComponentModel.ISupportInitialize)(this.ArticlePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ArticleLabel;
        private System.Windows.Forms.PictureBox ArticlePicture;
        private System.Windows.Forms.Label ArticleTextLabel;
        private System.Windows.Forms.Label AuthorsNameLabel;
    }
}
