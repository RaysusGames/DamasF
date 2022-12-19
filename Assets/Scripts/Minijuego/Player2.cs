using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Movimiento
{
    private void Update()
    {
        Move();
        Shoot();
    }
    protected override void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {

            rb.AddForce(new Vector2(0, 1) * moveSpeed * Time.deltaTime);
        }
       
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(new Vector2(0, -1) * moveSpeed * Time.deltaTime);
        }
       
    }


    protected override void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(bullet, aimPos.position, Quaternion.identity);
        }

    }
}
