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
        private int btnWithMove;
        private int btnHeightMove;
        private int btnCnt;
        private int spaceBtwBtn;
        private List<Button> btnList = new List<Button>();
        private int xx1;
        private int yy1;
        private Point temp;
        private Point res;

        public Form1()
        {
            InitializeComponent();

            spaceBtwBtn = 6;
            btnWithMove = button1.Width + spaceBtwBtn;
            btnHeightMove = button1.Height + spaceBtwBtn;

            xx1 = button1.Location.X;
            yy1 = button1.Location.Y + spaceBtwBtn;
        }

        public Button AddNewButton()
        {
            Button btn = new Button();

            btnCnt++;

            //xx1 = button1.Location.X;
            //yy1 = button1.Location.Y + (spaceBtwBtn * btnCnt) + ((btnCnt - 1) * 40);

            this.Controls.Add(btn);

            btn.Width = button1.Width;
            btn.Height = button1.Height;
            btn.Left = xx1;
            btn.Top = yy1 + btn.Height;

            xx1 = btn.Location.X;
            yy1 = btn.Location.Y + spaceBtwBtn;

            btn.Text = "Maked - " + btnCnt;
            btn.MouseDown += new MouseEventHandler(this.newButtonHandler);
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
                if (ee.Button == MouseButtons.Left)
                {
                    temp = Control.MousePosition;
                    res = new Point(startPoint.X - temp.X, startPoint.Y - temp.Y);

                    if((startPoint.Y - res.Y >= startPoint.Y + (btnHeightMove - spaceBtwBtn) || startPoint.X - res.X > startPoint.X + (btnWithMove - spaceBtwBtn)) 
                    || (startPoint.Y - res.Y <= startPoint.Y - (btnHeightMove - spaceBtwBtn) || startPoint.X - res.X < startPoint.X - (btnWithMove - spaceBtwBtn)))
                    {
                        if (res.Y > btnHeightMove)
                        {
                            btnMove.Location = new Point(btnMove.Location.X, btnMove.Location.Y - btnHeightMove);
                            resetCounters(btnMove);
                        }

                        if (res.Y < -btnHeightMove)
                        {
                            btnMove.Location = new Point(btnMove.Location.X, btnMove.Location.Y + btnHeightMove);
                            resetCounters(btnMove);
                        }

                        if (res.X > btnWithMove)
                        {
                            btnMove.Location = new Point(btnMove.Location.X - btnWithMove, btnMove.Location.Y);
                            resetCounters(btnMove);
                        }

                        if (res.X < -btnWithMove)
                        {
                            btnMove.Location = new Point(btnMove.Location.X + btnWithMove, btnMove.Location.Y);
                            resetCounters(btnMove);
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

        private void resetCounters(Button btn)
        {
            startPoint = temp;
            xx1 = btn.Location.X;
            yy1 = btn.Location.Y + spaceBtwBtn;

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            MoveBtn(button1);
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
