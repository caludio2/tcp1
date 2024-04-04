using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candelabro : MonoBehaviour
{
    public Transform player;
    public GameObject fogo;
    public float tempo;
    private  bool espera = true;
    void FixedUpdate()
    {
        float posy =  player.position.y - transform.position.y;
        float posx = player.position.x - transform.position.x;
        float mira = Mathf.Atan2(posy,posx) * Mathf.Rad2Deg;
        tempo = tempo + 1 * Time.deltaTime;
        if(tempo > 10)
        {
            Instantiate(fogo,transform.position,Quaternion.Euler(0,0,mira));
            tempo = 0;
        }
    }
       
}
