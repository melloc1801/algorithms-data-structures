namespace DataStructure.Test; 

public class Vertex
{
    public int Value { get; set; }
    
    public Vertex(int value)
    {
        Value = value;
    }
    
    public override string ToString()
    {
        return Value.ToString();
    }

}