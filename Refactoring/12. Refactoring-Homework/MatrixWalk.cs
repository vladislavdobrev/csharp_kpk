using System;
using System.Text;

public class MatrixWalk
{
    // Number of all directions
    private const int Directions = 8;

    // Arrays with numbers for adding to X and Y to move in direction.
    private readonly int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
    private readonly int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

    private readonly int dimension;
    private readonly int[,] matrix;
    private int currentPositionX;
    private int currentPositionY;

    // Numbers to be filled in the array.
    private int nextNumber;

    private int directionX;
    private int directionY;

    public MatrixWalk(int dimension)
    {
        if (dimension == 0)
        {
            throw new ArgumentOutOfRangeException(
                "The dimension size should be greater than 0.");
        }

        this.dimension = dimension;
        this.matrix = new int[dimension, dimension];
        this.currentPositionX = 0;
        this.currentPositionY = 0;
        this.nextNumber = 1;
        this.directionX = 1;
        this.directionY = 1;
    }

    /// <summary>
    /// Change to next clockwise direction.
    /// </summary>
    private void ChengeDirection()
    {
        for (int index = 0; index < Directions; index++)
        {
            if (directionsX[index] == this.directionX &&
                directionsY[index] == this.directionY)
            {
                if (index == Directions - 1)
                {
                    this.directionX = directionsX[0];
                    this.directionY = directionsY[0];
                }
                else
                {
                    this.directionX = directionsX[index + 1];
                    this.directionY = directionsY[index + 1];
                }

                break;
            }
        }
    }

    /// <summary>
    /// Check if there are any free direction.
    /// </summary>
    private bool FreePositionInAnyDirection()
    {
        for (int i = 0; i < Directions; i++)
        {
            bool isNeighbourXInArray = this.currentPositionX + directionsX[i] < dimension &&
                this.currentPositionX + directionsX[i] >= 0;
            bool isNeighbourYInArray = this.currentPositionY + directionsY[i] < dimension &&
                this.currentPositionY + directionsY[i] >= 0;

            if (isNeighbourXInArray && isNeighbourYInArray)
            {
                bool isNeighbourElementEmpty = this.matrix[this.currentPositionX + directionsX[i],
                    this.currentPositionY + directionsY[i]] == 0;
                if (isNeighbourElementEmpty)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void FindNextEmptyCell()
    {
        for (int row = 0; row < dimension; row++)
        {
            for (int col = 0; col < dimension; col++)
            {
                if (this.matrix[row, col] == 0)
                {
                    this.currentPositionX = row;
                    this.currentPositionY = col;
                    return;
                }
            }
        }
    }

    /// <summary>
    /// Filling the given matrix with numbers.
    /// </summary>
    public void Fill()
    {
        while (nextNumber <= dimension * dimension)
        {
            this.matrix[this.currentPositionX, this.currentPositionY] = nextNumber;
            nextNumber++;

            if (!FreePositionInAnyDirection())
            {
                FindNextEmptyCell();
                ChengeDirection();
            }
            else
            {
                // If neighbour position is out of the array or the element is not empty.
                while (this.currentPositionX + this.directionX >= dimension ||
                    this.currentPositionX + this.directionX < 0 ||
                    this.currentPositionY + this.directionY >= dimension ||
                    this.currentPositionY + this.directionY < 0 ||
                    this.matrix[this.currentPositionX + this.directionX,
                    this.currentPositionY + this.directionY] != 0)
                {
                    ChengeDirection();
                }

                this.currentPositionX += this.directionX;
                this.currentPositionY += this.directionY;
            }
        }
    }

    /// <summary>
    /// Printing given matrix.
    /// </summary>
    public string Print()
    {
        StringBuilder output = new StringBuilder();
        for (int row = 0; row < dimension; row++)
        {
            for (int col = 0; col < dimension; col++)
            {
                output.AppendFormat("{0,4}", this.matrix[row, col]);
            }
            output.AppendLine();
        }

        return output.ToString();
    }
}
