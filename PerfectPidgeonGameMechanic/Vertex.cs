using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PerfectPidgeonGameMechanic
{
    public class Vertex
    {
        public double X;
        public double Y;
        public double Z;
        public Vertex()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
        }
        public Vertex(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
            this.Z = 0;
        }
        public Vertex(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
        public Vertex(Vertex V)
        {
            if (V != null)
            {
                X = V.X;
                Y = V.Y;
                Z = V.Z;
            }
            else
            {
                X = 0;
                Y = 0;
                Z = 0;
            }
        }
        public Vertex Translate(Vertex A)
        {
            this.X += A.X;
            this.Y += A.Y;
            this.Z += A.Z;
            return this;
        }
        public Vertex Scale(Vertex A)
        {
            this.X *= A.X;
            this.Y *= A.Y;
            this.Z *= A.Z;
            return this;
        }
        public Point ToPoint()
        {
            return new Point((int)this.X, (int)this.Y);
        }
        public static double Distance(Vertex A, Vertex B)
        {
            return Math.Sqrt((A.X - B.X) * (A.X - B.X) +
                        (A.Y - B.Y) * (A.Y - B.Y));
        }
        public static Vertex Norm(double angle)
        {
            return new Vertex(Math.Cos((angle * 180) / Math.PI), Math.Sin((angle * 180) / Math.PI), 0);
        }
        public static Vertex Mid(Vertex A, Vertex B)
        {
            return (A + B) * 0.5;
        }
        public static double OnPath(int C1, int C2, double Val1, double Val2)
        {
            Val2 -= Val1;
            return Val1 + Val2 * C1 / C2;
        }
        public static Vertex operator +(Vertex a, Vertex b)
        {
            return new Vertex(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vertex operator -(Vertex a, Vertex b)
        {
            return new Vertex(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Vertex operator *(Vertex a, Vertex b)
        {
            return new Vertex(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        }
        public static Vertex operator *(Vertex a, double b)
        {
            return new Vertex(a.X * b, a.Y * b, a.Z * b);
        }
        public Vertex RotateZ(double A)
        {
            double OX = X;
            double OY = Y;
            Vertex V = new Vertex();
            V.X = (double)(Math.Cos((A / 180) * Math.PI) * OX - Math.Sin((A / 180) * Math.PI) * OY);
            V.Y = (double)(Math.Cos((A / 180) * Math.PI) * OY + Math.Sin((A / 180) * Math.PI) * OX);
            return V;
        }
    }
}
