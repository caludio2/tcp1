using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class passagemdosslides : MonoBehaviour
{
    public float tempo,tempoentreosslides;
    public GameObject[] paineis;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempo += 1 * Time.deltaTime;
        if(tempo > tempoentreosslides)
        {
            i += 1;
            tempo = 0;
            Destroy(paineis[i - 1]);
        }
        if (i == 5)
        {
            SceneManager.LoadScene("menu");
        }
    }
}
