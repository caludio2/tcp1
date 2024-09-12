using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class muv : MonoBehaviour
{
    public float vel,impulso,forcadopulo,lugar,range,i;
    public Rigidbody2D forca;
    Vector3 lugardespawn;
    public GameObject mao,particulapulo,particulamoeda, particularastro;
    bool segurando;
    public Image[] coracao;
    public Image quit,play;
    public bool naparde;
    public int vidamaxima = 6;
    public Camera Cam;
    Vector3 mousePos;
    public Collider2D playerCol,chaoCol;
    public Animator playerAnim;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;
    public int moeda,vagalume;
    public Transform mapa2;

    private void Start()
    {
        forca = GetComponent<Rigidbody2D>();
        coracao[0].enabled = false;
        coracao[1].enabled = false;
        coracao[2].enabled = false;
        coracao[3].enabled = false;
        coracao[4].enabled = false;
        text2.text = vagalume + "/4 vagalumes";
        text.text = "Score:   :" + moeda;
    }

    void OnTriggerEnter2D(Collider2D zol)
    {
        if (zol.gameObject.CompareTag("coin"))
        {
            moeda += 1;
            Destroy(zol.gameObject);
            Instantiate(particulamoeda, transform.position, Quaternion.identity);
            text.text = "Score:   :" + moeda;
        }
        if (zol.gameObject.CompareTag("coletavel"))
        {
            vagalume += 1;
            Destroy(zol.gameObject);
            Instantiate(particulamoeda, transform.position, Quaternion.identity);
            text2.text = vagalume + "/4 vagalumes";
        }
        if (zol.gameObject.CompareTag("janela"))
        {
            transform.position = new Vector3(mapa2.position.x, mapa2.position.y,0);
        }
    }
    void OnCollisionEnter2D(Collision2D Col)
    {
        if(Col.gameObject.CompareTag("chao"))
        {
            impulso = 1;
            vel = 8;
        }
       

         
        


            if (Col.gameObject.CompareTag("ik"))
        {
            vidamaxima = vidamaxima - 5;
        }

        if(Col.gameObject.CompareTag("save"))
            {
                lugardespawn = transform.position;
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
            quit.enabled = false;
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
    void OnCollisionExit2D(Collision2D dol)
    {
        if (dol.gameObject.CompareTag("chao"))
        {
            forca.gravityScale = 2;
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
                Instantiate(particulapulo,transform.position,Quaternion.identity);
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
                Instantiate(particularastro,transform.position,Quaternion.identity);
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
            lugar = 2f;
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
            lugar = -2f;
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
