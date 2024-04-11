using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ninja : MonoBehaviour
{
    public Transform player;
    public float range;
    public float distancia;
    public Rigidbody2D rb;
    public float vel;
    void awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float distancia = Vector3.Distance(player.position,transform.position);
        if(distancia < range)
        {
            movimento();
        }
    }
    void movimento()
    {
        if(player.position.x < transform.position.x)
        {
            rb.velocity = new Vector2(-vel,rb.velocity.y);
        }
        if(player.position.x > transform.position.x)
        {
            rb.velocity = new Vector2(vel,rb.velocity.y);
        }
    }
}
