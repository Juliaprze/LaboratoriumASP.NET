namespace WebApplication1.Models;

public enum Operators
{
    Unknown, Add, Mul, Sub, Div
        
}

public class Calculator
{
    public Operators? op { get; set; }
    
    public double? a { get; set; } 
    
    public double? b { get; set; }

    public String Op
    {
        get
        {
            switch (op)
            {
                case Operators.Add:
                    return "+";
                case Operators.Sub:
                    return "-";
                case Operators.Mul:
                    return "*";
                case Operators.Div:
                   return "/";
                default:
                    return "";
            
            }
        }
    }

    public bool IsValid()
    {
        return op != null && a != null && b != null;
    }

    public double Calculate()
    {
        switch (op)
        {
            case Operators.Add:                
                return (double) (a + b);            
            case Operators.Sub:                
                return (double) (a - b);            
            case Operators.Mul:                
                return (double) (a * b);            
            case Operators.Div:                
                return (double) (a / b);            
            default: 
                return double.NaN;
        }
    }
}
    