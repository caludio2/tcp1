using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapler : MonoBehaviour
{
    public Camera Cam;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 mousePos = Cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Rigidbody2D forca = GetComponent<Rigidbody2D>();
        forca.AddForce(mousePos,ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collision2D Col)
    {
        Destroy(this.gameObject);
    }
}
