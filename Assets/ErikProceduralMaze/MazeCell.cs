using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField]
    GameObject wallNorth;

    [SerializeField]
    GameObject wallSouth;

    [SerializeField]
    GameObject wallEast;

    [SerializeField]
    GameObject wallWest;

    public bool Visited { get; private set; }

    private void Awake()
    {
        Visited = false;

        GetComponent<Renderer>().material.color = Color.black;
    }

    public void SetVisited()
    {
        Visited = true;

        GetComponent<Renderer>().material.color = Color.white;
    }

    public void RemoveWall(Vector2Int direction)
    {
        if (direction == new Vector2Int(0, 1))
        {
            wallNorth.SetActive(false);
        }
        else if (direction == new Vector2Int(0, -1))
        {
            wallSouth.SetActive(false);
        }
        else if (direction == new Vector2Int(1, 0))
        {
            wallEast.SetActive(false);
        }
        else if (direction == new Vector2Int(-1, 0))
        {
            wallWest.SetActive(false);
        }
    }
}
