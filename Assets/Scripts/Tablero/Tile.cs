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

    [SerializeField] protected bool canHighLight;

    private void Start()
    {
        yourTurn = true;
        player2On = false;
        canHighLight = true;
    }

    public void ShowPosition()
    {
        Debug.Log(xPos + " " + yPos);
    }
    public void SetCanHighLight (bool t)
    {
        this.canHighLight = t;
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
    public void SetHighLightOn(bool on)
    {
         this.higtlight.SetActive(on);
    }
    public void HighLightON(bool on)
    {
        if (ocupiedUnit != null)
        {
            foreach (Vector2 v2 in ocupiedUnit.GetPosibleMove())
            {
                GridManager.instance.GetTile((int)v2.x, (int)v2.y).SetHighLightOn(on);
                GridManager.instance.GetTile((int)v2.x, (int)v2.y).SetCanHighLight(!on);
            }
        }
    }

    private void OnMouseDown()
    {  
        //Player1
        //si se selecciona un tile con una ficha
        if (ocupiedUnit != null && yourTurn )
        {
            GridManager.instance.UnitArraund(xPos, yPos);

            //Si la unidad que esta ocuapando el tile es del tipo ally
            if (ocupiedUnit.GetFaction()== Enums.Faction.Ally)
            {
                //si ya tengo seleccionada una ficha aliada
                if (UnitManager.insatance.GetSelectedUnit() != null)
                {
                    UnitManager.insatance.GetSelectedUnit().GetOccupiedTile().HighLightON(false);
                    UnitManager.insatance.GetSelectedUnit().GetPosibleMove().Clear();
                    UnitManager.insatance.SetSelectedUnit(ocupiedUnit);
                    HighLightON(true);
                }
                else
                {
                    HighLightON(false);
                    UnitManager.insatance.SetSelectedUnit(ocupiedUnit);
                    HighLightON(true);
                }

            }
        }
        else if(yourTurn)
        {
            //Si tengo seleccionada una ficha
            if (UnitManager.insatance.GetSelectedUnit()!= null)
            {
                //si el tile esta dentro de las possible moves
                if (UnitManager.insatance.GetSelectedUnit().CheckPosibbleMove(xPos, yPos))
                {
                    if (isWalkeable)
                    {
                        Debug.Log("SI SE PUEDE WALKEABLE");
                        TurnManager a = FindObjectOfType<TurnManager>();
                        a.SetEndTurn(true);

                        SetUnit(UnitManager.insatance.GetSelectedUnit());
                        HighLightON(false);
                        UnitManager.insatance.GetSelectedUnit().GetPosibleMove().Clear();
                        UnitManager.insatance.SetSelectedUnit(null);
                    }
                    else
                    {
                        Debug.Log("SI SE PUEDE ELSE");
                        HighLightON(false);
                        UnitManager.insatance.GetSelectedUnit().GetPosibleMove().Clear();
                        
                        UnitManager.insatance.SetSelectedUnit(null);
                    }
                }
                //si el tile NO esta dentro de las possible moves
                else
                {
                    UnitManager.insatance.GetSelectedUnit().GetOccupiedTile().HighLightON(false);
                    UnitManager.insatance.GetSelectedUnit().GetPosibleMove().Clear();
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
        if (canHighLight)
        {
            higtlight.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (canHighLight)
        {
            higtlight.SetActive(false);
        }
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
