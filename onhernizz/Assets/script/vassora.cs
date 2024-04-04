using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vassoura : MonoBehaviour
{
    public Transform player;
    int tempo;
    public int vel;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(player.position, transform.position);
        if(distancia < 200)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.position,vel * Time.deltaTime);
        }
        else
        {
            lado();
        }
    }
    void lado()
    {

    }
}
