using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour
{
    public GameObject Cameraplayer;
    public float speedparalax,lugarinicial;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = (Cameraplayer.transform.position.x * (speedparalax));

        transform.position = new Vector3(dist - lugarinicial,transform.position.y, transform.position.z);
    }
}
