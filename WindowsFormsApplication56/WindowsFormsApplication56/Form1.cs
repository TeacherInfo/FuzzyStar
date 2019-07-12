using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication56
{
    public partial class Form1 : Form
    {
        List<Vertex> list;
        public Vertex p,left,right;
        public int Flag,FlagRibs,leftindex,rightindex;
        Graphics gr1;
        int Count;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
        //    MessageBox.Show("Mouse click");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list = new List<Vertex>();
            Flag = 0;
            FlagRibs = 0;
            leftindex = 0;
            rightindex = 0;
            Count = 0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
          
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            MessageBox.Show("KeyUp");
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

            if (list.Count == 0)
            {
                p = new Vertex();
                p.point.X = e.X;
                p.point.Y = e.Y;
                p.check = false;
                list.Add(p);
                
               // break;
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if ((Math.Abs(list[i].point.X - e.X)+(Math.Abs(list[i].point.Y - e.Y))<=20))
                    {
                        Flag = 0;
             //           MessageBox.Show("Count=" + Count.ToString());
                        if (list[i].check == false)
                        list[i].check = true;
                        else
                       list[i].check = false;
                        break;
                    }
                    else
                    {
                       Flag = 1;
                    }
                    
                }
                if (Flag == 1)
                {
                    p = new Vertex();
                    p.point.X = e.X;
                    p.point.Y = e.Y;
                    p.check = false;
                    Flag = 0;
                    list.Add(p);
                   
                   
                }
            }

            gr1 = this.CreateGraphics();
            for (int i =0;i<list.Count;i++)
            {
                if (list[i].check == false)
                {
                    gr1.FillEllipse(Brushes.White, list[i].point.X, list[i].point.Y, 10, 10);
                    gr1.DrawEllipse(Pens.Black, list[i].point.X, list[i].point.Y, 10, 10);
                }
                else
                {
                    if (FlagRibs == 0)
                    {
                        gr1.FillEllipse(Brushes.Red, list[i].point.X, list[i].point.Y, 10, 10);
                        FlagRibs = 1;
                        left = new Vertex();
                        left = list[i];
                        leftindex = i;
                      //  break;
                    }
                    else
                    {
                     
                            gr1.FillEllipse(Brushes.Red, list[i].point.X, list[i].point.Y, 10, 10);
                           

                            right = new Vertex();
                            right = list[i];
                            rightindex = i;
                           
                        }
                       
                   
                    }
                    
                }
           
                   
                
            }

        private void button1_Click(object sender, EventArgs e)
        {
            FlagRibs = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i].check == true)
                {
                    left = list[i];
                    leftindex = i;
                    for(int j=i+1;j<list.Count;j++)
                        if(list[j].check == true)
                        {
                            right = list[j];
                            rightindex = j;
                            FlagRibs = 1;
                            break;
                        }
                }
                if (FlagRibs == 1)
                {
                    gr1.DrawLine(Pens.Red, left.point, right.point);
                    list[leftindex].check = false;
                    list[rightindex].check= false;
                    gr1.FillEllipse(Brushes.White, list[rightindex].point.X, list[rightindex].point.Y, 10, 10);
                    gr1.DrawEllipse(Pens.Black, list[rightindex].point.X, list[rightindex].point.Y, 10, 10);
                    gr1.FillEllipse(Brushes.White, list[leftindex].point.X, list[leftindex].point.Y, 10, 10);
                    gr1.DrawEllipse(Pens.Black, list[leftindex].point.X, list[leftindex].point.Y, 10, 10);

                }
            }
        }
            
        }
    }

