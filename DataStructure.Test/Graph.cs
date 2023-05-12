using NUnit.Framework;

namespace DataStructure.Test;

public class Graph
{
    public List<Vertex> Vertexes { get; }
    public List<Edge> Edges { get; }
    public int VertexesCount => Vertexes.Count;
    public int EdgesCount => Edges.Count;

    public Graph()
    {
        Vertexes = new List<Vertex>();
        Edges = new List<Edge>();
    }

    public void AddVertex(Vertex vertex)
    {
        Vertexes.Add(vertex);
    }

    public void AddEdge(Vertex from, Vertex to)
    {
        var edge = new Edge(from, to);
        Edges.Add(edge);
    }

    public void BreadthFirstSearchLog()
    {
        var visited = new HashSet<Vertex>();
        
        var startVertex = Vertexes.First(vertex => vertex.Value == 1);

        var queue = new Queue<Vertex>();
        queue.Enqueue(startVertex);

        while (queue.Count > 0)
        {
            var newQueueValues = new List<Vertex>();
            
            foreach (var item in queue)
            {
                if (visited.Contains(item))
                {
                    continue; 
                }
                
                Console.Write($"_{item}_");

                Edges.ForEach(edge =>
                    {
                        if (!visited.Contains(edge.From) && edge.From == item)
                        {
                            newQueueValues.Add(edge.To);
                        } else if (!visited.Contains(edge.To) && edge.To == item)
                        {
                            newQueueValues.Add(edge.From);
                        }
                    });
                
                visited.Add(item);
            }

            Console.WriteLine();
            
            queue.Clear();
            
            foreach (var vertex in newQueueValues)
            {
                queue.Enqueue(vertex);
            }
        }
    }

    public void RepeatBFS()
    {
        var matrix = GetMatrix();
        
        var src = Vertexes.First(vertex => vertex.Value == 1);
        var queue = new Queue<Vertex>();
        var visited = new HashSet<Vertex>();
        
        queue.Enqueue(src);
        visited.Add(src);

        while (queue.Count > 0)
        {
            var currentVertex = queue.Dequeue();
            Console.Write(currentVertex.Value);
            for (int i = 0; i < VertexesCount; i++)
            {
                if (matrix[currentVertex.Value - 1, i] == 1)
                {
                    var childVertex = Vertexes.First(v => v.Value == i + 1); 
                    if (!visited.Contains(childVertex))
                    {
                        queue.Enqueue(childVertex);
                        visited.Add(childVertex);
                    }
                }
            }
                
        }
    }
    
    public void BreadFirstSearch()
    {
        var src = Vertexes.First(vertex => vertex.Value == 1);
        var matrix = GetMatrix();
        
        var queue = new Queue<Vertex>();
        var visited = new HashSet<Vertex>();
            
        queue.Enqueue(src);
        visited.Add(src);

        while (queue.Count > 0)
        {
            src = queue.Dequeue();
            Console.WriteLine(src);
            for (int i = 0; i < VertexesCount; i++)
            {
                var matValue = matrix[src.Value - 1, i];
                var vertex = Vertexes.First(v => v.Value == i + 1);
                if (matValue == 1 && !visited.Contains(vertex))
                {
                    queue.Enqueue(vertex);
                    visited.Add(vertex);
                }
            }
        }
    }

    public void DepthFirstSearchLog()
    {
        var matrix = GetMatrix();
        var visited = new HashSet<Vertex>();
        
        var stack = new Stack<Vertex>();
        var startVertex = Vertexes.First(vertex => vertex.Value == 1);
        stack.Push(startVertex);

        while (stack.Count > 0)
        {
            var currentVertex = stack.Pop();
            Console.WriteLine(currentVertex.Value);
            for (int i = 0; i < VertexesCount; i++)
            {
                if (matrix[currentVertex.Value - 1, i] == 1)
                {
                    var vertex = Vertexes.First(v => v.Value - 1 == i);
                    if (!visited.Contains(vertex))
                    {
                        stack.Push(vertex);
                        visited.Add(vertex);
                    }
                }
            }
            
            // 1. Find all children
            // 2. Add children to stack
            // 3. Go to 1st Step
            // 4. If there are no children => log current node
        }
        
    }

    public int[,] GetMatrix()
    {
        var matrix = new int[VertexesCount, VertexesCount];

        foreach (var edge in Edges)
        {
            var from = edge.From.Value - 1;
            var to = edge.To.Value - 1;

            matrix[from, to] = 1;
        }

        return matrix;
    }

    public void LogMatrix()
    {
        var matrix = GetMatrix();

        Console.Write($"№ |");
        for (int i = 0; i < VertexesCount; i++)
        {
            Console.Write($"_{i + 1}_");
        }
        Console.WriteLine();

        for (int i = 0; i < VertexesCount; i++)
        {
            Console.Write($"{i + 1} |");
            for (int j = 0; j < VertexesCount; j++)
            {
                Console.Write($"_{matrix[i, j]}_");
            }
            Console.WriteLine();
        }
    }
}

[TestFixture]
public class Test
{
    [Test]
    public void Tmp()
    {
        var graph = new Graph();

        var v1 = new Vertex(1);
        var v2 = new Vertex(2);
        var v3 = new Vertex(3);
        var v4 = new Vertex(4);
        var v5 = new Vertex(5);
        var v6 = new Vertex(6);
        var v7 = new Vertex(7);
        var v8 = new Vertex(8);
        var v9 = new Vertex(9);
        
        graph.AddVertex(v1);
        graph.AddVertex(v2);
        graph.AddVertex(v3);
        graph.AddVertex(v4);
        graph.AddVertex(v5);
        graph.AddVertex(v6);
        graph.AddVertex(v7);
        graph.AddVertex(v8);
        graph.AddVertex(v9);

        graph.AddEdge(v1, v2);
        graph.AddEdge(v1, v7);
        graph.AddEdge(v2, v3);
        graph.AddEdge(v2, v4);
        graph.AddEdge(v2, v5);
        graph.AddEdge(v3, v6);
        graph.AddEdge(v7, v8);
        graph.AddEdge(v8, v9);
     
        // graph.BreadthFirstSearchLog();
        // Console.WriteLine("========");
        // graph.BreadFirstSearch();
        // Console.WriteLine("========");
        // graph.RepeatBFS();
        
        graph.DepthFirstSearchLog();
        // graph.LogMatrix();
    }
}