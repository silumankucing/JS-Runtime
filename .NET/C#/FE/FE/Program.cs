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

    public double[,] Solve()
    {
        // Simplified example - Replace with actual FEA calculations
        int numNodes = _mesh.Nodes.Count;
        double[,] stiffnessMatrix = new double[numNodes, numNodes];

        // Sample values (replace with actual calculations)
        stiffnessMatrix[0, 0] = 2;
        stiffnessMatrix[0, 1] = -1;
        stiffnessMatrix[1, 0] = -1;
        stiffnessMatrix[1, 1] = 2;

        return stiffnessMatrix;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create a simple mesh (example: 2 nodes, 1 element)
        Mesh mesh = new Mesh();
        mesh.AddNode(new Node(0, 0));
        mesh.AddNode(new Node(1, 0));
        mesh.AddElement(new Element(0, 1));

        // Solve the problem
        Solver solver = new Solver(mesh);
        double[,] stiffnessMatrix = solver.Solve();

        // Print the stiffness matrix
        Console.WriteLine("Stiffness Matrix:");
        for (int i = 0; i < stiffnessMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < stiffnessMatrix.GetLength(1); j++)
            {
                Console.Write(stiffnessMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.ReadLine();
    }
}