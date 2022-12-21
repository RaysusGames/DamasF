using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer sRend;
    [SerializeField] protected GameObject higtlight;
    [SerializeField] protected BaseUnit ocupiedUnit;
    [SerializeField] protected bool isWalkeable;
    [SerializeField] protected bool yourTurn,player2On;

    [SerializeField] protected int xPos;
    [SerializeField] protected int yPos;

    [SerializeField] protected bool canHighLight;

    [SerializeField] protected Vector2 comer;

    [SerializeField] protected GameObject Minijuego;
    [SerializeField] protected GameObject canvas;
    //Test
    

    private void Start()
    {
        yourTurn = true;
        player2On = false;
        canHighLight = true;
        comer = new Vector2(999, 999);
        Minijuego = GameObject.FindGameObjectWithTag("Minijuego");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
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

    public void SetComer(Vector2 v2)
    {
        this.comer = v2;
    }

    private void OnMouseDown()
    {  
        //Player1
        //si se selecciona un tile con una ficha
        if (ocupiedUnit != null && yourTurn )
        {
            this.comer = new Vector2( 999,999);
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

                        if (this.comer != new Vector2(999, 999))
                        {
                           
                          

                            //LLAMAR MINI JUEGO
                            Minijuego.GetComponent<Animator>().SetBool("On", true);
                            Minijuego.GetComponent<GameManagerMinijuego>().attackPLayer1 = true;
                            Minijuego.GetComponent<GameManagerMinijuego>().attackPlayer2 = false;
                            Minijuego.GetComponent<GameManagerMinijuego>().SetDefenderPosition(comer);
                            canvas.SetActive(false);
                           


                             //DestroyFicha();




                        }
                        
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

     /*   if (ocupiedUnit != null && player2On)
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
        }*/



        //Player2
        //si se selecciona un tile con una ficha
        if (ocupiedUnit != null && player2On)
        {
            this.comer = new Vector2(999, 999);
            GridManager.instance.UnitArraundP2(xPos, yPos);

            //Si la unidad que esta ocuapando el tile es del tipo ally
            if (ocupiedUnit.GetFaction() == Enums.Faction.Enemy)
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
        else if (player2On)
        {
            //Si tengo seleccionada una ficha
            if (UnitManager.insatance.GetSelectedUnit() != null)
            {
                //si el tile esta dentro de las possible moves
                if (UnitManager.insatance.GetSelectedUnit().CheckPosibbleMove(xPos, yPos))
                {
                    if (isWalkeable)
                    {
                        Debug.Log("SI SE PUEDE WALKEABLE");
                        TurnManager a = FindObjectOfType<TurnManager>();
                        a.SetEndTurn(false);

                        SetUnit(UnitManager.insatance.GetSelectedUnit());
                        HighLightON(false);

                        if (this.comer != new Vector2(999, 999))
                        {
                            //LLAMAR MINI JUEGO
                            //DestroyFicha();
                          
                            Minijuego.GetComponent<Animator>().SetBool("On", true);
                            Minijuego.GetComponent<GameManagerMinijuego>().attackPLayer1 = false;
                            Minijuego.GetComponent<GameManagerMinijuego>().attackPlayer2 =true;
                            Minijuego.GetComponent<GameManagerMinijuego>().SetDefenderPosition(comer);
                            canvas.SetActive(false);
                            

                        




                        }

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

    public void DestroyFicha()
    {
        Debug.Log(comer.x);
        Debug.Log(comer.y);
        
        
            Destroy(GridManager.instance.GetTile((int)comer.x, (int)comer.y).GetOccupiedUnit().gameObject);
            GridManager.instance.GetTile((int)comer.x, (int)comer.y).SetOcccupiedUnit(null);
        
      
        
        
        this.comer = new Vector2(999, 999);
      
 
    }

    
}
