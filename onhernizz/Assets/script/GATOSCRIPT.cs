using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GATOSCRIPT : MonoBehaviour
{
    public int a;
    public Transform alvo1;
    public Transform alvo2;
    public Vector3 alvo;
    public Transform player;
    public float vel;
    public float disalvo2;
    void Start()
    {
        alvo = alvo2.position;
    }

    // Update is called once per frame
    void Update()
    {
        disalvo2 = Vector3.Distance(player.position, alvo2.position);
        if (disalvo2 < 10)
        {
            transform.position = Vector3.MoveTowards(transform.position, alvo2.position, vel * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, alvo1.position, vel * Time.deltaTime);
        }
    }
}
