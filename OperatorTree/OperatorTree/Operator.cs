using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorTree
{
    class Operator : Node
    {
        public Node Left { set; get; }
        public Node Right { set; get; }
        public string Desc { set; get; }
        public Operator(int x, int y, string desc) : base(x,y)
        {
            Desc = desc;
        }
       

        public override string GetDesc()
        {
            return Desc;
        }

        public override bool IsFree(int x, int y)
        {            
            return (x < X-SIZE || X+SIZE < x) && (y < Y - SIZE || Y + SIZE < y);
        }

        public override bool IsInNode(int x, int y)
        {
            return (X - SIZE < x && x < X + SIZE) && (Y - SIZE < y && y < Y + SIZE);
        }

        public override void Paint(Graphics g)
        {
            g.FillRectangle(Brushes.White, X - SIZE, Y - SIZE, SIZE * 2, SIZE * 2);
            g.DrawRectangle(Pens.Black, X - SIZE, Y - SIZE, SIZE * 2, SIZE * 2);

            SizeF dim = g.MeasureString(Desc, FONT);
            g.DrawString(Desc, FONT, Brushes.Black, X - dim.Width / 2, Y - dim.Height / 2);
        }

        public override bool AddConnection(Node n)
        {
            if(n.Y > Y)
            {
                if(Left == null && n.X < X)
                {
                    Left = n;
                    return true;
                } else if(Right == null && n.X > X)
                {
                    Right = n;
                    return true;
                }
            }
            return false;
        }
    }
}
