using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    public float tempo;
    public int D;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tempo = tempo + 0.1f;
        if(tempo < 0)
        {
            transform.position = transform.position + new Vector3(0.01f,0,0);
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        if(tempo > 0)
        {
            transform.position = transform.position - new Vector3(0.01f,0,0);
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        if(tempo > D)
        {
            tempo = -D;
        }
    }
}
