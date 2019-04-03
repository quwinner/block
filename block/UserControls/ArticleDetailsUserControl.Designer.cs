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
            this.ArticleLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ArticleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ArticleLabel.Location = new System.Drawing.Point(4, 4);
            this.ArticleLabel.Name = "ArticleLabel";
            this.ArticleLabel.Size = new System.Drawing.Size(221, 23);
            this.ArticleLabel.TabIndex = 0;
            this.ArticleLabel.Text = "Заголовок";
            // 
            // ArticleTextLabel
            // 
            this.ArticleTextLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ArticleTextLabel.Location = new System.Drawing.Point(4, 174);
            this.ArticleTextLabel.Name = "ArticleTextLabel";
            this.ArticleTextLabel.Size = new System.Drawing.Size(342, 189);
            this.ArticleTextLabel.TabIndex = 2;
            this.ArticleTextLabel.Text = "Текст статьи";
            this.ArticleTextLabel.Click += new System.EventHandler(this.ArticleTextLabel_Click);
            // 
            // AuthorsNameLabel
            // 
            this.AuthorsNameLabel.AutoSize = true;
            this.AuthorsNameLabel.BackColor = System.Drawing.SystemColors.Control;
            this.AuthorsNameLabel.Location = new System.Drawing.Point(231, 6);
            this.AuthorsNameLabel.Name = "AuthorsNameLabel";
            this.AuthorsNameLabel.Size = new System.Drawing.Size(67, 13);
            this.AuthorsNameLabel.TabIndex = 3;
            this.AuthorsNameLabel.Text = "Имя автора";
            // 
            // ArticlePicture
            // 
            this.ArticlePicture.BackColor = System.Drawing.SystemColors.Control;
            this.ArticlePicture.Location = new System.Drawing.Point(7, 30);
            this.ArticlePicture.Name = "ArticlePicture";
            this.ArticlePicture.Size = new System.Drawing.Size(339, 130);
            this.ArticlePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ArticlePicture.TabIndex = 1;
            this.ArticlePicture.TabStop = false;
            // 
            // ArticleDetailsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.AuthorsNameLabel);
            this.Controls.Add(this.ArticleTextLabel);
            this.Controls.Add(this.ArticlePicture);
            this.Controls.Add(this.ArticleLabel);
            this.Name = "ArticleDetailsUserControl";
            this.Size = new System.Drawing.Size(356, 376);
            this.Load += new System.EventHandler(this.ArticleDetailsUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ArticlePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label ArticleLabel;
        public System.Windows.Forms.PictureBox ArticlePicture;
        public System.Windows.Forms.Label ArticleTextLabel;
        public System.Windows.Forms.Label AuthorsNameLabel;
    }
}
