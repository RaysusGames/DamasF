using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //

    [SerializeField] protected SpriteRenderer sRend;
    [SerializeField] protected GameObject higtlight;
    [SerializeField] protected BaseUnit ocupiedUnit;
    [SerializeField] protected bool isWalkeable;

    public virtual void Tileinit(int x,int y)
    {
        
    }

    public BaseUnit GetOccupiedUnit()
    {
        return this.ocupiedUnit;
    }
    public void SetOcccupiedUnit(BaseUnit unit)
    {
        this.ocupiedUnit = unit;
    }
    private void OnMouseDown()
    {
        if (ocupiedUnit != null)
        {
            if (ocupiedUnit.GetFaction()== Enums.Faction.Ally)
            {
                UnitManager.insatance.SetSelectedUnit(ocupiedUnit);
            }
            else
            {
                if (UnitManager.insatance.GetSelectedUnit() != null)
                {
                    Destroy(ocupiedUnit.gameObject);
                    SetUnit(UnitManager.insatance.GetSelectedUnit());
                    UnitManager.insatance.SetSelectedUnit(null);
                }
            }
        }
        else
        {
            if (UnitManager.insatance.GetSelectedUnit()!= null)
            {
                if (isWalkeable)
                {
                    SetUnit(UnitManager.insatance.GetSelectedUnit());
                    UnitManager.insatance.SetSelectedUnit(null);

                }
                else
                {
                    UnitManager.insatance.SetSelectedUnit(null);
                }
            }
        }
    }
    private void OnMouseEnter()
    {
        higtlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        higtlight.SetActive(false);
    }

    public void SetUnit(BaseUnit unit)
    {
        if (unit.GetOccupiedTile() != null)
        {
            unit.GetOccupiedTile().ocupiedUnit = null;
        }

        unit.transform.position = transform.position;
        this.ocupiedUnit = unit;
        unit.setOccupiedTile(this);
    }
}
