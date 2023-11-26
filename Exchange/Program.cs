﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a , b;
            Input(out a,  out b);
            Console.WriteLine($"{a}\t{b}");
            Exchange(ref a, ref b);
            Console.WriteLine($"{a}\t{b}");

        }
        static void Input(out int a, out int b)
        {
            Console.Write("Введите два числа: ");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
        }
        static void Exchange(ref int a,ref int b) 
        {
            int buffer = a;
            a = b;
            b = buffer;
        }
    }
}
