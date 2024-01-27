// See https://aka.ms/new-console-template for more information

public class CircleBase
{
    public double Radius { get; set; }
    public double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}