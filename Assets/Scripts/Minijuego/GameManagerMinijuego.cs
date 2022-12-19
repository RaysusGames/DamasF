using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMinijuego : MonoBehaviour
{
    [SerializeField] Player1 p1;
    [SerializeField] Player2 p2;

    [SerializeField] private Vector2 defenderPosition;

      public bool attackPLayer1 = false, attackPlayer2 = false;

    [SerializeField] Animator anim;

    [SerializeField] GameObject canvas;
    
    
    private void Update()
    {
        onGame();
    }
    void onGame()
    {
        if (p1.getHp() <= 0 && attackPlayer2)
        {
            Debug.Log("Player2Win");
            anim.SetBool("On", false);
            p1.SetHp(1);
        }

        //Si ganO Y EL player 1 attacka
        if (p2.getHp() <= 0 && attackPLayer1)
        {
            
            Debug.Log("Player1Win");
            canvas.SetActive(true);
            anim.SetBool("On", false);
            p2.SetHp(1);
            GridManager.instance.GetTile((int)defenderPosition.x, (int)defenderPosition.y).DestroyFicha();
           
           
        }
        else
        {
        }

    }

    public void SetDefenderPosition(Vector2 v2)
    {
        this.defenderPosition = v2;
    }

}
