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
    [SerializeField] protected bool yourTurn,player2On;

    [SerializeField] protected int xPos;
    [SerializeField] protected int yPos;

    private void Start()
    {
        yourTurn = true;
        player2On = false;   
    }

    public void ShowPosition()
    {
        Debug.Log(xPos + " " + yPos);
    }

    public virtual void Tileinit(int x,int y)
    {
        xPos = x;
        yPos = y;
    }
    public void Setyourturn(bool youTurna)
    {
         this.yourTurn = youTurna;
    }
    public void Player2On(bool youTurna)
    {
        this.player2On = youTurna;
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
        //Player1
        if (ocupiedUnit != null && yourTurn )
        {
            GridManager.instance.UnitArraund(xPos, yPos);
            //ocupiedUnit.ShowPossibleMove();
            //Si la unidad que estaocuapando el tile es del tipo ally
            if (ocupiedUnit.GetFaction()== Enums.Faction.Ally)
            {
               
                UnitManager.insatance.SetSelectedUnit(ocupiedUnit);
            }
            else
            {
                //Si la unidad seleccionada es distinta de null
                if (UnitManager.insatance.GetSelectedUnit() != null)
                {
                    Destroy(ocupiedUnit.gameObject);
                    SetUnit(UnitManager.insatance.GetSelectedUnit());
                    UnitManager.insatance.SetSelectedUnit(null);
                }
            }
        }
        else if(yourTurn)
        {
            if (UnitManager.insatance.GetSelectedUnit()!= null)
            {
                if (isWalkeable)
                {
                    TurnManager a = FindObjectOfType<TurnManager>();
                    a.SetEndTurn(true);

                    SetUnit(UnitManager.insatance.GetSelectedUnit());
                    UnitManager.insatance.SetSelectedUnit(null);

                }
                else
                {
                    UnitManager.insatance.SetSelectedUnit(null);
                }
            }
        }


        //player2

        if (ocupiedUnit != null && player2On)
        {
            //Si la unidad que estaocuapando el tile es del tipo ally
            if (ocupiedUnit.GetFaction() == Enums.Faction.Enemy)
            {

                UnitManager.insatance.SetSelectedUnit(ocupiedUnit);
            }
            else
            {
                //Si la unidad seleccionada es distinta de null
                if (UnitManager.insatance.GetSelectedUnit() != null)
                {
                    Destroy(ocupiedUnit.gameObject);
                    SetUnit(UnitManager.insatance.GetSelectedUnit());
                    UnitManager.insatance.SetSelectedUnit(null);
                }
            }
        }
        else if (player2On)
        {
            if (UnitManager.insatance.GetSelectedUnit() != null)
            {
                if (isWalkeable)
                {
                    TurnManager a = FindObjectOfType<TurnManager>();
                    a.SetEndTurn(false);

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
