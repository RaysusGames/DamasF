using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;


    private void Update()
    {
        Move();
    }

    void Move()
    {
        rb.AddForce(new Vector2(1, 0) * speed * Time.deltaTime);
    }



}
