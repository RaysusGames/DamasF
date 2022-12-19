using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Movimiento : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected Transform aimPos;
    [SerializeField] protected float hp;
    [SerializeField] protected TextMeshProUGUI hpText;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hpText.SetText(hp.ToString(""));
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public float getHp()
    {
        return this.hp;
    }
    public void setDamage(float damage)
    {
        this.hp -= damage;
        
        hpText.SetText(hp.ToString(""));

    }
    public void SetHp(float hp)
    {
        this.hp = hp;
        hpText.SetText(hp.ToString(""));
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
