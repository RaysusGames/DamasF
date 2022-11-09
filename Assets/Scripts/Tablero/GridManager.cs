using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] private Tile tile;
    [SerializeField] private Transform cam;


    private void Start()
    {
        GenerateGrid();
    }



    void GenerateGrid()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Tile t = Instantiate(tile, new Vector3(x, y), Quaternion.identity);
                t.name = $"Tile{x} {y}";

                bool isOffset;
                if ((x % 2 ==0 && y % 2 !=0) || (x%2 !=0 && y%2 == 0))
                {
                    isOffset = true;
                }
                else
                {
                    isOffset = false;
                }

                t.Tileinit(isOffset);
            }
        }
        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 05f, -10);
    }




}
