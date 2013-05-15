using System;

class MatrixWalkMain
{
    static void Main()
    {
        Console.Write("Enter a positive number: ");
        string input = Console.ReadLine();
        int number;
        while (!int.TryParse(input, out number) || number < 0 || number > 100)
        {
            Console.Write("You haven't entered a correct positive number. Enter again: ");
            input = Console.ReadLine();
        }

        MatrixWalk matrixWalk = new MatrixWalk(number);
        matrixWalk.Fill();
        Console.Write(matrixWalk.Print());
    }
}
