using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    [SerializeField] protected Tile ocupiedTile;
    [SerializeField] protected Enums.Faction faction;
    [SerializeField] protected List<Vector2> possibleMoves;




    public void AddPosibleMove(Vector2 Posibility)
    {
        possibleMoves.Add(Posibility);
    }

    public List<Vector2> GetPosibleMove()
    {
        return this.possibleMoves;
    }
    public void ShowPossibleMove()
    {
        foreach (Vector2 V2 in possibleMoves)
        {
            Debug.Log(V2);
        }
    }
    public Tile GetOccupiedTile()
    {
        return this.ocupiedTile;
    }
    public void setOccupiedTile(Tile t)
    {
        this.ocupiedTile = t;
    }
    public Enums.Faction GetFaction()
    {
        return this.faction;
    }

    public void SetFaction(Enums.Faction fact)
    {
        this.faction = fact;
    }
}
