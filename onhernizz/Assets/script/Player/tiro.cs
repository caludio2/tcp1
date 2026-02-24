using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro : MonoBehaviour , IDamageble
{
    public float speed;
    public Transform player;
    public Rigidbody2D forca;

    [SerializeField] private int damage;

    public int Damage => damage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        forca.AddForce((player.position - transform.position) * speed,ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D Col)
    {
        Destroy(this.gameObject);
        
    }
}

