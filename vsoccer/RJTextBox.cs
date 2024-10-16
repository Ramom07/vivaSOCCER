﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vsoccer
{
    public partial class RJTextBox : UserControl
    {

        //

        private Color borderColor = Color.MediumSlateBlue;
        private int bprderSize = 2;
        private bool underlineStyle = false;

        //constructor
        public RJTextBox()
        {
            InitializeComponent();
        }
        //propiedades

        [Category("RJ Code Advance ")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                this.Invalidate();
            }


        }

        [Category("RJ Code Advance ")]
        public int BorderSize
        {
            get
            {
                return bprderSize;
            }
            set 
            {
                bprderSize=value;
                this.Invalidate();
            }
        }
        [Category("RJ Code Advance ")]
        public bool UnderlineStyle
        {
            get 
            { 
            
            return underlineStyle;}

            set { underlineStyle = value;
                this.Invalidate();
            }
        }
        [Category("RJ Code Advance ")]
        public bool PasswordChar
        {
            get { return textBox1.UseSystemPasswordChar; }
            set { textBox1.UseSystemPasswordChar = value;  }
        }
        [Category("RJ Code Advance ")]

        public override Color BackColor
        {
            get
            { return base.BackColor; }

            set
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }
        [Category("RJ Code Advance ")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }
        [Category("RJ Code Advance ")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {

                base.Font = value;
                textBox1.Font = value;
                if (this.DesignMode)
                    UpdateControlHeight();
            }
        }
        [Category ("RJ Code Advance " )]
        public string Texts
        {
            get
            {
            return textBox1.Text;
            }
            set 
            {
            textBox1.Text = value;
            }



        }

        //override 
        protected override void  OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graph = e.Graphics;

            //draw border

            using (Pen penBorder = new Pen(borderColor, bprderSize))
            {
                penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                if (underlineStyle)
                    graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                else
                    graph.DrawRectangle(penBorder, 0, 0, this.Width - 0, this.Height - 0.5F);
            }

        }

        protected override void  OnResize (EventArgs e)
        {
            base.OnResize (e);
            if (this.DesignMode)
                UpdateControlHeight();
            UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }
        
        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false )
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }


        }
    }
}

