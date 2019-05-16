using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework2
{

    struct Line
    {
        public Point p1, p2;

        public bool Equals(Line obj)
        {
            if (obj.p1 == this.p1 && obj.p2 == this.p2)
            {
                return true;
            }
            return false;
        }

    };

    struct Node
    {
        public Rectangle rect;
        public List<Line> vertices;
        public Node(Rectangle r)
        {
            vertices = new List<Line>();
            rect = r;
        }
    }


    public partial class Form1 : Form
    {
        public bool isDrawNodePushed;
        public bool isEditNodePushed;
        public bool isDeleteNodePushed;
        public bool isAddLinePushed;
        public bool isStartAdded;
        public bool isEditLinePushed;
        public bool isDeleteLinePushed;
        public Point lineStart, lineEnd;
        Dictionary<Label, Rectangle> map = new Dictionary<Label, Rectangle>();
        Dictionary<Line, Label> map2 = new Dictionary<Line, Label>();
        Rectangle r1, r2;
        List<Node> Nodes = new List<Node>();

        public Form1()
        {
            InitializeComponent();
            isDrawNodePushed = false;
            isEditNodePushed = false;
            isDeleteNodePushed = false;
            isAddLinePushed = false;
            isEditLinePushed = false;
            isDeleteLinePushed = false;
            isStartAdded = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isDrawNodePushed = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isEditNodePushed = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isDeleteNodePushed = true ;   
        }

        private void button5_Click(object sender, EventArgs e)
        {
            isEditLinePushed = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            isDeleteLinePushed = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            isAddLinePushed = true;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Point point = panel1.PointToClient(Cursor.Position);
            if (isDrawNodePushed)
            {
                Pen sb = new Pen(Color.Black);
                Pen sw = new Pen(Color.White);
                Graphics g = panel1.CreateGraphics();
                Rectangle rect = new Rectangle(point.X, point.Y, 40, 40);
                Nodes.Add(new Node(rect));
                g.DrawRectangle(sb, rect);

                Label lbl = new Label();
                lbl.Text = "1";
                lbl.AutoSize = true;
                lbl.ForeColor = Color.Red;
                lbl.Location = new Point(point.X + 16, point.Y + 25);
                this.Controls.Add(lbl);
                lbl.BringToFront();
                map.Add(lbl, rect);
                lbl.Click += delegate
                {
                    if (isEditNodePushed && textBox1.Text != "")
                    {
                        lbl.Text = textBox1.Text;
                        isEditNodePushed = false;
                    }

                    if (isDeleteNodePushed)
                    {
                        g.DrawRectangle(sw, map[lbl]);
                        foreach (Node node in Nodes)
                        {
                            if (node.rect == map[lbl])
                            {
                                foreach (Line line in node.vertices)
                                {
                                    g.DrawLine(sw, line.p1, line.p2);
                                    map2[line].Dispose();
                                }
                            }
                        }
                        map.Remove(lbl);
                        lbl.Dispose();
                        isDeleteNodePushed = false;
                    }

                    if (isAddLinePushed && isStartAdded)
                    {
                        lineEnd.X = point.X;
                        lineEnd.Y = point.Y;
                        r2 = map[lbl];
                        Line l1 = new Line();

                        l1.p1.X = lineStart.X;
                        l1.p1.Y = lineStart.Y;
                        l1.p2.X = lineEnd.X;
                        l1.p2.Y = lineEnd.Y;
                        foreach (Node node in Nodes)
                        {
                            if (node.rect == r1)
                            {
                                node.vertices.Add(l1);
                                Label lbl2 = new Label();
                                lbl2.Text = "1";
                                lbl2.AutoSize = true;
                                lbl2.ForeColor = Color.Red;
                                lbl2.Location = new Point((l1.p1.X + l1.p2.X)/2, (l1.p1.Y + l1.p2.Y)/2);
                                this.Controls.Add(lbl2);
                                lbl2.BringToFront();
                                map2.Add(node.vertices.LastOrDefault(), lbl2);
                                lbl2.Click += delegate
                                {
                                    if (isEditLinePushed)
                                        lbl2.Text = textBox1.Text;
                                    if (isDeleteLinePushed)
                                    {
                                        foreach (KeyValuePair<Line, Label> pair in map2)
                                            if (pair.Value == lbl2)
                                            {
                                                g.DrawLine(sw, pair.Key.p1, pair.Key.p2);
                                                foreach (Node node2 in Nodes)
                                                {
                                                    foreach (Line line in node2.vertices)
                                                        if (line.Equals(pair.Key))
                                                        {
                                                            node2.vertices.Remove(line);
                                                            break;
                                                        }
                                                }

                                            }
                                        lbl2.Dispose();
                                    }
                                };
                            }
                            if (node.rect == r2)
                                node.vertices.Add(l1);
                        }

                        g.DrawLine(sb, lineStart, lineEnd);
                        isAddLinePushed = false;
                        isStartAdded = false;
                    }

                    if (isAddLinePushed && !isStartAdded)
                    {
                        lineStart.X = point.X;
                        lineStart.Y = point.Y;
                        isStartAdded = true;
                        r1 = map[lbl];
                    }
                };

                isDrawNodePushed = false;
            }
        }

    }
}
