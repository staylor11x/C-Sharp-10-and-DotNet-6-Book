using System.Text.Json.Serialization;

namespace Packt.Shared;

public abstract class Shape
{
    public Shape(){}

    //fields
    [JsonInclude]
    public string? Color;
    [JsonInclude]
    public double height;
    [JsonInclude]
    public double width;

    //properties
    public virtual double Height
    {
        get
        {
            return height;
        }
        set
        {
            if(value > 0)
            {
                height = value;
            }
        }
    }

    public virtual double Width
    {
        get
        {
            return width;
        }
        set
        {
            if(value > 0)
            {
                width = value;
            }
        }
    }
    
    public abstract double Area { get; }

}