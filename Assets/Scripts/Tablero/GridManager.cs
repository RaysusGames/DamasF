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

    public bool IsInsideGrid(int x, int y)
    {
        if (x >= grid.GetLength(0))
        {
            return false;
        }
        if (x < 0)
        {
            return false;
        }

        if (y >= grid.GetLength(1))
        {
            return false;
        }
        if (y < 0)
        {
            return false;
        }

        return true;
    }


    public void UnitArraund(int x,int y)
    {
        ////SUP IZQ
        //if (IsInsideGrid(x-1,y+1)&&grid[x-1,y+1].GetComponent<BaseUnit>().GetOccupiedTile() != null && grid[x - 1, y + 1].GetComponent<BaseUnit>().GetFaction()== Enums.Faction.Enemy)
        //{

        //}
        ////Mid Up
        //if (IsInsideGrid(x , y + 1) && grid[x , y + 1].GetComponent<BaseUnit>().GetOccupiedTile() != null)
        //{

        //}
        ////Sup Der
        //if (IsInsideGrid(x + 1, y + 1) && grid[x + 1, y + 1].GetComponent<BaseUnit>().GetOccupiedTile() != null)
        //{

        //}
        ////Mid DER
        //if (IsInsideGrid(x + 1, y ) && grid[x + 1, y].GetComponent<BaseUnit>().GetOccupiedTile() != null)
        //{

        //}
        //// Infe Der
        //if (IsInsideGrid(x + 1, y - 1) && grid[x + 1, y - 1].GetComponent<BaseUnit>().GetOccupiedTile() != null)
        //{

        //}
        //// Mid Down
        //if (IsInsideGrid(x , y -1) && grid[x, y -1].GetComponent<BaseUnit>().GetOccupiedTile() != null)
        //{

        //}
        ////Infe Izq
        //if (IsInsideGrid(x - 1, y - 1) && grid[x - 1, y - 1].GetComponent<BaseUnit>().GetOccupiedTile() != null)
        //{

        //}
        ////Mid Izq
        //if (IsInsideGrid(x - 1, y ) && grid[x - 1, y ].GetComponent<BaseUnit>().GetOccupiedTile() != null)
        //{

        //}

        //SUP IZQ
        if (IsInsideGrid(x - 1, y + 1))
        {
            //Si la casilla esta ocupada por una ficha enemiga
            if (grid[x - 1, y + 1].GetComponent<Tile>().GetOccupiedUnit() != null && grid[x - 1, y + 1].GetComponent<Tile>().GetOccupiedUnit().GetFaction() == Enums.Faction.Enemy)
            {
                //Agregar posible movimiento de la ficha
                grid[x, y].GetComponent<Tile>().GetOccupiedUnit().AddPosibleMove(new Vector2(x - 2, y + 2));
            }
            //Si la casiila esta vacia
            else if (grid[x - 1, y + 1].GetComponent<Tile>().GetOccupiedUnit() == null)
            {
                //Agregar posible movimiento de la ficha
                grid[x, y].GetComponent<Tile>().GetOccupiedUnit().AddPosibleMove(new Vector2(x - 1, y + 1));
            }
        }
        ////Mid Up

        if (IsInsideGrid(x , y + 1))
        {
            //Si la casilla esta ocupada por una ficha enemiga
            if (grid[x , y + 1].GetComponent<Tile>().GetOccupiedUnit() != null && grid[x , y + 1].GetComponent<Tile>().GetOccupiedUnit().GetFaction() == Enums.Faction.Enemy)
            {
                //Agregar posible movimiento de la ficha
                grid[x, y].GetComponent<Tile>().GetOccupiedUnit().AddPosibleMove(new Vector2(x , y + 2));
            }
            //Si la casiila esta vacia
            else if (grid[x , y + 1].GetComponent<Tile>().GetOccupiedUnit() == null)
            {
                //Agregar posible movimiento de la ficha
                grid[x, y].GetComponent<Tile>().GetOccupiedUnit().AddPosibleMove(new Vector2(x, y + 1));
            }
        }




        ////Sup Der

        if (IsInsideGrid(x+1, y + 1))
        {
            //Si la casilla esta ocupada por una ficha enemiga
            if (grid[x+1, y + 1].GetComponent<Tile>().GetOccupiedUnit() != null && grid[x+1, y + 1].GetComponent<Tile>().GetOccupiedUnit().GetFaction() == Enums.Faction.Enemy)
            {
                //Agregar posible movimiento de la ficha
                grid[x, y].GetComponent<Tile>().GetOccupiedUnit().AddPosibleMove(new Vector2(x+2, y + 2));
            }
            //Si la casiila esta vacia
            else if (grid[x+1, y + 1].GetComponent<Tile>().GetOccupiedUnit() == null)
            {
                //Agregar posible movimiento de la ficha
                grid[x, y].GetComponent<Tile>().GetOccupiedUnit().AddPosibleMove(new Vector2(x+1, y + 1));
            }
        }

        ////Mid DER
        if (IsInsideGrid(x + 1, y ))
        {
            //Si la casilla esta ocupada por una ficha enemiga
            if (grid[x + 1, y ].GetComponent<Tile>().GetOccupiedUnit() != null && grid[x + 1, y ].GetComponent<Tile>().GetOccupiedUnit().GetFaction() == Enums.Faction.Enemy)
            {
                //Agregar posible movimiento de la ficha
                grid[x, y].GetComponent<Tile>().GetOccupiedUnit().AddPosibleMove(new Vector2(x + 2, y ));
            }
            //Si la casiila esta vacia
            else if (grid[x + 1, y ].GetComponent<Tile>().GetOccupiedUnit() == null)
            {
                //Agregar posible movimiento de la ficha
                grid[x, y].GetComponent<Tile>().GetOccupiedUnit().AddPosibleMove(new Vector2(x + 1, y ));
            }
        }





        //// Infe Der


        if (IsInsideGrid(x + 1, y))
        {
            //Si la casilla esta ocupada por una ficha enemiga
            if (grid[x + 1, y -1].GetComponent<Tile>().GetOccupiedUnit() != null && grid[x + 1, y - 1].GetComponent<Tile>().GetOccupiedUnit().GetFaction() == Enums.Faction.Enemy)
            {
                //Agregar posible movimiento de la ficha
                grid[x, y].GetComponent<Tile>().GetOccupiedUnit().AddPosibleMove(new Vector2(x + 2, y - 2));
            }
            //Si la casiila esta vacia
            else if (grid[x + 1, y - 1].GetComponent<Tile>().GetOccupiedUnit() == null)
            {
                //Agregar posible movimiento de la ficha
                grid[x, y].GetComponent<Tile>().GetOccupiedUnit().AddPosibleMove(new Vector2(x + 1, y - 1));
            }
        }



        //// Mid Down
        ///
        if (IsInsideGrid(x + 1, y))
        {
            //Si la casilla esta ocupada por una ficha enemiga
            if (grid[x,y-1].GetComponent<Tile>().GetOccupiedUnit() != null && grid[x, y - 1].GetComponent<Tile>().GetOccupiedUnit().GetFaction() == Enums.Faction.Enemy)
            {
                //Agregar posible movimiento de la ficha
                grid[x, y].GetComponent<Tile>().GetOccupiedUnit().AddPosibleMove(new Vector2(x , y - 2));
            }
            //Si la casiila esta vacia
            else if (grid[x, y - 1].GetComponent<Tile>().GetOccupiedUnit() == null)
            {
                //Agregar posible movimiento de la ficha
                grid[x, y].GetComponent<Tile>().GetOccupiedUnit().AddPosibleMove(new Vector2(x, y - 1));
            }
        }



        ////Infe Izq
        ///
        if (IsInsideGrid(x + 1, y))
        {
            //Si la casilla esta ocupada por una ficha enemiga
            if (grid[x-1, y - 1].GetComponent<Tile>().GetOccupiedUnit() != null && grid[x - 1, y - 1].GetComponent<Tile>().GetOccupiedUnit().GetFaction() == Enums.Faction.Enemy)
            {
                //Agregar posible movimiento de la ficha
                grid[x, y].GetComponent<Tile>().GetOccupiedUnit().AddPosibleMove(new Vector2(x-2, y - 2));
            }
            //Si la casiila esta vacia
            else if (grid[x - 1, y - 1].GetComponent<Tile>().GetOccupiedUnit() == null)
            {
                //Agregar posible movimiento de la ficha
                grid[x, y].GetComponent<Tile>().GetOccupiedUnit().AddPosibleMove(new Vector2(x - 1, y - 1));
            }
        }


        ////Mid Izq
        ///
        if (IsInsideGrid(x + 1, y))
        {
            //Si la casilla esta ocupada por una ficha enemiga
            if (grid[x - 1, y ].GetComponent<Tile>().GetOccupiedUnit() != null && grid[x - 1, y].GetComponent<Tile>().GetOccupiedUnit().GetFaction() == Enums.Faction.Enemy)
            {
                //Agregar posible movimiento de la ficha
                grid[x, y].GetComponent<Tile>().GetOccupiedUnit().AddPosibleMove(new Vector2(x - 2, y ) );
            }
            //Si la casiila esta vacia
            else if (grid[x - 1, y - 1].GetComponent<Tile>().GetOccupiedUnit() == null)
            {
                //Agregar posible movimiento de la ficha
                grid[x, y].GetComponent<Tile>().GetOccupiedUnit().AddPosibleMove(new Vector2(x - 1, y));
            }
        }

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
        //cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 05f, -10);
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
