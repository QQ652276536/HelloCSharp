﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp.MyControl
{
    public partial class HintTextBox : TextBox
    {
        public Label hintLabel = null;
        public Button clearBtn = null;

        public HintTextBox()
        {
            InitializeComponent();
            InitHintLabel();
            InitClearBtn();
        }

        public HintTextBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public void InitClearBtn()
        {
            clearBtn = new Button();
            clearBtn.Size = new Size(14, 14);
            clearBtn.BackColor = Color.Transparent;
            clearBtn.BackgroundImage = Image.FromFile("../../Image/关闭1.png");
            clearBtn.BackgroundImageLayout = ImageLayout.Stretch;
            clearBtn.Cursor = Cursors.Hand;
            clearBtn.FlatAppearance.BorderSize = 0;
            clearBtn.FlatStyle = FlatStyle.Flat;
            clearBtn.Click += new EventHandler(clearBtn_Click);
            clearBtn.MouseHover += new EventHandler(clearBtn_MouseHover);
            clearBtn.MouseLeave += new EventHandler(clearBtn_MouseLeave);
            base.Controls.Add(clearBtn);
        }

        private void clearBtn_Click(Object sender, EventArgs e)
        {
            base.Text = String.Empty;
            hintLabel.Visible = true;
        }

        private void clearBtn_MouseHover(Object sender, EventArgs e)
        {
            clearBtn.BackgroundImage = Image.FromFile("../../Image/关闭2.png");
        }

        private void clearBtn_MouseLeave(Object sender, EventArgs e)
        {
            clearBtn.BackgroundImage = Image.FromFile("../../Image/关闭1.png");
        }

        public void InitHintLabel()
        {
            hintLabel = new Label();
            hintLabel.BorderStyle = BorderStyle.None;
            hintLabel.Enabled = false;
            hintLabel.BackColor = Color.Transparent;
            hintLabel.AutoSize = true;
            base.Controls.Add(hintLabel);
        }

        public void LabelIsVisible()
        {
            if (base.Text != String.Empty)
            {
                hintLabel.Visible = false;
            }
            else
            {
                hintLabel.Visible = true;
            }
        }

        public Image BtnImage
        {
            get
            {
                return clearBtn.BackgroundImage;
            }
            set
            {
                clearBtn.BackgroundImage = value;
            }
        }

        public String HintText
        {
            get
            {
                return hintLabel.Text;
            }
            set
            {
                hintLabel.Text = value;
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                LabelIsVisible();
                base.Text = value;
            }
        }

        /// <summary>
        /// 控件大小改变时重新计算其它控件的坐标
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            int tempHeight = (int)((base.Height - hintLabel.Height) / 2) - 2;
            hintLabel.Location = new Point(2, tempHeight);
            tempHeight = (int)((base.Height - clearBtn.Height) / 2) - 2;
            clearBtn.Location = new Point(2, tempHeight);
            base.OnSizeChanged(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            LabelIsVisible();
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            LabelIsVisible();
            base.OnLeave(e);
        }

    }
}
