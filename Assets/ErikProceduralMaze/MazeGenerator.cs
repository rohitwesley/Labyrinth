using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    int width, height;

    [SerializeField]
    MazeCell cellPrefab;

    private MazeCell[,] maze;

    private void Awake()
    {
        maze = new MazeCell[width, height];
    }

    private void Start()
    {
        Generate();

        Vector2Int startingPosition = new Vector2Int(0, 0);

        Path(startingPosition);
    }

    private void Generate()
    {
        for (int y = 0; y < maze.GetLength(1); y++)
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                Vector3 position = new Vector3(x, 0, y);
                MazeCell cell = Instantiate(cellPrefab, position, Quaternion.identity);

                maze[x, y] = cell;
            }
        }
    }

    private void Path(Vector2Int currentPosition)
    {
        maze[currentPosition.x, currentPosition.y].SetVisited();

        List<Vector2Int> neighbors = GetAllNeighbors(currentPosition);

        while (true)
        {
            List<Vector2Int> unvisited = neighbors.Where(n => !maze[n.x, n.y].Visited).ToList();

            if (unvisited.Count > 0)
            {
                int targetNeighborIndex = Random.Range(0, unvisited.Count);
                Vector2Int targetNeighborPosition = unvisited[targetNeighborIndex];

                maze[currentPosition.x, currentPosition.y].RemoveWall(targetNeighborPosition - currentPosition);
                maze[targetNeighborPosition.x, targetNeighborPosition.y].RemoveWall(currentPosition - targetNeighborPosition);

                Path(targetNeighborPosition);
            }
            else
            {
                break;
            }
        }
    }

    // Cells on the edge of the maze will have fewer neighbors.
    private List<Vector2Int> GetAllNeighbors(Vector2Int cellPosition)
    {
        List<Vector2Int> neighbors = new List<Vector2Int>();

        Vector2Int north = cellPosition + new Vector2Int(0, 1);
        Vector2Int south = cellPosition + new Vector2Int(0, -1);
        Vector2Int east = cellPosition + new Vector2Int(1, 0);
        Vector2Int west = cellPosition + new Vector2Int(-1, 0);

        if (IsValidNeighbor(north))
            neighbors.Add(north);

        if (IsValidNeighbor(south))
            neighbors.Add(south);

        if (IsValidNeighbor(east))
            neighbors.Add(east);

        if (IsValidNeighbor(west))
            neighbors.Add(west);

        return neighbors;
    }

    private bool IsValidNeighbor(Vector2Int position)
    {
        return position.x >= 0 && position.x < width
            && position.y >= 0 && position.y < height;
    }
}
