using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Transform player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Rigidbody2D forca = GetComponent<Rigidbody2D>();
        forca.AddForce(player.position - transform.position,ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D Col)
    {
        Vector3 direction = (transform.position - Col.transform.position).normalized;

        Col.gameObject.GetComponent<Rigidbody2D>().AddForce (direction * -1000);
        Destroy(this.gameObject);
    }
}

