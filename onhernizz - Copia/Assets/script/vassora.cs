using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vassoura : MonoBehaviour
{
    [SerializeField]private GameObject onda,espinho;
    private Transform player;
    private float tempo2,tempo;
    [SerializeField]private float tempomax,velronda;
    public float vel;
    [SerializeField]private bool atirar,fugir,seguir,ronda,seguirnochao,fugirnochao,espinhostiro;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        onda = GameObject.FindWithTag("tiro").GetComponent<GameObject>();
        espinho = GameObject.FindWithTag("chaodelama").GetComponent<GameObject>();
    }
    void Update()
    {
        if(seguir == true)
        {
            ir();
        }
        if(fugir == true)
        {
            vir();
        }
        if(atirar == true)
        {
            piupiu();
        }
        if(ronda == true)
        {
            senoide();
        }
        if(seguirnochao == true)
        {
            movimento();
        }
        if(fugirnochao == true)
        {
            otnemivom();
        }
        if(espinhostiro == true)
        {
            espinhos();
        }
    }
    void ir()
    {
        float distancia = Vector3.Distance(player.position, transform.position);
        if(distancia < 15)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.position,vel * Time.deltaTime);
            Vector2 lookDir = transform.position - player.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 180;
            transform.rotation = Quaternion.Euler(0,0,angle);
        }
    }
    void vir()
    {
        float distancia = Vector3.Distance(player.position, transform.position);
        if(distancia < 3)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.position,-vel*2 * Time.deltaTime);
        }
    }
    void piupiu()
    {
        float distancia = Vector3.Distance(player.position, transform.position);
        if(distancia < 15)
        {
            tempo = tempo + 1 * Time.deltaTime;
            if(tempo > tempomax)
            {
                Instantiate(onda,transform.position,Quaternion.Euler(0,0,0));
                tempo = 0;
            }
        }
    }
    void senoide()
    {
        tempo2 = tempo2 + 1 * Time.deltaTime;
        if(tempo2 < 0)
        {
            transform.position = transform.position + new Vector3(velronda / 1000,0,0);
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        if(tempo2 > 0)
        {
            transform.position = transform.position - new Vector3(velronda / 1000,0,0);
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        if(tempo2 > tempomax)
        {
            tempo2 = -tempomax;
        }
    }
    void movimento()
    {
        float distancia = Vector3.Distance(player.position, transform.position);
        if(distancia < 15)
        {
            if(player.position.x < transform.position.x)
            {
                transform.position = transform.position - new Vector3(vel / 1000,0,0);
            }
            if(player.position.x > transform.position.x)
            {
                transform.position = transform.position + new Vector3(vel / 1000,0,0);
            }
        }
    }
    void otnemivom()
    {
        float distancia = Vector3.Distance(player.position, transform.position);
        if(distancia < 15)
        {
            if(player.position.x < transform.position.x)
            {
                transform.position = transform.position + new Vector3(vel / 1000,0,0);
            }
            if(player.position.x > transform.position.x)
            {
                transform.position = transform.position - new Vector3(vel / 1000,0,0);
            }
        }
    }
    void espinhos()
    {
        float distancia = Vector3.Distance(player.position, transform.position);
        if(distancia < 7)
        {
            tempo = tempo + 1 * Time.deltaTime;
            if(tempo > tempomax)
            {
                Instantiate(espinho,transform.position,Quaternion.Euler(0,0,0));
                tempo = 0;
            }
        }
    }
}
