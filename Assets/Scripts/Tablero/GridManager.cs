using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] private Tile grassTile,stoneTile;
    [SerializeField] private Transform cam;
    [SerializeField]GameObject [,] grid;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        GenerateGrid();
    }



    void GenerateGrid()
    {
        grid = new GameObject[width, height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Tile rendTile;
              /*  if (Random.Range(0, 6) == 3)
                {
                    rendTile = stoneTile;

                }
                else
                {
                    rendTile = grassTile;
                }*/
                Tile t = Instantiate(grassTile, new Vector3(x, y), Quaternion.identity);
                t.Tileinit(x, y);
                grid[x, y] = t.gameObject;
            }
        }
        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 05f, -10);
    }

    public Tile GetTile(int x , int y)
    {
        Tile t = null;
        if (grid[x,y]!= null)
        {
            t = grid[x, y].GetComponent<Tile>();
            
        }
        return t;
    }




}
