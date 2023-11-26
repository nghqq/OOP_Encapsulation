﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    internal class Fraction
    {
        int denominator;

        public int Integer { get; set; } // Автосвойства. Их можно применять, когда фильтрация данных не требуется,
        // при этом переменная-член создаётся неявно компиляторе
        public int Numerator { get; set; }

        public int Denominator
        {
            get { return denominator; }
            set
            {
                if (value == 0) value =  1;
                denominator = value;
            }
        }

        // Constuctors:

        public Fraction(int integer=0,int numerator=0,int denominator= 1) 
        {
            Integer = integer;
            Numerator = numerator;
            Denominator = denominator;
            Console.WriteLine("Constructor:\t"+GetHashCode());
        }

        public Fraction()
        {
            Integer= 0;
            Numerator = 0;
            Denominator = 1;
            Console.WriteLine("DefConstructor:\t" + GetHashCode());
        }
        public Fraction(int integer)
        {
            Integer = integer;
            Numerator = 0;
            Denominator = 1;
            Console.WriteLine("SingleArgumentConstructor:\t" + GetHashCode());
        }
        public Fraction (int numerator,int denominator)
        {
            Integer = 0;
            Numerator = numerator;
            Denominator = denominator;
            Console.WriteLine("Constructor:\t" + GetHashCode());
        }
        public Fraction(Fraction other)
        {
            this.Integer = other.Integer;
            this.Numerator = other.Numerator;
            this.Denominator = other.Denominator;
            Console.WriteLine("CopyConstructor:\t" + GetHashCode());
        }
        ~Fraction()
        {
            Console.WriteLine("Destuctor:\t" + GetHashCode());
        }
        // Operators

        public static Fraction operator * (Fraction left_operand,Fraction right_operand)
        {
            Fraction left = new Fraction(left_operand);
            Fraction right = new Fraction(right_operand);
            left.ToImproper();
            right.ToImproper();
            return new Fraction(left.Numerator * right.Numerator, left.Denominator * right.Denominator).ToProper();
        }

        public static Fraction operator /(Fraction left,Fraction right)
        {
            return left * right.Inverted();
        }


        public static Fraction operator +(Fraction left_operand, Fraction right_operand)
        {
            Fraction left = new Fraction(left_operand);
            Fraction right = new Fraction(right_operand);
            int min_denominator = left.Denominator < right.Denominator ? left.Denominator : right.Denominator;
            int max_denominator = left.Denominator > right.Denominator ? left.Denominator : right.Denominator;
            int i = 0;
            do
                ++i;
            while (min_denominator * i % max_denominator != 0);
            return new Fraction
                (
                left.Integer + right.Integer,
                left.Numerator * ((min_denominator * i) / left.Denominator) + right.Numerator * ((min_denominator * i) / right.Denominator),
                min_denominator * i
                );
        }
        public static Fraction operator -(Fraction left_operand, Fraction right_operand)
        {
            Fraction left = new Fraction(left_operand);
            Fraction right = new Fraction(right_operand);
            int new_int = left.Integer - right.Integer;
            int min_denominator = left.Denominator < right.Denominator ? left.Denominator : right.Denominator;
            int max_denominator = left.Denominator > right.Denominator ? left.Denominator : right.Denominator;
            int i = 0;
            do
                ++i;
            while (min_denominator * i % max_denominator != 0);
            int new_number = 0;
            if (left.Numerator < right.Numerator)
            {
                new_number = left.Numerator * ((min_denominator * i) / left.Denominator) - right.Numerator * ((min_denominator * i) / right.Denominator);
            }
            else
            {
                new_int--;
                new_number = (min_denominator*i) + (left.Numerator * (min_denominator * i) / left.Denominator) - right.Numerator * ((min_denominator * i) / right.Denominator);
            }
            return new Fraction(new_int, new_number, min_denominator * i);
        }

        public static Fraction operator ++(Fraction fraction)
        {
            fraction.Integer++;
            if (fraction.Integer == 0) fraction.Integer = 1;
            return fraction;
        }
        public static Fraction operator --(Fraction fraction)
        {
            fraction.Integer--;
            if (fraction.Integer <= 0) fraction.Integer = 0;
            return fraction;
        }

        // Methods

        public Fraction ToProper() 
            {
           
            Integer = Numerator / Denominator;
            Numerator%=Denominator;
            return this;
            } 
        public void Print()
        {
            if (Integer != 0) Console.Write(Integer);
            if (Numerator != 0)
            {
                if(Integer != 0) Console.Write("(");
                Console.Write($"{Numerator}/{Denominator}");
                if (Integer != 0) Console.Write(")");
            }
            else if(Integer == 0) Console.Write(0);
            Console.WriteLine();
        }
        public Fraction ToImproper()
        {
           
            Numerator += Integer * Denominator;
            Integer = 0;
            return this;
        }
        public Fraction Inverted()
        {
            Fraction inverted = new Fraction(this);
            inverted.ToImproper();
            int buffer = inverted.Numerator;
            inverted.Numerator=  inverted.Denominator;
            inverted.Denominator = buffer;
            return inverted;
        }
    }

}
