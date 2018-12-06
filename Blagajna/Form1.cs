using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

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
        private int startPointX;
        private int startPointY;

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
            BtnClick(currBtn);
        }

        public void BtnClick(Button btnClick)
        {
            btnClick.Click += (s, e) =>
            {
                //btnClick.Text = groupBox1.Text = ConnectionHelper.GetFirstValueAsString("select FullName from Sifrarnik where FullCode = 13002010");
            };
        }

        public void MoveBtn(Button btnMove)
        {
            startPoint = Control.MousePosition;
            startPointX = btnMove.Location.X;
            startPointY = btnMove.Location.Y;

            btnMove.MouseMove += (ss, ee) =>
            {
                if (ee.Button == MouseButtons.Left)
                {
                    temp = Control.MousePosition;
                    res = new Point(startPoint.X - temp.X, startPoint.Y - temp.Y);

                    if ((startPoint.Y - res.Y >= startPoint.Y + (btnHeightMove - spaceBtwBtn) || startPoint.X - res.X > startPoint.X + (btnWithMove - spaceBtwBtn))
                    || (startPoint.Y - res.Y <= startPoint.Y - (btnHeightMove - spaceBtwBtn) || startPoint.X - res.X < startPoint.X - (btnWithMove - spaceBtwBtn)))
                    {
                        if(startPoint.Y - res.Y >= startPoint.Y + (btnHeightMove - spaceBtwBtn) || startPoint.Y - res.Y <= startPoint.Y - (btnHeightMove - spaceBtwBtn))
                            checkForControlPositionY(btnMove);
                        if (startPoint.X - res.X > startPoint.X + (btnWithMove - spaceBtwBtn) || startPoint.X - res.X < startPoint.X - (btnWithMove - spaceBtwBtn))
                            checkForControlPositionX(btnMove);

                        resetCounters(btnMove);

                        //label2.Text = "X " + startPoint.X;
                        //label1.Text = "Y " + startPoint.Y;

                        //label5.Text = "X " + temp.X;
                        //label4.Text = "Y " + temp.Y;

                        //label8.Text = "X " + res.X;
                        //label7.Text = "Y " + res.Y;

                        //label11.Text = "H " + btnHeightMove;
                        //label10.Text = "X " + btnMove.Location.X;
                        //label13.Text = "Y " + btnMove.Location.Y;
                    }
                    label2.Text = "X " + startPoint.X;
                    label1.Text = "Y " + startPoint.Y;

                    label5.Text = "X " + temp.X;
                    label4.Text = "Y " + temp.Y;

                    label8.Text = "X " + res.X;
                    label7.Text = "Y " + res.Y;

                    label11.Text = "H " + btnHeightMove;
                    label10.Text = "X " + btnMove.Location.X;
                    label13.Text = "Y " + btnMove.Location.Y;
                }
            };
        }

        private void checkForControlPositionY(Button btnMove)
        {
            List<Control> c = getButtnos();
            int emptySpace = btnMove.Location.Y;
            int controlsInList = c.Count;
            List<int> spaces = new List<int>();
            List<int> emptySpaces = new List<int>();

            foreach (Control k in c)
            {
                if (k.Text != btnMove.Text && k.Location.X == btnMove.Location.X)
                {
                    spaces.Add(k.Location.Y);
                }
            }

            //MoveDown
            if (res.Y < 0)
            {
                for (int i = 1; i < c.Count; i++)
                {
                    if (!spaces.Contains(btnMove.Location.Y + (btnHeightMove * i)))
                    {
                        emptySpaces.Add(btnMove.Location.Y + (btnHeightMove * i));
                    }
                }
                btnMove.Location = new Point(btnMove.Location.X, emptySpaces.Min());
            }
            //MoveUp
            if (res.Y > 0)
            {
                for (int i = 1; i < c.Count; i++)
                {
                    if (!spaces.Contains(btnMove.Location.Y - (btnHeightMove * i)))
                    {
                        emptySpaces.Add(btnMove.Location.Y - (btnHeightMove * i));
                    }
                }
                btnMove.Location = new Point(btnMove.Location.X, emptySpaces.Max());
            }
        }

        private void checkForControlPositionX(Button btnMove)
        {
            List<Control> c = getButtnos();
            int emptySpace = btnMove.Location.X;
            int controlsInList = c.Count;
            List<int> spaces = new List<int>();
            List<int> emptySpaces = new List<int>();

            foreach (Control k in c)
            {
                if (k.Text != btnMove.Text && k.Location.X != btnMove.Location.X)
                {
                    spaces.Add(k.Location.Y);
                }
            }

            //MoveLeft
            if (res.X > 0)
            {
                for (int i = 1; i < c.Count; i++)
                {
                    if (!spaces.Contains(btnMove.Location.Y))
                    {
                        emptySpaces.Add(btnMove.Location.Y);
                    }
                }
                if (!spaces.Contains(btnMove.Location.Y))
                {
                    btnMove.Location = new Point(btnMove.Location.X - btnWithMove, btnMove.Location.Y);
                }
                else
                {
                    btnMove.Location = new Point(btnMove.Location.X - btnWithMove, emptySpaces.Max());
                }
                    
            }

            //MoveRight
            if (res.X < 0)
            {
                for (int i = 1; i < c.Count; i++)
                {
                    if (!spaces.Contains(btnMove.Location.Y))
                    {
                        emptySpaces.Add(btnMove.Location.Y);
                    }
                }
                if (!spaces.Contains(btnMove.Location.Y))
                {
                    btnMove.Location = new Point(btnMove.Location.X + btnWithMove, btnMove.Location.Y);
                }
                else
                {
                    btnMove.Location = new Point(btnMove.Location.X - btnWithMove, emptySpaces.Max());
                }
            }
        }

        private void resetCounters(Button btn)
        {
            startPoint = temp;
            xx1 = btn.Location.X;
            yy1 = btn.Location.Y + spaceBtwBtn;

        }

        private List<Control> getButtnos()
        {
            List<Control> c = Controls.OfType<Button>().Cast<Control>().ToList();
            return c;
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
            //button1.Text = groupBox1.Text = ConnectionHelper.GetFirstValueAsString("select FullName from Sifrarnik where FullCode = 13002010");
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
