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
    static class Helper
    {
        public static void createLabel(Label lbl, Point position, Form1 form)
        {
            lbl.Text = "1";
            lbl.AutoSize = true;
            lbl.Location = new Point(position.X, position.Y);
            form.Controls.Add(lbl);
            lbl.BringToFront();
        }

        public static Node findNodeByIndex(Label index, List<Node> nodes)
        {
            foreach (Node node in nodes)
                if (node.index == index)
                    return node;
            return null;
        }

        public static Line findLineByIndex(Label index, List<Line> lines)
        {
            foreach (Line line in lines)
                if (line.index == index)
                    return line;
            return null;
        }

        public static void deleteNode(Node n, List<Line> lns, Graphics g, Pen p, List<Node> nds)
        {
            g.DrawRectangle(p, n.rect);
            n.index.Dispose();
            n.value.Dispose();
            nds.Remove(n);
            foreach (Line ln in lns.ToList())
                if (ln.node1 == n || ln.node2 == n)
                {
                    g.DrawLine(p, ln.node1.rect.Location, ln.node2.rect.Location);
                    ln.index.Dispose();
                    ln.value.Dispose();
                    lns.Remove(ln);
                }
        }

        public static void createLine(Node n1, Node n2, List<Line> lns, Graphics g, Pen p, Form1 form)
        {
            Line ln = new Line();
            ln.node1 = n1;
            ln.node2 = n2;
            g.DrawLine(p, n1.rect.Location, n2.rect.Location);

            ln.index = new Label();
            ln.value = new Label();
            Point labelPosition = new Point((n1.rect.Location.X + n2.rect.Location.X) / 2, (n1.rect.Location.Y + n2.rect.Location.Y) /2);
            createLabel(ln.index, labelPosition, form);
            labelPosition.Y += 25;
            createLabel(ln.value, labelPosition, form);

            lns.Add(ln);
        }
        public static void deleteLine(Line ln, List<Line> lns, Graphics g, Pen wp, Pen bp)
        {
            g.DrawLine(wp, ln.node1.rect.Location, ln.node2.rect.Location);
            g.DrawRectangle(bp, ln.node1.rect);
            g.DrawRectangle(bp, ln.node2.rect);
            ln.index.Dispose();
            ln.value.Dispose();
            lns.Remove(ln);
        }
        public static void moveNode(List<Line> lns, Node n, Graphics g, Pen wp, Pen bp, Point poz)
        {
            g.DrawRectangle(wp, n.rect);
            foreach (Line ln in lns)
                if (ln.node1 == n || ln.node2 == n)
                    g.DrawLine(wp, ln.node1.rect.Location, ln.node2.rect.Location);
            n.rect.Location = poz;
            g.DrawRectangle(bp, n.rect);

            Point labelPosition = n.rect.Location;
            labelPosition.X += 16;
            labelPosition.Y += 15;
            n.index.Location = labelPosition;
            labelPosition.Y += 20;
            n.value.Location = labelPosition;
            foreach (Line ln in lns)
                if (ln.node1 == n || ln.node2 == n)
                {
                    labelPosition = new Point((ln.node1.rect.Location.X + ln.node2.rect.Location.X) / 2, (ln.node1.rect.Location.Y + ln.node2.rect.Location.Y) / 2);
                    ln.index.Location = labelPosition;
                    labelPosition.Y += 25;
                    ln.value.Location = labelPosition;
                    g.DrawLine(bp, ln.node1.rect.Location, ln.node2.rect.Location);
                }

        }
        public static void moveLine(Line ln, Node oldNode, Node destinationNode, Graphics g, Pen wp, Pen bp)
        {
            g.DrawLine(wp, ln.node1.rect.Location, ln.node2.rect.Location);
            g.DrawRectangle(bp, oldNode.rect);
            if (ln.node1 == oldNode)
                ln.node1 = destinationNode;
            else
                ln.node2 = destinationNode;
            Point labelPosition = new Point((ln.node1.rect.Location.X + ln.node2.rect.Location.X) / 2, (ln.node1.rect.Location.Y + ln.node2.rect.Location.Y) / 2);
            ln.index.Location = labelPosition;
            labelPosition.Y += 25;
            ln.value.Location = labelPosition;
            g.DrawLine(bp, ln.node1.rect.Location, ln.node2.rect.Location);
        }
    }

    class Line
    {
        public Node node1, node2;
        public Label index, value;
    };

    class Node
    {
        public Rectangle rect;
        public Label index, value;
    }

    public partial class Form1 : Form
    {
        List<Node> Nodes = new List<Node>();
        List<Line> Lines = new List<Line>();
        Pen blackPen = new Pen(Color.Black);
        Pen whitePen = new Pen(Color.White);
        Node selectedNode;
        Line selectedLine;
        Graphics g;

        bool isAddNodePushed = false;
        bool isEditNodePushed = false;
        bool isDeleteNodePushed = false;
        bool isAddLinePushed = false;
        bool isNodeSelected = false;
        bool isLineSelected = false;
        bool isEditLinePushed = false;
        bool isDeleteLinePushed = false;
        bool isMoveNodePushed = false;
        bool isMoveLinePushed = false;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void disableAllButtons()
        {
            isAddNodePushed = false;
            isEditNodePushed = false;
            isDeleteNodePushed = false;
            isAddLinePushed = false;
            isEditLinePushed = false;
            isDeleteLinePushed = false;
            isMoveNodePushed = false;
            isNodeSelected = false;
            isMoveLinePushed = false;
            isLineSelected = false;
        }

        private void addNodeButton_Click(object sender, EventArgs e)
        {
            disableAllButtons();
            isAddNodePushed = true;
        }

        private void moveLineButton_Click(object sender, EventArgs e)
        {
            disableAllButtons();
            isMoveLinePushed = true;
        }

        private void editNodeButton_Click(object sender, EventArgs e)
        {
            disableAllButtons();
            isEditNodePushed = true;
        }

        private void deleteNodeButton_Click(object sender, EventArgs e)
        {
            disableAllButtons();
            isDeleteNodePushed = true;
        }

        private void addLineButton_Click(object sender, EventArgs e)
        {
            disableAllButtons();
            isAddLinePushed = true;
        }

        private void deleteLineButton_Click(object sender, EventArgs e)
        {
            disableAllButtons();
            isDeleteLinePushed = true;
        }

        private void moveNodeButton_Click(object sender, EventArgs e)
        {
            disableAllButtons();
            isMoveNodePushed = true;
        }

        private void editLineButton_Click(object sender, EventArgs e)
        {
            disableAllButtons();
            isEditLinePushed = true;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Point clickPosition = panel1.PointToClient(Cursor.Position);

            if (isAddNodePushed)
            {
                Node node = new Node();
                node.rect = new Rectangle(clickPosition.X, clickPosition.Y, 40, 40);
                g.DrawRectangle(blackPen, node.rect);

                Label index = new Label();
                Label value = new Label();

                Point lblPos = clickPosition;
                lblPos.X += 16;
                lblPos.Y += 15;
                Helper.createLabel(index, lblPos, this);
                lblPos.Y += 20;
                Helper.createLabel(value, lblPos, this);

                index.Click += delegate
                {
                    if (isEditNodePushed && textBox1.Text != "")
                    {
                        index.Text = textBox1.Text;
                        isEditNodePushed = false;
                    }
                    if (isMoveLinePushed && isLineSelected && !isNodeSelected)
                    {
                        selectedNode = Helper.findNodeByIndex(index, Nodes);
                        if(selectedNode == selectedLine.node1 || selectedNode == selectedLine.node2)
                            isNodeSelected = true;
                    }

                    if (isMoveLinePushed && isLineSelected && isNodeSelected)
                    {
                        Node destinationNode = Helper.findNodeByIndex(index, Nodes);
                        if (destinationNode != selectedLine.node1 && destinationNode != selectedLine.node2)
                        {
                            Helper.moveLine(selectedLine, selectedNode, destinationNode, g, whitePen, blackPen);
                            isMoveLinePushed = false;
                            isLineSelected = false;
                            isNodeSelected = false;
                        }
                    }

                    if (isAddLinePushed && isNodeSelected)
                    {
                        Node selectedNode2 = Helper.findNodeByIndex(index, Nodes);
                        bool ok = true;
                        foreach (Line ln in Lines)
                        {
                            if ((ln.node1 == selectedNode && ln.node2 == selectedNode2) || (ln.node1 == selectedNode2 && ln.node2 == selectedNode))
                                ok = false;
                        }

                        if (selectedNode == selectedNode2)
                            ok = false;

                        if (ok)
                        { 
                            Helper.createLine(selectedNode, selectedNode2, Lines, g, blackPen, this);
                            Line addedLine = Lines.Last();
                            addedLine.index.Click += delegate
                            {
                                if (isEditLinePushed && textBox1.Text != "")
                                { 
                                    addedLine.index.Text = textBox1.Text;
                                    isEditLinePushed = false;
                                }
                                if (isDeleteLinePushed)
                                {
                                    Helper.deleteLine(addedLine, Lines, g, whitePen, blackPen);
                                    isDeleteLinePushed = false;
                                }
                                if (isMoveLinePushed && !isLineSelected)
                                {
                                    isLineSelected = true;
                                    selectedLine = Helper.findLineByIndex(addedLine.index, Lines);
                                }
                            };

                            addedLine.value.Click += delegate
                            {
                                if (isEditLinePushed && textBox1.Text != "")
                                {
                                    addedLine.value.Text = textBox1.Text;
                                    isEditLinePushed = false;
                                }
                            };

                            isAddLinePushed = false;
                            isNodeSelected = false;
                        }
                    }

                    if (isMoveNodePushed && !isNodeSelected)
                    {
                        selectedNode = Helper.findNodeByIndex(index, Nodes);
                        isNodeSelected = true;
                    }

                    if (isAddLinePushed && !isNodeSelected)
                    {
                        isNodeSelected = true;
                        selectedNode = Helper.findNodeByIndex(index, Nodes);
                    }
                    if (isDeleteNodePushed)
                    {
                        Node n = Helper.findNodeByIndex(index, Nodes);
                        Helper.deleteNode(n, Lines, g, whitePen, Nodes);
                        isDeleteNodePushed = false;
                    }

                };
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
            }
            if (isMoveNodePushed && isNodeSelected)
            {
                Helper.moveNode(Lines, selectedNode, g, whitePen, blackPen, clickPosition);
                isMoveNodePushed = false;
                isNodeSelected = false;
            }
            isAddNodePushed = false;
        }
    }
}
