using System;
using System.Collections.Generic;
using System.Linq;

public class Node
{
    public double X { get; set; }
    public double Y { get; set; }

    public Node(double x, double y)
    {
        X = x;
        Y = y;
    }
}

public class Element
{
    public List<int> NodeIndices { get; set; } 

    public Element(params int[] nodeIndices)
    {
        NodeIndices = nodeIndices.ToList();
    }
}

public class Mesh
{
    public List<Node> Nodes { get; set; }
    public List<Element> Elements { get; set; }

    public Mesh()
    {
        Nodes = new List<Node>();
        Elements = new List<Element>();
    }

    public void AddNode(Node node)
    {
        Nodes.Add(node);
    }

    public void AddElement(Element element)
    {
        Elements.Add(element);
    }
}

public class Solver
{
    private Mesh _mesh;

    public Solver(Mesh mesh)
    {
        _mesh = mesh;
    }

    public void Solve()
    {
        Console.WriteLine("Solution complete.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create a simple mesh
        Mesh mesh = new Mesh();

        mesh.AddNode(new Node(0, 0));
        mesh.AddNode(new Node(1, 0));
        mesh.AddNode(new Node(1, 1));
        mesh.AddNode(new Node(0, 1));

        mesh.AddElement(new Element(0, 1, 2)); 
        mesh.AddElement(new Element(0, 2, 3)); 

        // Create and run the solver
        Solver solver = new Solver(mesh);
        solver.Solve();
    }
}