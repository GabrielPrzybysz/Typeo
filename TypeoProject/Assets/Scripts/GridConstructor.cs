using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridConstructor : MonoBehaviour
{

    public int Width;
    public int Height;

    public static int[,] Matrix;

    public enum Cells 
    {
        Free = 0,
        Wall = 1,
        Player = 2,
        Point = 3,
        OnPoint = 4,
        Item = 5
    }


    public GameObject Free;
    public GameObject Wall;
    public GameObject Player;
    public GameObject Point;
    public GameObject OnPoint;
    public GameObject Item;

    [SerializeField]
    private string _bones;

    private GameObject _grid;


    void Start()
    {
        Matrix = new int[Width, Height];

        int boneIndex = 0;

        for (int x = 0; x < Width; x++) 
        {
            for (int y = 0; y < Height; y++) 
            {
                Matrix[x, y] = (int) char.GetNumericValue(_bones, boneIndex);
                boneIndex++;
            }
        }
    }

    void Update()
    {
        UpdateGrid();
    }

    private void UpdateGrid()
    {
        if (_grid != null)
        {
            Destroy(_grid);
        }

        _grid = new GameObject
        {
            name = "Grid"
        };


        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                if (Matrix[x, y] == (int)Cells.Free)
                {
                    Instantiate(Free, new Vector2(x, y), transform.rotation, _grid.transform);
                }
                if (Matrix[x, y] == (int)Cells.Wall)
                {
                    Instantiate(Wall, new Vector2(x, y), transform.rotation, _grid.transform);
                }
                if (Matrix[x, y] == (int)Cells.Player)
                {
                    Instantiate(Player, new Vector2(x, y), transform.rotation, _grid.transform);
                }
                if (Matrix[x, y] == (int)Cells.Point)
                {
                    Instantiate(Point, new Vector2(x, y), transform.rotation, _grid.transform);
                }
                if (Matrix[x, y] == (int)Cells.OnPoint)
                {
                    Instantiate(OnPoint, new Vector2(x, y), transform.rotation, _grid.transform);
                }
                if (Matrix[x, y] == (int)Cells.Item)
                {
                    Instantiate(Item, new Vector2(x, y), transform.rotation, _grid.transform);
                }
            }
        }
    }
}
