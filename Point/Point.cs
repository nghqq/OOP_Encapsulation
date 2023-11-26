using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
    internal class Point
    {
        // const это статическая константа, которая обязательно должна быть приинициализированна при объявление
        // const поля автоматически являются статическими
        // readonly  нестатические поля только для чтения. Это константы которые существуют в объектах
        public static readonly int X_MAX;
        public static readonly int Y_MAX;
        double x, y;

        public  double GetX()
        {
            return x;
        }
        public double GetY()
        {
            return y;
        }
        public void SetX(double x)
        {
            if(x > X_MAX) x = X_MAX;
            if (x < 0) x = 0;
            this.x = x; 
        }
        public void SetY(double y)
        {
            if (y > Y_MAX) y = Y_MAX;
            if (y < 0) y = 0;
            this.y = y;
        }

        // Properties         Свойства 

        public double X
        {
            
            get { return x; }
            set 
            { 
                x = value;
                if (x > X_MAX) x = X_MAX;
                if (x < 0) x = 0;
            }
        }
        public double Y
        {
            get { return y; }
            set
            {
                y = value;
                if (y > Y_MAX) y = Y_MAX;
                if (y < 0) y = 0;
            }
        }

        // Constuctors

        static Point()
        {
            X_MAX = 1366;
            Y_MAX = 768;
        }
        public Point(double x = 0, double y = 0)
        {
            X= x;  // Маленькая буква это принимаемые параметры, а большная буква это свойства 
            Y= y;
            Console.WriteLine("Constuctor: \t"+ GetHashCode());
        }

        public Point(Point other)
        {
            this.x = other.x;
            this.y = other.y;
            Console.WriteLine("CopyConstuctor: \t" + GetHashCode());
        }

         ~Point()   // Деструктор. Только приватный.
        {
            Console.WriteLine("Finalizer: \t"+GetHashCode());
        }

        // Operators

        public static Point operator+(Point A,Point B)
        {
            return new Point(A.x + B.x, A.y + B.y);
        }
        public static Point operator-(Point A,Point B)
            => new Point(A.x - B.x, A.y - B.y);
        
        public static Point operator ++(Point point)
        {
            point.x++;
            point.y++;
            return point;
        }


        // Methods 

         public void Print()
        {
            Console.WriteLine($"X = {x}, \tY = {y}");
        }

        public double Distance(Point point)
        {

            return Math.Sqrt(Math.Pow(point.x - x, 2) + Math.Pow(point.y - y, 2));
        }
    }
}
