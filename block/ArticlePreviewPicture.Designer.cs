namespace block
{
    partial class ArticlePreviewPicture
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LikeCount = new System.Windows.Forms.Label();
            this.DisLikeCount = new System.Windows.Forms.Label();
            this.LikePB = new System.Windows.Forms.PictureBox();
            this.DisLikePB = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LikePB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisLikePB)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LikeCount
            // 
            this.LikeCount.AutoSize = true;
            this.LikeCount.Location = new System.Drawing.Point(251, 159);
            this.LikeCount.Name = "LikeCount";
            this.LikeCount.Size = new System.Drawing.Size(13, 13);
            this.LikeCount.TabIndex = 2;
            this.LikeCount.Text = "0";
            // 
            // DisLikeCount
            // 
            this.DisLikeCount.AutoSize = true;
            this.DisLikeCount.Location = new System.Drawing.Point(310, 159);
            this.DisLikeCount.Name = "DisLikeCount";
            this.DisLikeCount.Size = new System.Drawing.Size(13, 13);
            this.DisLikeCount.TabIndex = 3;
            this.DisLikeCount.Text = "0";
            // 
            // LikePB
            // 
            this.LikePB.Image = global::block.Properties.Resources.like;
            this.LikePB.Location = new System.Drawing.Point(225, 159);
            this.LikePB.Name = "LikePB";
            this.LikePB.Size = new System.Drawing.Size(20, 20);
            this.LikePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LikePB.TabIndex = 4;
            this.LikePB.TabStop = false;
            this.LikePB.Click += new System.EventHandler(this.LikePB_Click);
            // 
            // DisLikePB
            // 
            this.DisLikePB.Image = global::block.Properties.Resources.dislike;
            this.DisLikePB.Location = new System.Drawing.Point(284, 160);
            this.DisLikePB.Name = "DisLikePB";
            this.DisLikePB.Size = new System.Drawing.Size(20, 20);
            this.DisLikePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DisLikePB.TabIndex = 5;
            this.DisLikePB.TabStop = false;
            this.DisLikePB.Click += new System.EventHandler(this.DisLikePB_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(3, 159);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ArticlePreviewPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.DisLikePB);
            this.Controls.Add(this.LikePB);
            this.Controls.Add(this.DisLikeCount);
            this.Controls.Add(this.LikeCount);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ArticlePreviewPicture";
            this.Size = new System.Drawing.Size(330, 190);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LikePB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisLikePB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LikeCount;
        private System.Windows.Forms.Label DisLikeCount;
        private System.Windows.Forms.PictureBox LikePB;
        private System.Windows.Forms.PictureBox DisLikePB;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
