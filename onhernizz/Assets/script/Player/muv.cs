using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class muv : MonoBehaviour
{
    [Header("moviment settings")]
    [SerializeField] float vel, forcadopulo;

    [SerializeField] bool impulso;
    [SerializeField] LayerMask jumpable;

    [Header("moviment settings")]
    [SerializeField] float wallDetectionLength;
    [SerializeField] float floorDetectionLength;

    [Header("animation settings")]
    [SerializeField] GameObject particulaPulo;

    Animator playerAnim;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        andar();
        enableJumpDetection(Vector2.right , wallDetectionLength);
        enableJumpDetection(Vector2.left , wallDetectionLength);
        enableJumpDetection(Vector2.down , floorDetectionLength);
        pular();
    }

    void enableJumpDetection(Vector2 direction ,float rayLength)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 2, jumpable);

        // DEBUG VISUAL DO RAYCAST
        if (hit.collider != null)
            if (hit.distance < rayLength)
            {
                Debug.DrawRay(transform.position, direction * 2, Color.red);
                Debug.DrawRay(transform.position, direction * rayLength, Color.green);
                impulso = true;
            }
            else
            {
                Debug.DrawRay(transform.position, direction * 2, Color.red);
                Debug.DrawRay(transform.position, direction * rayLength, Color.red);
                impulso = false;
            }
    }

    void pular()
    {
        if (impulso)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, forcadopulo, 0), ForceMode2D.Impulse);
                impulso = false;
                playerAnim.SetBool("pulo", true);
                Instantiate(particulaPulo, transform.position, Quaternion.identity);
            }
        }
    }

    void andar()
    {
        float horisontalInput = Input.GetAxis("Horizontal");
        if (horisontalInput > 0)
        {
            rb.velocity = new Vector2(horisontalInput * vel, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerAnim.SetBool("andando", true);
        }
        if (horisontalInput < 0)
        {
            rb.velocity = new Vector2(horisontalInput * vel, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerAnim.SetBool("andando", true);
        }
        if (horisontalInput == 0)
        {
            playerAnim.SetBool("idle", false);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}