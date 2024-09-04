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
    void Start()
    {
        alvo = alvo2.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, alvo, vel * Time.deltaTime);
        float disalvo1 = Vector3.Distance(player.position, alvo2.position);
        if (disalvo1 < 1)
        {
            alvo = alvo2.position;
        }
        else
        {
            alvo = alvo1.position;
        }
    }
}
