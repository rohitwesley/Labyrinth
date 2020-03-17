using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralWall : MonoBehaviour
{
    Vector2Int mazeDimensions;
    int noVisitedCells;
    CellNeighbours[] maze;
    Stack<Vector2Int> stack;

    enum CellNeighbours
    {
        Cell_Path_N,
        Cell_Path_S,
        Cell_Path_E,
        Cell_Path_W,
        Cell_Visited,
    }

    public void InitilizeMaze()
    {
        mazeDimensions = new Vector2Int(10,10);
        maze = new CellNeighbours[mazeDimensions.x * mazeDimensions.y];
        stack = new Stack<Vector2Int>();
        
        stack.Push(new Vector2Int(0,0));
        maze[0] = CellNeighbours.Cell_Visited;
        noVisitedCells++;

    }

    public void DrawMaze()
    {
        for (int x = 0; x < mazeDimensions.x; x++)
        {
            for (int y = 0; y < mazeDimensions.y; y++)
            {
                int index = (x + (y * mazeDimensions.x));
                if(maze[index] == CellNeighbours.Cell_Visited)
                {
                    //TODO draw Visited Tile
                }
                else
                {
                    //TODO draw Empty Tile
                }
            }
        }

    }


}
