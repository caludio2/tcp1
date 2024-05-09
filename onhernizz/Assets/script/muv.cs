using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muv : MonoBehaviour
{
    public float vel,impulso,forcadopulo,lugar,range;
    public Rigidbody2D forca;
    public Transform player;
    Vector3 lugardespawn;
    GameObject mao;
    bool segurando;
    public Image[] coracao;
    public bool naparde;
    public int vidamaxima = 5;
    public Camera Cam;
    Vector3 mousePos;
    public Collider2D playerCol,chaoCol;




    
    void OnCollisionEnter2D(Collision2D Col)
    {
        if(Col.gameObject.CompareTag("chao"))
        {
            impulso = 1;
        }     



        if(Col.gameObject.CompareTag("parede"))
        {
            naparde = true;
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
    void OnCollisionExit2D(Collision2D col)
    {
         if(col.gameObject.CompareTag("parede"))
        {
            naparde = false;
        }  
    }
     void FixedUpdate()
    {
        andar();
    }
    void Update()
    {
        parede();
        parede();
        vida();
        PegarOuLargar();
        Carregar();
        pular();
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
                //coracao[i].enabled = true;
            }
        }
    }
    void pular()
    {
        if(impulso > 0)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                forca.AddForce(new Vector3(0,forcadopulo,0),ForceMode2D.Impulse);
                impulso = impulso - 1;
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
            if(segurando == true)
            {
                segurando = false;
                mao = null;
            }
        }
    }
    void Carregar()
    {
        if(segurando == true)
        {
            mao.transform.position = transform.position + new Vector3(lugar,0,0);
        }
    }
    void parede()
    {
        if(naparde == true)
        {
            //forca.useGravity2D = false;
        }
        if(naparde == false)
        {
            //forca.useGravity2D = true;
        }
    }
    void Start()
    {
        forca = GetComponent<Rigidbody2D>();
    }
}
