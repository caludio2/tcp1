using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vassoura : MonoBehaviour
{
    public Transform player;
    public float vel;
    [SerializeField] private bool seguir;
    void Start()
    {
        
    }
    void Update()
    {
        if (player == null)
        {
            seguir = false;
        }
        else
        {
            player = GameObject.Find("player").transform;
            seguir = true;
            
        }
        if ( seguir == true)
        {
            ir();
        }
    }
    void ir()
    {
        float distancia = Vector3.Distance(player.position, transform.position);
        if(distancia < 15)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.position,vel * Time.deltaTime);
            Vector2 lookDir = transform.position - player.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 180;
            transform.rotation = Quaternion.Euler(0,0,angle);
        }
    }
    
}
