using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] GameManagerMinijuego managerMinijuego;
    [SerializeField] bool ally;
    private void Start()
    {
        managerMinijuego = GameObject.FindObjectOfType<GameManagerMinijuego>(); 

        Destroy(this.gameObject, 6f);
    }
    private void Update()
    {
        Move();
    }

    void Move()
    {
        rb.AddForce(new Vector2(1, 0) * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
 
            collision.gameObject.GetComponent<Player2>().setDamage(1);
           
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
           
            Destroy(this.gameObject);
            managerMinijuego.onGame();
        }
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
           

            collision.gameObject.GetComponent<Player1>().setDamage(1);
         
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
           
            Destroy(this.gameObject);
            managerMinijuego.onGame();
        }


        if (collision.gameObject.CompareTag("BDown"))
        {
            Destroy(this.gameObject);
        }

        if (ally && collision.gameObject.CompareTag("Bblanca"))
        {
            Destroy(this.gameObject);
        }
        if (!ally&& collision.gameObject.CompareTag("Bnegra"))
        {
            Destroy(this.gameObject);
        }
       
        
    }



}
