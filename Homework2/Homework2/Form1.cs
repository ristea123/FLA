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

    class Line : ICloneable
    {
        public Point p1, p2;

        public Line Clone() { return (Line)this.MemberwiseClone(); }
        object ICloneable.Clone() { return Clone(); }

        public Label index, value;

        public bool Equals(Line obj)
        {
            if (obj.p1 == this.p1 && obj.p2 == this.p2)
            {
                return true;
            }
            return false;
        }

    };

    class Node
    {
        public Rectangle rect;
        public List<Line> vertices;
        public Label index, value;
    }


    public partial class Form1 : Form
    {
        List<Node> Nodes = new List<Node>();
        Pen blackPen = new Pen(Color.Black);
        Pen whitePen = new Pen(Color.White);
        Graphics g;

        Point lineStart;
        int selectedRectPos;

        bool isAddNodePushed = false;
        bool isEditNodePushed = false;
        bool isDeleteNodePushed = false;
        bool isAddLinePushed = false;
        bool isRectSelected = false;
        bool isEditLinePushed = false;
        bool isDeleteLinePushed = false;
        bool isMoveNodePushed = false;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void addNodeButton_Click(object sender, EventArgs e)
        {
            isAddNodePushed = true;
        }

        private void editNodeButton_Click(object sender, EventArgs e)
        {
            isEditNodePushed = true;
        }

        private void deleteNodeButton_Click(object sender, EventArgs e)
        {
            isDeleteNodePushed = true;
        }

        private void addLineButton_Click(object sender, EventArgs e)
        {
            isAddLinePushed = true;
        }

        private void deleteLineButton_Click(object sender, EventArgs e)
        {
            isDeleteLinePushed = true;
        }

        private void moveNodeButton_Click(object sender, EventArgs e)
        {
            isMoveNodePushed = true;
        }

        private void editLineButton_Click(object sender, EventArgs e)
        {
            isEditLinePushed = true;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Point position = panel1.PointToClient(Cursor.Position);

            if (isAddNodePushed)
            {
                Node node = new Node();
                node.rect = new Rectangle(position.X, position.Y, 40, 40);
                node.vertices = new List<Line>();

                Label index = new Label();
                index.Text = "1";
                index.AutoSize = true;
                index.ForeColor = Color.Red;
                index.Location = new Point(position.X + 16, position.Y + 15);
                this.Controls.Add(index);
                index.BringToFront();

                index.Click += delegate
                {
                    if (isEditNodePushed && textBox1.Text != "")
                    {
                        index.Text = textBox1.Text;
                        isEditNodePushed = false;
                    }
                    if (isDeleteNodePushed)
                    {
                        for (int i = 0; i < Nodes.Count(); i++)
                            if (Nodes[i].index == index)
                            {
                                g.DrawRectangle(whitePen, Nodes[i].rect);
                                Nodes[i].index.Dispose();
                                Nodes[i].value.Dispose();
                                for (int j = 0; j < Nodes[i].vertices.Count(); j++)
                                {
                                    g.DrawLine(whitePen, Nodes[i].vertices[j].p1, Nodes[i].vertices[j].p2);
                                    Nodes[i].vertices[j].index.Dispose();
                                    Nodes[i].vertices[j].value.Dispose();
                                }
                                Nodes.Remove(Nodes[i]);
                            }
                        isDeleteNodePushed = false;
                    }

                    if (isMoveNodePushed && !isRectSelected)
                    {
                        isRectSelected = true;
                        for (int i = 0; i < Nodes.Count(); i++)
                            if (Nodes[i].index == index)
                                selectedRectPos = i;
                    }

                    if (isAddLinePushed && isRectSelected)
                    {
                        Line line = new Line();
                        line.p1 = lineStart;
                        for (int i = 0; i < Nodes.Count(); i++)
                            if (Nodes[i].index == index)
                            {
                                line.p2 = Nodes[i].rect.Location;
                                Point tmp1 = line.p1;
                                line.p1 = line.p2;
                                line.p2 = tmp1;
                                Label lineIndex = new Label();
                                lineIndex.Text = "1";
                                lineIndex.AutoSize = true;
                                lineIndex.ForeColor = Color.Red;
                                lineIndex.Location = new Point((line.p1.X  + line.p2.X)/2, (line.p1.Y + line.p2.Y)/2);
                                this.Controls.Add(lineIndex);
                                lineIndex.BringToFront();
                                lineIndex.Click += delegate
                                {
                                    if (isEditLinePushed && textBox1.Text != "")
                                    {
                                        lineIndex.Text = textBox1.Text;
                                        isEditLinePushed = false;
                                    }
                                    if (isDeleteLinePushed)
                                    {
                                        for (int j = 0; j < Nodes.Count; j++)
                                            for (int k = 0; k < Nodes[j].vertices.Count(); k++)
                                                if (lineIndex == Nodes[j].vertices[k].index)
                                                {
                                                    Nodes[j].vertices[k].index.Dispose();
                                                    Nodes[j].vertices[k].value.Dispose();
                                                    g.DrawLine(whitePen, Nodes[j].vertices[k].p1, Nodes[j].vertices[k].p2);
                                                    Nodes[j].vertices.RemoveAt(k);
                                                }
                                    }
                                };

                                Label lineValue = new Label();
                                lineValue.Text = "1";
                                lineValue.AutoSize = true;
                                lineValue.ForeColor = Color.Red;
                                lineValue.Location = new Point((line.p1.X + line.p2.X) / 2, (line.p1.Y + line.p2.Y) / 2 + 25);
                                this.Controls.Add(lineValue);
                                lineValue.BringToFront();

                                lineValue.Click += delegate
                                {
                                    if (isEditLinePushed && textBox1.Text != "")
                                    {
                                        lineValue.Text = textBox1.Text;
                                        isEditLinePushed = false;
                                    }
                                };

                                line.index = lineIndex;
                                line.value = lineValue;
                                Nodes[i].vertices.Add(line);
                                g.DrawLine(blackPen, line.p1, line.p2);
                                break;
                            }

                        Line line2 = (Line)line.Clone();

                        Point tmp = line2.p1;
                        line2.p1 = line2.p2;
                        line2.p2 = tmp;

                        Nodes[selectedRectPos].vertices.Add(line2);
                        isAddLinePushed = false;
                        isRectSelected = false;
                    }

                    if(isAddLinePushed && !isRectSelected)
                    {
                        isRectSelected = true;
                        for (int i = 0; i < Nodes.Count(); i++)
                            if (Nodes[i].index == index)
                            {
                                lineStart = Nodes[i].rect.Location;
                                selectedRectPos = i;
                                break;
                            }

                    }
                };



                Label value = new Label();
                value.Text = "1";
                value.AutoSize = true;
                value.ForeColor = Color.Red;
                value.Location = new Point(position.X + 16, position.Y + 35);
                this.Controls.Add(value);
                value.BringToFront();

                value.Click += delegate
                {
                    if (isEditNodePushed && textBox1.Text != "")
                    {
                        value.Text = textBox1.Text;
                        isEditNodePushed = false;
                    }
                };

                node.index = index;
                node.value = value;
                Nodes.Add(node);
                g.DrawRectangle(blackPen, node.rect);

                isAddNodePushed = false;
            }
            if (isMoveNodePushed && isRectSelected)
            {

                g.DrawRectangle(whitePen, Nodes[selectedRectPos].rect);
                int distX = Nodes[selectedRectPos].rect.X - position.X;
                int distY = Nodes[selectedRectPos].rect.Y - position.Y;
                Nodes[selectedRectPos].rect.X -= distX;
                Nodes[selectedRectPos].rect.Y -= distY;
                g.DrawRectangle(blackPen, Nodes[selectedRectPos].rect);

                Point newPoint = new Point(Nodes[selectedRectPos].index.Location.X - distX, Nodes[selectedRectPos].index.Location.Y - distY);
                Nodes[selectedRectPos].index.Location = newPoint;
                newPoint = new Point(Nodes[selectedRectPos].value.Location.X - distX, Nodes[selectedRectPos].value.Location.Y - distY);
                Nodes[selectedRectPos].value.Location = newPoint;

                for (int i = 0; i < Nodes[selectedRectPos].vertices.Count(); i++)
                {
                    bool found = false;
                    int j = 0, k = 0;
                    for (j = 0; j < Nodes.Count(); j++)
                    {
                        if (j != selectedRectPos)
                            for (k = 0; k < Nodes[j].vertices.Count(); k++)
                            {
                                if (Nodes[j].vertices[k].index == Nodes[selectedRectPos].vertices[i].index)
                                {
                                    found = true;
                                    break;
                                }

                            }
                        if (found == true)
                            break;
                    }
                    g.DrawLine(whitePen, Nodes[selectedRectPos].vertices[i].p1, Nodes[selectedRectPos].vertices[i].p2);
                    newPoint = new Point(Nodes[selectedRectPos].vertices[i].p1.X - distX, Nodes[selectedRectPos].vertices[i].p1.Y - distY);
                    Nodes[selectedRectPos].vertices[i].p1 = newPoint;
                    Nodes[j].vertices[k].p2 = newPoint;
                    g.DrawLine(blackPen, Nodes[selectedRectPos].vertices[i].p1, Nodes[selectedRectPos].vertices[i].p2);
                    newPoint = new Point((Nodes[selectedRectPos].vertices[i].p1.X + Nodes[selectedRectPos].vertices[i].p2.X) / 2, (Nodes[selectedRectPos].vertices[i].p1.Y + Nodes[selectedRectPos].vertices[i].p2.Y) / 2);
                    Nodes[selectedRectPos].vertices[i].index.Location = newPoint;
                    Nodes[j].vertices[k].index.Location = newPoint;
                    newPoint = new Point((Nodes[selectedRectPos].vertices[i].p1.X + Nodes[selectedRectPos].vertices[i].p2.X) / 2, (Nodes[selectedRectPos].vertices[i].p1.Y + Nodes[selectedRectPos].vertices[i].p2.Y) / 2 + 25);
                    Nodes[selectedRectPos].vertices[i].value.Location = newPoint;
                    Nodes[j].vertices[k].value.Location = newPoint;
                }
                isMoveNodePushed = false;
                isRectSelected = false;
            }
        }

    }
}
