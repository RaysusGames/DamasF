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
    [SerializeField] GameObject[,] grid;


    private void Update()
    {
    }
   public  void onGame()
    {
       

        //Si ganO Y EL player 1 attacka
        if (p2.getHp() <= 0 && attackPLayer1)
        {
           
            Debug.Log("Player1Win");
            canvas.SetActive(true);
            Debug.Log(defenderPosition);
            GridManager.instance.GetTile((int)defenderPosition.x, (int)defenderPosition.y).SetComer(defenderPosition);
            GridManager.instance.GetTile((int)defenderPosition.x, (int)defenderPosition.y).DestroyFicha();

            p2.SetHp(1);

            anim.SetBool("On", false);
            GridManager.instance.GetTile((int)defenderPosition.x, (int)defenderPosition.y).SetComer(new Vector2(999,999));



        }
        else if (p1.getHp() <= 0 && attackPLayer1)
        {
            Debug.Log("Malo");
            canvas.SetActive(true);
            anim.SetBool("On", false);
           
            p1.SetHp(1);
        }


        if (p1.getHp() <= 0 && attackPlayer2)
        {

            Debug.Log("Player1Win");
            canvas.SetActive(true);
            Debug.Log(defenderPosition);
            GridManager.instance.GetTile((int)defenderPosition.x, (int)defenderPosition.y).SetComer(defenderPosition);
            GridManager.instance.GetTile((int)defenderPosition.x, (int)defenderPosition.y).DestroyFicha();

            p1.SetHp(1);

            anim.SetBool("On", false);
            GridManager.instance.GetTile((int)defenderPosition.x, (int)defenderPosition.y).SetComer(new Vector2(999, 999));



        }
        else if (p2.getHp() <= 0 && attackPlayer2)
        {
            Debug.Log("Malo");
            canvas.SetActive(true);
            anim.SetBool("On", false);

            p2.SetHp(1);
        }



    }

    public void SetDefenderPosition(Vector2 v2)
    {
        this.defenderPosition = v2;
    }

}
