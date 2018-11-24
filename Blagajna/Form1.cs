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
        private int btnWith;
        private int btnHeight;
        private int btnCnt;
        private int spaceBtwBtn;

        public Form1()
        {
            InitializeComponent();

            btnWith = button4.Width;
            btnHeight = button4.Height;
        }

        public System.Windows.Forms.Button AddNewButton()
        {
            System.Windows.Forms.Button btn = new System.Windows.Forms.Button();

            btnCnt++;
            spaceBtwBtn = button3.Location.Y - button2.Location.Y - 40;

            int xx1 = button3.Location.X;
            int yy1 = button3.Location.Y + (spaceBtwBtn * btnCnt) + ((btnCnt - 1) * 40);

            this.Controls.Add(btn);
            btn.Left = xx1;
            btn.Top = yy1 + 40;

            btn.Width = btnWith;
            btn.Height = btnHeight;

            //flowLayoutPanel1.Controls.Add(btn);

            btn.Text = "Maked - " + btnCnt;

            btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.newButtonHandler);

            return btn;
        }

        void newButtonHandler(object sender, EventArgs e)
        {
            Button currBtn = (Button)sender;
            MoveBtn(currBtn);
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

                    if((startPoint.Y - res.Y >= startPoint.Y + 40 || startPoint.X - res.X > startPoint.X + 80) || (startPoint.Y - res.Y <= startPoint.Y - 40 || startPoint.X - res.X < startPoint.X - 80))
                    {
                        if (res.Y > 46)
                        {
                            btnMove.Location = new Point(btnMove.Location.X, btnMove.Location.Y -46);
                            startPoint = temp;
                        }

                        if (res.Y < -46)
                        {
                            btnMove.Location = new Point(btnMove.Location.X, btnMove.Location.Y + 46);
                            startPoint = temp;
                        }

                        if (res.X > 86)
                        {
                            btnMove.Location = new Point(btnMove.Location.X - 86, btnMove.Location.Y);
                            startPoint = temp;
                        }

                        if (res.X < -86)
                        {
                            btnMove.Location = new Point(btnMove.Location.X + 86, btnMove.Location.Y);
                            startPoint = temp;
                        }
                        //btnMove.Location = new Point(btnMove.Location.X - res.X, btnMove.Location.Y - res.Y);

                        //startPoint = temp;
                    }

                    label2.Text = "X " + startPoint.X;
                    label1.Text = "Y " + startPoint.Y;

                    label5.Text = "X " + temp.X;
                    label4.Text = "Y " + temp.Y;

                    label8.Text = "X " + res.X;
                    label7.Text = "Y " + res.Y;
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

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            groupBox1.Text = button1.Text;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
