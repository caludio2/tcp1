using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muv : MonoBehaviour
{
    public float vel,impulso,forcadopulo,lugar,range,i;
    public Rigidbody2D forca;
    public Transform player;
    Vector3 lugardespawn;
    public GameObject mao,save1,particulafoda,particulafoda2,particulafoda3,particulafoda4;
    bool segurando;
    public Image[] coracao;
    public bool naparde;
    public int vidamaxima = 6;
    public Camera Cam;
    Vector3 mousePos;
    public Collider2D playerCol,chaoCol;
    public Animator playerAnim;


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
        if (Col.gameObject.CompareTag("caldeirao"))
        {
            forca.AddForce(new Vector3(0, forcadopulo, 0), ForceMode2D.Impulse);
        }
        


        if (Col.gameObject.CompareTag("ik"))
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
    void OnTriggerEnter2D(Collider2D zol)
    {
        if(zol.gameObject.CompareTag("coin"))
        {
            Destroy(zol.gameObject);
            Instantiate(particulafoda3,transform.position,Quaternion.identity);
        }
        if (zol.gameObject.CompareTag("agua"))
        {
            Instantiate(particulafoda4, transform.position, Quaternion.identity);
        }
    }
     void FixedUpdate()
    {
       
        
    }
    void Update()
    {
        andar();
        vida();
        PegarOuLargar();
        Carregar();
        pular();
    }
    void vida()
    {
        if(vidamaxima <= 0)
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
                playerAnim.SetBool("pulo",true);
                Instantiate(particulafoda,transform.position,Quaternion.identity);
            }
            else
            {
                playerAnim.SetBool("pulo",false);
            }
        }
        if(impulso == 0)
        {
            playerAnim.SetBool("andando",false);
            i = i + 1 * Time.deltaTime;
            if(i >= 0.3)
            {
            Instantiate(particulafoda2,transform.position,Quaternion.identity);
            i = 0;
            }
        }
    }
    void andar()
    {
        if(Input.GetKey(KeyCode.D))
        {
            forca.velocity = new Vector2(vel,forca.velocity.y);
            transform.rotation = Quaternion.Euler(0,0,0);
            lugar = 1.7f;
            playerAnim.SetBool("andando",true);
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetBool("andando",false);
            forca.velocity = new Vector2(0,forca.velocity.y);
        }

        
        if(Input.GetKey(KeyCode.A))
        {
            forca.velocity = new Vector2(-vel,forca.velocity.y);
            transform.rotation = Quaternion.Euler(0,180,0);
            lugar = -1.7f;
            playerAnim.SetBool("andando",true);
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            playerAnim.SetBool("andando",false);
            forca.velocity = new Vector2(0,forca.velocity.y);
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
