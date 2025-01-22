// Shape Customizer using Decorator Design Pattern in C#

using System;
using System.Collections.Generic;

// Step 1: Shape interface
public interface IShape
{
    void Draw();
}

// Step 2: Concrete shapes
public class Circle : IShape
{
    public void Draw() => Console.WriteLine("Drawing a Circle");
}

public class Rectangle : IShape
{
    public void Draw() => Console.WriteLine("Drawing a Rectangle");
}

// Step 3: Base Decorator
public abstract class ShapeDecorator : IShape
{
    protected IShape _shape;

    public ShapeDecorator(IShape shape) => _shape = shape;

    public virtual void Draw() => _shape.Draw();
}

// Step 4: Concrete Decorators

// Add Color
public class ColorDecorator : ShapeDecorator
{
    private string _color;

    public ColorDecorator(IShape shape, string color) : base(shape) => _color = color;

    public override void Draw()
    {
        _shape.Draw();
        Console.WriteLine($"Adding Color: {_color}");
    }
}

// Add Border
public class BorderDecorator : ShapeDecorator
{
    private int _borderThickness;

    public BorderDecorator(IShape shape, int borderThickness) : base(shape) => _borderThickness = borderThickness;

    public override void Draw()
    {
        _shape.Draw();
        Console.WriteLine($"Adding Border with Thickness: {_borderThickness}px");
    }
}

// Add Shadow
public class ShadowDecorator : ShapeDecorator
{
    public ShadowDecorator(IShape shape) : base(shape) { }

    public override void Draw()
    {
        _shape.Draw();
        Console.WriteLine("Adding Shadow");
    }
}

// Step 5: Test the program
class Program
{
    static void Main(string[] args)
    {
        // Create a Circle
        IShape circle = new Circle();

        // Decorate Circle with Color, Border, and Shadow
        IShape decoratedCircle = new ShadowDecorator(
                                  new BorderDecorator(
                                  new ColorDecorator(circle, "Red"), 5));

        Console.WriteLine("Customized Circle:");
        decoratedCircle.Draw();

        Console.WriteLine();

        // Create a Rectangle
        IShape rectangle = new Rectangle();

        // Decorate Rectangle with Border only
        IShape decoratedRectangle = new BorderDecorator(rectangle, 3);

        Console.WriteLine("Customized Rectangle:");
        decoratedRectangle.Draw();
    }
}
