using System;
using System.Collections.Generic;
using System.Linq;

// Define a class for Domino
public class Domino
{
    public int Side1 { get; private set; }
    public int Side2 { get; private set; }

    // Constructor
    public Domino(int side1, int side2)
    {
        Side1 = side1;
        Side2 = side2;
    }

    // Method to convert attributes to a string
    public override string ToString()
    {
        return $"[{Side1}|{Side2}]";
    }
}

// Define a class for Boneyard
public class Boneyard
{
    private List<Domino> dominos;

    // Constructor
    public Boneyard(int maxDots)
    {
        dominos = new List<Domino>();

        // Generate all possible dominos based on the maximum number of dots
        for (int i = 0; i <= maxDots; i++)
        {
            for (int j = i; j <= maxDots; j++)
            {
                dominos.Add(new Domino(i, j));
            }
        }
    }

    // Get the number of dominos remaining
    public int GetDominosRemaining()
    {
        return dominos.Count;
    }

    // Get a domino based on its position in the boneyard
    public Domino GetDominoAtPosition(int position)
    {
        if (position < 0 || position >= dominos.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
        }
        return dominos[position];
    }

    // Change the domino object in a specific position in the boneyard
    public void ChangeDominoAtPosition(int position, Domino newDomino)
    {
        if (position < 0 || position >= dominos.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
        }
        dominos[position] = newDomino;
    }

    // Draw or deal a domino from the top of the boneyard
    public Domino Draw()
    {
        if (dominos.Count == 0)
        {
            throw new InvalidOperationException("Boneyard is empty.");
        }

        Domino topDomino = dominos[0];
        dominos.RemoveAt(0);
        return topDomino;
    }

    // Check if the boneyard is empty
    public bool IsEmpty()
    {
        return dominos.Count == 0;
    }

    // Shuffle the boneyard
    public void Shuffle()
    {
        Random rng = new Random();
        int n = dominos.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Domino value = dominos[k];
            dominos[k] = dominos[n];
            dominos[n] = value;
        }
    }

    // Convert attributes to a string for displaying on the screen
    public override string ToString()
    {
        return string.Join(", ", dominos.Select(d => d.ToString()));
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Test the Boneyard class
        Boneyard boneyard = new Boneyard(6); // Create a boneyard with dominos up to 6 dots

        Console.WriteLine("Initial Boneyard:");
        Console.WriteLine(boneyard);

        Console.WriteLine($"Number of dominos remaining: {boneyard.GetDominosRemaining()}");

        // Draw and display the top domino
        Domino drawnDomino = boneyard.Draw();
        Console.WriteLine($"Drawn domino: {drawnDomino}");

        // Shuffle the boneyard and display
        boneyard.Shuffle();
        Console.WriteLine("Shuffled Boneyard:");
        Console.WriteLine(boneyard);

        // Change a domino at position 2
        boneyard.ChangeDominoAtPosition(2, new Domino(3, 3));
        Console.WriteLine("Boneyard after changing domino at position 2:");
        Console.WriteLine(boneyard);

        // Check if boneyard is empty
        Console.WriteLine($"Is boneyard empty? {boneyard.IsEmpty()}");
    }
}
