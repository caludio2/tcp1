using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MORCEGOSCRIPT : MonoBehaviour
{
    public Transform idlepoint;
    public Transform player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        float distancia = Vector3.Distance(player.position, idlepoint.position);
        if (distancia < 10)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, 2 * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, idlepoint.position, 3 * Time.deltaTime);
        }
    }
}
