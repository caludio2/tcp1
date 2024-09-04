using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CANDELABROSCRIPT : MonoBehaviour
{
    public Transform player;
    public GameObject boladefogo;
    public float temposobrando;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(player.position, transform.position);
        if (distancia < 15)
        {
            temposobrando += Time.deltaTime;
            if(temposobrando > 5)
            {
                temposobrando = 0;
                Instantiate(boladefogo, transform.position+ new Vector3(0,0,1), Quaternion.Euler(0, 0, 0));
            }
        }
        else
        {
            temposobrando = 0;
        }
    }
}
