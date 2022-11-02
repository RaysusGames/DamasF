using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Movimiento
{
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    protected override void Move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            rb.AddForce(new Vector2(0, 1) * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.AddForce(new Vector2(0, -1) * moveSpeed * Time.deltaTime);
        }
    }
}
