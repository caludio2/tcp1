using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muv : MonoBehaviour
{
    public float vel,impulso,forcadopulo,lugar;
    public Rigidbody2D forca;
    public Transform player;
    public Vector3 lugardespawn;
    public GameObject mao;
    public bool segurando;
    public Image[] coracao;
    public int vidamaxima = 5;
    void Start()
    {
        forca = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D Col)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0,-0.1f,0), transform.TransformDirection(Vector2.down),0.1f);
        if(hit)
        {
            if(Col.gameObject.CompareTag("chao"))
            {
                impulso = 2;
            }        
        }
        if(Col.gameObject.CompareTag("save"))
            {
                    lugardespawn = player.position;
            }
        if(Col.gameObject.CompareTag("espinho"))
                {
                    vidamaxima = vidamaxima - 1;
                }
        if(Col.gameObject.CompareTag("caixa"))
        {
            segurando = true;
            mao = Col.gameObject;
        }
    }
     void FixedUpdate()
    {
        andar();
    }
    void Update()
    {
        PegarOuLargar();
        vida();
        pular();
        PegarOuLargar();
        Carregar();
    }
    void vida()
    {
        for(int i = 0; i < coracao.Length;i++)
        {
            if(i > vidamaxima)
            {
                coracao[i].enabled = false;
            }
            else
            {
                coracao[i].enabled = true;
            }
        }
    }
    void pular()
    {
        if(impulso > 0)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                forcadopulo = 11;
                forca.AddForce(new Vector3(0,forcadopulo,0),ForceMode2D.Impulse);
                impulso = impulso - 1;
                forcadopulo = 0;
            }
        }
    }
    void andar()
    {
            if(Input.GetKey(KeyCode.D))
            {
                forca.velocity = new Vector2(vel,forca.velocity.y);
                transform.rotation = Quaternion.Euler(0,180,0);
                lugar = 1.1f;
            }
            else
            {
                forca.velocity = new Vector2(0,forca.velocity.y);
            }
            if(Input.GetKey(KeyCode.A))
            {
                forca.velocity = new Vector2(-vel,forca.velocity.y);
                transform.rotation = Quaternion.Euler(0,0,0);
                lugar = -1.1f;
            }
    }
    void PegarOuLargar()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(segurando = true)
            {
                segurando = false;
                mao = null;
            }
        }
        
    }
    void Carregar()
    {
        if(segurando = true)
        {
            mao.transform.position = transform.position + new Vector3(lugar,0,0);
        }
    }
}
