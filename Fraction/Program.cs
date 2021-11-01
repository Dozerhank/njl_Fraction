using System;
class Fraction
{
    private int whole;
    private int numerator;
    private int denominator;

    public Fraction()
    {
        this.whole = 0;
        this.numerator = 0;
        this.denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        this.whole = 0;
        this.numerator = numerator;
        this.denominator = denominator;
    }

    public Fraction(int whole, int numerator, int denominator)
    {
        this.whole = whole;
        this.numerator = numerator;
        this.denominator = denominator;
    }

    int gcd(int a, int b)
    {
        if (b == 0)
            return a;
        return gcd(b, a % b);
    }

    public void Reduce()
    {
        int tempGCD = gcd(this.numerator, this.denominator);
        this.whole += this.numerator / this.denominator;             
        this.numerator = this.numerator % this.denominator;
        this.numerator /= tempGCD;
        this.denominator /= tempGCD;
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        Fraction c = new Fraction();
        if (b.denominator == 1)
        {
            b.whole += b.numerator;
            b.numerator = 0;
            b.denominator = 1;
        }
        else if (a.denominator == 1)
        {
            a.whole += a.numerator;
            a.numerator = 0;
            a.denominator = 1;
        }

        c.whole = a.whole + b.whole;
        c.denominator = c.gcd(a.denominator, b.denominator);
        c.denominator = (a.denominator * b.denominator) / c.denominator;
        c.numerator = (a.numerator) * (c.denominator / a.denominator) + b.numerator * (c.denominator / b.denominator);
        c.Reduce();

        return c;
    }

    public static Fraction operator -(Fraction a, Fraction b)
    {
        Fraction c = new Fraction();
        if (b.denominator == 1)
        {
            b.whole += b.numerator;
            b.numerator = 0;
            b.denominator = 1;
        }   
        else if (a.denominator == 1)
        {
            a.whole += a.numerator;
            a.numerator = 0;
            a.denominator = 1;
        }

        c.whole = a.whole - b.whole;
        c.denominator = c.gcd(a.denominator, b.denominator);
        c.denominator = (a.denominator * b.denominator) / c.denominator;
        c.numerator = (a.numerator) * (c.denominator / a.denominator) - b.numerator * (c.denominator / b.denominator);
        c.Reduce();

        return c;
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        Fraction c = new Fraction();
        if (a.whole != 0)
        {
            a.numerator += a.whole * a.denominator;
            a.whole = 0;
        }  
        else if (b.whole != 0)
        {
            b.numerator += b.whole * b.denominator;
            b.whole = 0;
        }
        c.numerator = a.numerator * b.numerator;
        c.denominator = a.denominator * b.denominator;
        c.Reduce();

        return c;
    }

    public static Fraction operator /(Fraction a, Fraction b)
    {
        Fraction c = new Fraction();
        if (a.whole != 0)
        {
            a.numerator += a.whole * a.denominator;
            a.whole = 0;
        }
        else if (b.whole != 0)
        {
            b.numerator += b.whole * b.denominator;
            b.whole = 0;
        }
        c.numerator = a.numerator * b.denominator;
        c.denominator = a.denominator * b.numerator;

        c.Reduce();

        return c;
    }

    public string Display()
    {
        string temp = "";
        if (this.whole == 0)
        {
            if (this.denominator == 1)
            {
                temp = Convert.ToString(this.numerator);
            }  
            else if (this.numerator != 0)
            {
                temp = this.numerator + "/" + this.denominator;
            }
        }
        else
        {
            temp = Convert.ToString(this.whole);
            if (this.denominator == 1 && this.numerator != 0)
            {
                temp = " " + Convert.ToString(this.whole + this.numerator);
            }
            else if (this.numerator != 0)
            {
                temp += " " + this.numerator + "/" + this.denominator;
            }
        }

        return temp;
    }
}

class Fractions
{
    static void Main(string[] args)
    {
        Fraction X = new Fraction(1, 3, 4);
        Fraction Y = new Fraction(2, 3, 8);
        Fraction Z = X - Y;
        Console.WriteLine(Z.Display());
        Console.ReadLine();
    }
}