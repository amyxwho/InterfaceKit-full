using System;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace InterfaceKit_full
{
    class Shape
    {
        private Point pnt;
        private Pen drawPen = new Pen(Color.Black);
        private SolidBrush fillBrush;
        private LinearGradientBrush gradBrush;
        private Rectangle rect;
        private Graphics g;
        private ShapeType type;

        enum ShapeType
        {
            rectangle,
            ellipse
        }

        public Shape(string shapeType, Color c, Point pntXY, Graphics inputG)
        {
            pnt = pntXY;
            makeShapeType(shapeType.ToLower(), pntXY);
            fillBrush=new SolidBrush(c);
            gradBrush=new LinearGradientBrush(rect,c,c,0,true);
            g = inputG;

        }

        private void makeShapeType(string s, Point p)
        {
            switch (s)
            {
                case "rectangle":
                    type = ShapeType.rectangle;
                    rect = new Rectangle(new Point(1, 1), new Size(p));
                    break;
                case "ellipse":
                    type = ShapeType.ellipse;
                    rect = new Rectangle(new Point(1, 1), new Size(p));
                    break;
                default:
                    type = ShapeType.rectangle;
                    rect = new Rectangle(new Point(1, 1), new Size(p));
                    break;
            }
        }

        public void changePosition(Point p)
        {
            rect.Location = p;
        }

        public void changeSize(Point s)
        {
            rect.Size = (Size)s;
        }

        public void changeColor(Color c)
        {
            fillBrush = new SolidBrush(c);
        }
        public void changeColorGrad(Color b, Color c)
        {
            gradBrush = new LinearGradientBrush(rect,b,c, 1, true);
        }
        public void Draw(String s)
        {

            switch (type)
            {
                case ShapeType.rectangle:
                    if(s.Equals("gradient"))
                        g.FillRectangle(gradBrush,rect);
                    else
                        g.FillRectangle(fillBrush,rect);
                    g.DrawRectangle(drawPen,rect);
                    break;
                case ShapeType.ellipse:
                    if(s.Equals("gradient"))
                        g.FillEllipse(gradBrush,rect);
                    else
                        g.FillEllipse(fillBrush,rect);
                    g.DrawEllipse(drawPen,rect);
                    break;

            }
        }

    }
}
