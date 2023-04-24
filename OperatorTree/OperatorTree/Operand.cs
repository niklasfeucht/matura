using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorTree
{
    class Operand : Node
    {
        public int Value { set; get; }
        public Operand(int x, int y, int value) : base(x,y)
        {
            Value = value;
        }
        
        public override string GetDesc()
        {
            return Value + "";
        }

        public override bool IsFree(int x, int y)
        {
            int dx = X - x;
            int dy = Y - y;
            int dist = (int)Math.Sqrt(dx * dx + dy * dy);
            return dist > SIZE * 2;
        }

        public override bool IsInNode(int x, int y)
        {
            int dx = X - x;
            int dy = Y - y;
            int dist = (int)Math.Sqrt(dx * dx + dy * dy);
            return dist < SIZE;
        }

        public override void Paint(Graphics g)
        {
            g.FillEllipse(Brushes.White, X - SIZE, Y - SIZE, SIZE * 2, SIZE * 2);
            g.DrawEllipse(Pens.Black, X - SIZE, Y - SIZE, SIZE * 2, SIZE * 2);

            SizeF dim = g.MeasureString(Value + "", FONT);
            g.DrawString(Value + "", FONT, Brushes.Black, X - dim.Width / 2, Y - dim.Height / 2);
        }

        public override bool AddConnection(Node n)
        {
            return false;
        }
    }
}
