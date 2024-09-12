using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MORCEGOSCRIPT : MonoBehaviour
{
    public Transform idlepoint;
    public Transform player;
    public float speed;
    public GameObject morcego;
    public Animator morguesoAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        float distancia = Vector3.Distance(player.position, idlepoint.position);
        if (distancia < 10)
        {
            Debug.Log(distancia);
            player = GameObject.Find("player").transform;
            transform.position = Vector3.MoveTowards(transform.position, player.position, 2 * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, idlepoint.position,8 * Time.deltaTime);
        }
        if(new Vector3(transform.position.x, transform.position.y, 0) == new Vector3(idlepoint.position.x, idlepoint.position.y,0))
        {
            morguesoAnim.SetBool("voando", true);
            Debug.Log(" voa");
        }
        else
        {
            Debug.Log("parou");
            morguesoAnim.SetBool("voando", false);
        }
    }
}
