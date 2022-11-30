using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Movimiento
{
    Vector2 bulletPos;
  [SerializeField]  Transform bulletA;

    float time;
    float maxTime =2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
      

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        time+=Time.deltaTime;
        if (time >= maxTime)
        {
            Instantiate(bullet, aimPos.position, Quaternion.identity);
            time = 0;
            

        }
    }
    protected override void Move()
    {

        

      

       
        if (bulletA !=null)
        {
            bulletPos = bulletA.position;


            if (transform.position.y > bulletPos.y )
            {
                transform.position += new Vector3(0, moveSpeed * Time.deltaTime);
               
            }

            


            if (transform.position.y < bulletPos.y )
            {
                transform.position += new Vector3(0, -moveSpeed * Time.deltaTime);
            }
           
        }
      
        
    }

    protected override void Shoot()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            bulletA = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bulletA = null;
        

    }


}
