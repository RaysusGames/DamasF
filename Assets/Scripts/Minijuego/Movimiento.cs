using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
   [SerializeField] protected float moveSpeed;
    [SerializeField] protected Rigidbody2D rb ;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected Transform aimPos;
    [SerializeField] protected float hp;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float getHp()
    {
        return this.hp;
    }
    public void setHp(float damage)
    {
        this.hp = damage;
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
      
    }
    protected virtual void Shoot()
    {

    }
}
