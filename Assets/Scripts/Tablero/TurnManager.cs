using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] Tile[] tile;
    [SerializeField] protected bool endTurn;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

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
                player1.SetActive(true);
                player2.SetActive(false);
                tile[i].Setyourturn(false);
                tile[i].Player2On(true);
            }
        }
        else
        {
            for (int i = 0; i < tile.Length; i++)
            {
                player1.SetActive(false);
                player2.SetActive(true);
                tile[i].Setyourturn(true);
                tile[i].Player2On(false);
            }
        }
       

    }
    
}
