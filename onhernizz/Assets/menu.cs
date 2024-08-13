using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public GameObject save1;
    public GameObject player;
    public bool play;
    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        if(play = true)
        {
            player.SetActive(true);
        }
        play = true;
        player.transform.position = save1.transform.position;
    }
}
