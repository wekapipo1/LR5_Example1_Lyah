using System;
using System.Globalization;

abstract class Figure
{
    //обчислення площі
    public abstract double Square();
    //обчислення довжини межі
    public abstract double Border();
    //перевірка існування
    public abstract bool Exists();
    //поля об'єкту
    public abstract string Str();
}
class Triangle : Figure
{
    double a, b, c;
    public Triangle(double a, double b, double c)
    {
        this.a = a; this.b = b; this.c = c;
    }
    public override double Square()
    {
        double p =(a+b+c)/2;
        return Math.Sqrt(p*(p-a)*(p-b)*(p-c));
    }
    public override double Border()
    {
        return a + b + c;
    }
    public override string Str()
    {
        return "трикутник:" + " сторони " +a+" "+b+" " +c; 
    }
    public override bool Exists()
    {
        bool p = true;
        if ((a>=b+c)||(b>=a+c)||(c>=a+b)) p=false;
        return p;
    }
}
class Circle : Figure
{
    double r;
    public Circle(double r)
    {
        this.r = r;
    }
    public override bool Exists()
    {
        bool p = true;
        if (r==0) p =false;
        return p;
    }
    public override double Square()
    {
        return r * r * Math.PI;
    }
    public override double Border()
    {
        return 2 * r * Math.PI;
    }
    public override string Str()
    {
        return "коло: радiус " + r;
    }    
}
class Program
{
    static void Main(string[] args)
    {
        //описуємо змінну абстрактного класу
        Figure f;
        Random o = new Random();
        double p = 0, s = 0; string st = ""; bool e = true;
        for (int i=1; i<=5; i++)
        {
            int t = o.Next(0, 2); int x = o.Next(0, 9);
            int y = o.Next(0,9); int z = o.Next(0,9);
            //випадково створюємо об'єкт одного з дочірніх класів
            if (t == 0)
            {
                f = new Circle(x); st = "коло ";
            }
            else
            {
                f=new Triangle(x,y,z); st = "трикутник";
            }
            //виведення значень полів об'єкта
            Console.WriteLine(f.Str());
            //перевірка існування об'єкта
            e = f.Exists();
            if (e)
            {
                //для створеного об'єкта f викликаємо методи Border i Square
                // з того класу до якого відноситься об'єкт
                p=f.Border(); s=f.Square();
                Console.WriteLine("Довжина межi = {0:F2}, площа = {1:F2} \n -----", p,s);
            }
            else
            {
                Console.WriteLine("{0} не iснує \n -----", st);
            }
        }
        Console.ReadKey();
    }
}