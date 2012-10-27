using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpookyVision
{
    public partial class Spooky : Form
    {
        int i = 1;

        public Spooky()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void Spooky_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
            this.TransparencyKey = Color.Transparent;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Update();

            this.Location = new Point(0, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }

        private void blink_Tick(object sender, EventArgs e)
        {
            if (i == 1)
            {
                this.BackColor = Color.Magenta;
                i++;
            }
            else
            {
                this.BackColor = Color.Lime;
                i = 1;
            }
        }

        private void topMost_Tick(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
    }
}
