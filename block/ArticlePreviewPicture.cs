﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace block
{
    public partial class ArticlePreviewPicture : UserControl
    {
        private int like = 0;
        private int dislike = 0;
        private bool changed = false;
        private bool like_pressed = false;
        private bool dislike_pressed = false;


        private string URL_;
        public ArticlePreviewPicture(string URL, string Article, int Likes, int DisLikes)
        {
            InitializeComponent();
            like = Likes;
            dislike = DisLikes;
            URL_ = URL;

            pictureBox1.LoadAsync(URL);
            linkLabel1.Text = Article;
            LikeCount.Text = Likes.ToString();
            DisLikeCount.Text = DisLikes.ToString();
            DisLikePB.Image = Properties.Resources.dislike;
            LikePB.Image = Properties.Resources.like;
        }

        public ArticlePreviewPicture(string Article)
        {
            InitializeComponent();
            var url_pic = SQLClass.Select(string.Format("SELECT `Picture` FROM `Articles1` WHERE `Header`='{0}'", Article));
            pictureBox1.Load(url_pic[0]);
            var likes_dislikes = SQLClass.Select(string.Format("SELECT `LikesCount`, `DisCount` FROM `Likes` WHERE `Article`='{0}'", Article));
            like = Int32.Parse(likes_dislikes[0]);
            dislike = Int32.Parse(likes_dislikes[1]);
            linkLabel1.Text = Article;
        }

        public JObject Data
        {
            get
            {
                return new JObject(new Dictionary<string, dynamic> {
                    {"Article", linkLabel1.Name},
                    {"Likes", LikeCount.Text},
                    {"DisLikes", DisLikeCount.Text},
                    {"URL", URL_}
                });
            }
            set
            {
                linkLabel1.Text = value["Article"].ToString();
                LikeCount.Text = value["Likes"].ToString();
                DisLikeCount.Text = value["DisLikes"].ToString();
                pictureBox1.Load(value["URL"].ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        #region Логика лайков (не работает пока)
        private void LikePB_Click(object sender, EventArgs e)
        {
            if (!like_pressed)
            {
                if (!dislike_pressed)
                {
                    like_pressed = true;
                    LikePB.Image = Properties.Resources.like_pressed;
                    like += 1;
                    LikeCount.Text = like.ToString();
                }
                else
                {
                    dislike_pressed = false;
                    like_pressed = true;

                    LikePB.Image = Properties.Resources.like_pressed;
                    like += 1;
                    LikeCount.Text = like.ToString();

                    DisLikePB.Image = Properties.Resources.dislike;
                    dislike -= 1;
                    DisLikeCount.Text = dislike.ToString();
                    changed = false;
                }
            }
            else
            {
                LikePB.Image = Properties.Resources.like;
                like -= 1;
                LikeCount.Text = like.ToString();
                return;
            }
        }

        private void DisLikePB_Click(object sender, EventArgs e)
        {
            if (!dislike_pressed)
            {
                if (!like_pressed)
                {
                    dislike_pressed = true;
                    DisLikePB.Image = Properties.Resources.dislike_pressed;
                    dislike += 1;
                    DisLikeCount.Text = dislike.ToString();
                    return;
                }

                like_pressed = false;
                dislike_pressed = true;

                DisLikePB.Image = Properties.Resources.dislike_pressed;
                dislike += 1;
                DisLikeCount.Text = dislike.ToString();

                LikePB.Image = Properties.Resources.like;
                like -= 1;
                LikeCount.Text = like.ToString();
                return;
            }
            else
            {
                DisLikePB.Image = Properties.Resources.dislike;
                dislike -= 1;
                DisLikeCount.Text = dislike.ToString();
                return;
            }
        }
        #endregion
    }
}
