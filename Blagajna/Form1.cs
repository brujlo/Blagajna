using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blagajna
{
    public partial class Form1 : Form
    {
        private Point startPoint = new Point();

        public Form1()
        {
            InitializeComponent();
        }

        public System.Windows.Forms.Button AddNewButton()
        {
            System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
            int x1 = button4.Location.X;
            int y1 = button4.Location.Y;

            this.Controls.Add(btn);
            btn.Left = x1;
            btn.Top = y1 + 40;

            //flowLayoutPanel1.Controls.Add(btn);

            btn.Text = "Maked";

            btn.Click += new System.EventHandler(this.newButtonHandler);

            return btn;
        }

        void newButtonHandler(object sender, EventArgs e)
        {
            Button currBtn = (Button)sender;
            MessageBox.Show("Clicked");
        }

        public void MoveBtn(Button btnMove)
        {
            startPoint = Control.MousePosition;

            btnMove.MouseMove += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Point temp = Control.MousePosition;
                    Point res = new Point(startPoint.X - temp.X, startPoint.Y - temp.Y);

                    btnMove.Location = new Point(btnMove.Location.X - res.X, btnMove.Location.Y - res.Y);

                    startPoint = temp;
                }
            };
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            MoveBtn(button1);
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            MoveBtn(button2);
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            MoveBtn(button3);
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            AddNewButton();
        }
    }
}
