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
    public GameObject mao,save1;
    bool segurando;
    public Image[] coracao;
    public bool naparde;
    public int vidamaxima = 6;
    public Camera Cam;
    Vector3 mousePos;
    public Collider2D playerCol,chaoCol;
    

    private void Start()
    {
        forca = GetComponent<Rigidbody2D>();
    }

    
    void OnCollisionEnter2D(Collision2D Col)
    {
        if(Col.gameObject.CompareTag("chao"))
        {
            impulso = 1;

        }     

        if(Col.gameObject.CompareTag("coin"))
        {
            Destroy(Col.gameObject);
        }

        if(Col.gameObject.CompareTag("ik"))
        {
            vidamaxima = vidamaxima - 5;
        }

        if(Col.gameObject.CompareTag("save"))
            {
                lugardespawn = player.position;
                impulso = 1;
                if(vidamaxima < 5)
                {
                    vidamaxima++;
                }
                coracao[0].enabled = true;
                coracao[1].enabled = true;
                coracao[2].enabled = true;
                coracao[3].enabled = true;
                coracao[4].enabled = true;
            }
        if(Col.gameObject.CompareTag("espinho"))
                {
                    vidamaxima = vidamaxima - 1;
                    coracao[vidamaxima].enabled = false;
                }
        if(Col.gameObject.CompareTag("caixa"))
        {
            impulso = 1;
            if(Input.GetKey(KeyCode.W))
            {
                segurando = true;
                mao = Col.gameObject;
            }
        }
    }
     void FixedUpdate()
    {
        andar();
    }
    void Update()
    {
        vida();
        PegarOuLargar();
        Carregar();
        pular();
    }
    void vida()
    {
        if(vidamaxima < 0)
        {
            transform.position = new Vector3(lugardespawn.x,lugardespawn.y,transform.position.z);
            vidamaxima = 5;
        }
    }
    void pular()
    {
        if(impulso == 1)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                forca.AddForce(new Vector3(0,forcadopulo,0),ForceMode2D.Impulse);
                impulso = impulso - 1;
                PlayerAnimator.Play(andando);
            }
        }
    }
    void andar()
    {
        if(Input.GetKey(KeyCode.D))
        {
            forca.velocity = new Vector2(vel,forca.velocity.y);
            transform.rotation = Quaternion.Euler(0,180,0);
            lugar = 1.7f;
        }
        else
        {
            forca.velocity = new Vector2(0,forca.velocity.y);
        }
        if(Input.GetKey(KeyCode.A))
        {
            forca.velocity = new Vector2(-vel,forca.velocity.y);
            transform.rotation = Quaternion.Euler(0,0,0);
            lugar = -1.7f;
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
}
