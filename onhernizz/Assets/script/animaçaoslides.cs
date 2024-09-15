using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class animaçaoslides : MonoBehaviour
{
    public float tempo, tempoentreosslides;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempo += 1 * Time.deltaTime;
        if (tempo > tempoentreosslides)
        {
            transform.rotation = Quaternion.Euler(0,0,Random.Range(-2,1));
            tempo = 0;
        }
    }
}
