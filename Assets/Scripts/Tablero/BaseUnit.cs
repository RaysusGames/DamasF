using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    [SerializeField] protected Tile ocupiedTile;
    [SerializeField] protected Enums.Faction faction;

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
