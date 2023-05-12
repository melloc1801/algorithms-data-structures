namespace DataStructure.Test;

public class Edge
{
    public Vertex From { get; set; }
    public Vertex To { get; set; }
    public bool Oriented { get; set; }
    public int Weight { get; set; }

    public Edge(Vertex from, Vertex to, bool oriented = false, int weight = 1)
    {
        From = from;
        To = to;
        Oriented = oriented;
        Weight = weight;
    }
}