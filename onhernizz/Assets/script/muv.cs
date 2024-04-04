using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muv : MonoBehaviour
{
    public float vel,velnalama,impulso,forcadopulo,zdacamera;
    public Rigidbody2D forca,Fcaixa;
    public Transform Camera,player;
    public Vector3 lugardespawn;
    public Camera cam;
    public Transform grab;


    public GameObject barravermelha;
    public float vida = 1;
    //precionar tecla = mover pra direcao desejada
    // Start is called before the first frame update
    void Start()
    {
        forca = GetComponent<Rigidbody2D>();
        Fcaixa = GetComponent<Rigidbody2D>();
    }




    
    //
    void OnCollisionEnter2D(Collision2D Col)
    {
        RaycastHit2D chao2 = Physics2D.Raycast(transform.position + new Vector3(0,-1f,0), transform.TransformDirection(Vector2.down),0.1f);
        if(chao2)
        {
            if(Col.gameObject.CompareTag("chao"))
            {
                impulso = 2;
            }        
        }
        
            if(Col.gameObject.CompareTag("caixa"))
            {
                vida = vida + 0.5f;
            }

            if(Col.gameObject.CompareTag("save"))
            {
                    Debug.Log("salvou");
                    lugardespawn = player.position;
                    player.localScale = new Vector3(1,1,1);
            }

                if(Col.gameObject.CompareTag("espinho"))
                {
                    player.position = lugardespawn;
                }   
    }
    
    
        




    //movimentacao no eixo x
     void FixedUpdate()
    {
        if(forcadopulo == 0)
        {
        
            if(Input.GetKey(KeyCode.D))
            {
                transform.position = transform.position + new Vector3(vel,0,0);
                transform.rotation = Quaternion.Euler(0,0,0);
            }
            if(Input.GetKey(KeyCode.A))
            {
                transform.position = transform.position + new Vector3(-vel,0,0);
                transform.rotation = Quaternion.Euler(0,180,0);
            }
        RaycastHit2D parede = Physics2D.Raycast(transform.position + new Vector3(-1,0,0), transform.TransformDirection(180,0,0),0.5f);
        if(parede)
        {   
              
                forca.AddForce(new Vector3(-forcadopulo,0,0),ForceMode2D.Impulse);
        }
        RaycastHit2D parede2 = Physics2D.Raycast(transform.position + new Vector3(1,0,0), transform.TransformDirection(0,0,0),0.5f);
        if(parede2)
        {   
            Debug.Log("colidiu");
           
                forca.AddForce(new Vector3(forcadopulo,0,0),ForceMode2D.Impulse);
        }
        }

        //passa as coordenadas do mouse
        
    }







    //movimentacao no eixo y
    void Update()
    {
        barravermelha.transform.localScale = new Vector3(vida,1,0);
        if(Input.GetKeyDown(KeyCode.A))
        {
            vida = vida - 0.1f;
            
        }
        if(vida > 1)
        {
            vida = 1;
        }
        if(vida < 0)
        {
            vida = 0;
        }


        if(impulso > 0)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                forcadopulo = 11;
                forca.AddForce(new Vector3(0,forcadopulo,0),ForceMode2D.Impulse);
                impulso = impulso - 1;
                forcadopulo = 0;
                StartCoroutine(espera());
            }
        }
        if(impulso > 0)
        {
            if(Input.GetKey(KeyCode.Space) && forcadopulo < 15)
            {
                forcadopulo = forcadopulo + 0.1f;
                player.localScale = new Vector3(1 ,1 - forcadopulo / 80,1 );
            }
            if(Input.GetKeyUp(KeyCode.Space))
            {
                forca.AddForce(new Vector3(0,forcadopulo,0),ForceMode2D.Impulse);
                impulso = impulso - 1;
                //forcadopulo = 0;
                StartCoroutine(espera());
            }
        }




        Camera.position = player.position + new Vector3(0,0,zdacamera);
        
            if(Input.GetKeyDown(KeyCode.S))
            {
                player.localScale = new Vector3(1f ,0.7f ,1);
                vel = 0.05f;
                forca.AddForce(new Vector3(0,-forcadopulo * 2,0),ForceMode2D.Impulse);
            }
            if(Input.GetKeyUp(KeyCode.S))
            {
                StartCoroutine(espera());
            }
        







    }
    IEnumerator espera()
    {
        yield return new WaitForSeconds(0.3f);
        player.localScale = new Vector3(1 ,1 ,1 );
    }
}
