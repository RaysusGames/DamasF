using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : Movimiento
{
    private void Update()
    {
        Move();
        Shoot();

       
    }
    protected override void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {

            rb.AddForce(new Vector2(0, 1) * moveSpeed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector2(0, -1) * moveSpeed * Time.deltaTime);
        }
     
    }

  


    protected override void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, aimPos.position, Quaternion.identity);
        }
       
    }
}
