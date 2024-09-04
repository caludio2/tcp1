using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FANTASMASCRIPT : MonoBehaviour
{
    public int a;
    public Transform alvo1;
    public Transform alvo2;
    public Vector3 alvo;
    public float vel;

    void Start()
    {
        alvo = alvo2.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, alvo, vel * Time.deltaTime);
        if (transform.position == alvo1.position)
        {
            alvo = alvo2.position;
            a = 1;
        }

        if (transform.position == alvo2.position)
        {
            alvo = alvo1.position;
            a = 0;
        }
        if (a == 1)
        {
            alvo = alvo2.position;
        }
        if (a == 0)
        {
            alvo = alvo1.position;
        }
    }
}
