//Shape Customizer
/* Create a program for customizing shapes using decorator desing pattern:
1) Start with a Shape interface with a method draw().
2) Implement a Circle and Rectangle as concrete shapes.
3) Use decorators to add features like Color, Border, and Shadow. */


using System;
namespace DecoratorDesignPattern
{
  public abstract class Shape
  {
    private string draw;
    
    public Shape()
    {
      draw = "Random Shape";
    }
    
    public virtual string Draw
    {
      get { return draw; }
      protected set
      {
        draw = value;
      }
    }
    
    public abstract int Area();
  }
  
  public class Circle : Shape
  {
    public Circle()
    {
      Draw = "Circle";
    }
    
    public override int Area() => 1;
  }
  
  public class Reactangle : Shape
  {
    public Reactangle()
    {
      Draw = "Reactangle";
    }
    
    
    public override int Area() => 2;
  }
  
  public abstract class CondimentDecorator : Shape
  {
    protected Shape shape;
    
    public CondimentDecorator(Shape shape)
    {
      this.shape = shape;
    }
    
    public override string Draw => shape.Draw;
    
    public override int Area() => shape.Area();
  }
  
  public class Color : CondimentDecorator
  {
    public Color(Shape shape) : base(shape) { }
    
    public override string Draw => shape.Draw + ", Color";
    
    public override int Area() => shape.Area() + 3;
  }
  
  public class Border : CondimentDecorator
  {
    public Border(Shape shape) : base(shape) { }
    
    public override string Draw => shape.Draw + ", Border";
    
    public override int Area() => shape.Area() + 1;
  }
  
  public class Shadow : CondimentDecorator
  {
    public Shadow(Shape shape) : base(shape) { }
    
    public override string Draw => shape.Draw + ", Shadow";
    
    public override int Area() => shape.Area() + 2;
  }
  
  class Program
  {
    public static void Main(string[] args)
    {
      Shape shape1 = new Reactangle();
      
      shape1 = new Color(shape1);
      shape1 = new Border(shape1);
      shape1 = new Shadow(shape1);
      
      Console.WriteLine($"Shape you got is : {shape1.Draw}");
      Console.WriteLine($"Total area cost to draw : {shape1.Area()}");
    }
  }
}
