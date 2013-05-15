using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Text;
using System.IO;

[TestClass]
public class MatrixWalkTest
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Constructor_ZeroElements()
    {
        Console.SetIn(new StringReader("0"));
        int input = int.Parse(Console.ReadLine());
        MatrixWalk matrixWalk = new MatrixWalk(input);
    }

    [TestMethod]
    public void PrintMatrix_OneFilledElement()
    {
        Console.SetIn(new StringReader("1"));
        int input = int.Parse(Console.ReadLine());

        MatrixWalk matrixWalk = new MatrixWalk(input);
        matrixWalk.Fill();
        string result = matrixWalk.Print();

        Assert.AreEqual(result, string.Format("{0,4}{1}", 1, Environment.NewLine));
    }

    [TestMethod]
    public void PrintMatrix_OneEmptyElement()
    {
        Console.SetIn(new StringReader("1"));
        int input = int.Parse(Console.ReadLine());

        MatrixWalk matrixWalk = new MatrixWalk(input);
        string result = matrixWalk.Print();

        Assert.AreEqual(result, string.Format("{0,4}{1}", 0, Environment.NewLine));
    }

    [TestMethod]
    public void PrintMatrix_InputSix()
    {
        Console.SetIn(new StringReader("6"));
        int input = int.Parse(Console.ReadLine());

        MatrixWalk matrixWalk = new MatrixWalk(input);
        matrixWalk.Fill();
        string result = matrixWalk.Print();
        string expected =
            "   1  16  17  18  19  20" + Environment.NewLine +
            "  15   2  27  28  29  21" + Environment.NewLine +
            "  14  31   3  26  30  22" + Environment.NewLine +
            "  13  36  32   4  25  23" + Environment.NewLine +
            "  12  35  34  33   5  24" + Environment.NewLine +
            "  11  10   9   8   7   6" + Environment.NewLine;

        Assert.AreEqual(result, expected);
    }
}
