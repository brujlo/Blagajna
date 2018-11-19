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
            AddNewButton();
        }

        public System.Windows.Forms.Button AddNewButton()
        {
            System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
            int x1 = button1.Location.X;
            int y1 = button1.Location.Y;
            int x2 = button2.Location.X;
            int y2 = button2.Location.Y;

            this.Controls.Add(btn);
            btn.Left = x1;
            btn.Top = ((y2 - y1) / 2) + y1;

            //flowLayoutPanel1.Controls.Add(btn);

            btn.Text = "Maked";

            return btn;
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
    }
}
