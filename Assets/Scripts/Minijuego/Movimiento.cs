using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
   [SerializeField] protected float moveSpeed;
    [SerializeField] protected Rigidbody2D rb ;
    [SerializeField] protected GameObject bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Movimiento()
    {
        
    }

    public Movimiento(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }
    protected virtual void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            
            rb.AddForce(new Vector2(0,1)*moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(new Vector2(0, -1) * moveSpeed* Time.deltaTime);
        }
    }
    protected virtual void Shoot()
    {

    }
}
