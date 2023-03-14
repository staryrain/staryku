using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    internal class Rectangle
    {
        public double AB, CD, BC, AD;
        public double length, width;
        public double ABC;
        public Rectangle(double x, double y)
        {
            this.length = x; this.width = y;
            this.AB = this.CD = x;
            this.BC = this.AD = y;
            this.ABC = 90.0;
        }
        public double squire;
        public double Getsquire()
        {
            this.squire = this.length * this.width;
            return this.squire;
        }
        public bool JudgeisRec()
        {
            if (AB == 0 || CD == 0 || BC == 0 || AD == 0) return false;
            if (AB != CD || BC != AD) return false;
            if (ABC != 90.0) return false;
            return true;

        }
    }
    internal class Squire
    {
        double AB, CD, BC, AD;
        public double length;
        double ABC;
        public Squire(double x)
        {
            this.length = x; 
            this.AB = this.CD = this.BC = this.AD = x;
            this.ABC = 90.0;
        }
        double squire;
        public double Getsquire()
        {
            this.squire = this.length * this.length;
            return this.squire;
        }
        public bool JudgeisSqu()
        {
            if (AB ==0|| CD==0|| BC==0 ||AD==0) return false;
            if (AB != CD || BC != AD) return false;
            if(AB!=BC) return false;
            if (ABC != 90.0) return false;
            return true;
        }
    }
    internal class Triangle
    {
        public double AB, BC, AC;
       
       
        public Triangle(double x, double y,double z)
        {
            
            this.AB =  x;
            this.BC = y;
            this.AC = z;
        }
        double squire;
        public double Getsquire()
        {
            double p=(AB+BC+AC)/2;
            this.squire = Math.Sqrt(p*(p-AB)*(p-BC)*(p-AC));
            return this.squire;
        }
        public bool JudgeisTri()
        {
            if (AB >=(AC+BC) || AC>= (AB+BC) || BC >= (AB+AC)) return false;
            return true;
        }
       
    }
    class ShapeFactory
    {
        private Random rand = new Random();
        public double NArea(int n)
        {
            double Squire = 0;   //面积总和
            int count = 1; //形状总个数
            while (true)
            {
                int temp = rand.Next(3);
                switch (temp)
                {
                    case 0://创建三角形
                        Triangle triangle = new Triangle(rand.Next(100) + rand.NextDouble(), rand.Next(100) + rand.NextDouble(), rand.Next(100) + rand.NextDouble());
                        if (triangle.JudgeisTri())
                        {
                            Console.WriteLine("创建的第" + count + "个图形为一个三角形，三边为:" + triangle.AB + "、" + triangle.BC + "、" + triangle.AC);
                            count++;
                            Squire += triangle.Getsquire();
                        }
                        break;
                    case 1:
                        Rectangle rectangle = new Rectangle(rand.Next(100) + rand.NextDouble(), rand.Next(100) + rand.NextDouble());
                        if (rectangle.JudgeisRec())
                        {
                            Console.WriteLine("创建的第" + count + "个图形为一个长方形，两边为:" + rectangle.length + "、" + rectangle.width);
                            count++;
                            Squire += rectangle.Getsquire();
                        }
                        break;
                    case 2:

                        Squire square = new Squire(rand.Next(100) + rand.NextDouble());
                        if (square.JudgeisSqu())
                        {
                            Console.WriteLine("创建的第" + count + "个图形为一个正方形，边长为:" + square.length);
                            count++;
                            Squire += square.Getsquire();
                        }
                        break;
                    default:
                        throw new Exception("随机数生成失败！");
                }
                if (count == n + 1) break;
            }

            return Squire;
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            ShapeFactory shape = new ShapeFactory();
            string s = "";
            Console.Write("请输入创建图形的个数：");
            s = Console.ReadLine();
            int n = Int32.Parse(s);//创建图形个数
            Console.WriteLine("这" + n + "个图形的总面积为：" + shape.NArea(n));
            Console.ReadLine();

        }
    }

}
