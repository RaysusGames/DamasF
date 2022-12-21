using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] Tile[] tile;
    [SerializeField] protected bool endTurn;
    [SerializeField] Animator player1;
    [SerializeField] Animator player2;
    [SerializeField] GameObject fogPlayer1,fogPlayer2;

    private void Start()
    {
        endTurn = false;
    }

    public void SetEndTurn(bool endTun)
    {
        this.endTurn = endTun;
    }
    private void Update()
    {
       tile = GameObject.FindObjectsOfType<Tile>() ;

        if (endTurn)
        {
            for (int i = 0; i < tile.Length; i++)
            {
                player1.SetBool("OnTurn",true);
                fogPlayer1.SetActive(true);
                player2.SetBool("OnTurn", false);
                fogPlayer2.SetActive(false);
                tile[i].Setyourturn(false);
                tile[i].Player2On(true);
            }
        }
        else
        {
            for (int i = 0; i < tile.Length; i++)
            {
                player1.SetBool("OnTurn", false);
                fogPlayer1.SetActive(false);
                player2.SetBool("OnTurn", true);
                fogPlayer2.SetActive(true);
                tile[i].Setyourturn(true);
                tile[i].Player2On(false);
            }
        }
       

    }
    
}
