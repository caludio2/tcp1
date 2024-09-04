using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapllinggun : MonoBehaviour
{
    public LineRenderer rope;
    private Vector3 pointGrapler;
    public DistanceJoint2D joint;
    public LayerMask layer;
    public float praplleDistance;
    public float Distancia;
    public Animator playerAnim;
    public Rigidbody2D rb;

    void Start()
    {
        joint.enabled = false;
        rope.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(origin: Camera.main.ScreenToWorldPoint(Input.mousePosition),direction:Vector2.zero,distance: Mathf.Infinity,layerMask: layer);
            Distancia = Vector2.Distance(hit.point,transform.position);
                if(hit.collider != null)
                {
                    pointGrapler = hit.point;
                    pointGrapler.z = 0;
                    joint.enabled = true;
                    joint.connectedAnchor = pointGrapler;
                    
                    rope.enabled = true;
                    rope.SetPosition(0,pointGrapler);
                    rope.SetPosition(1, transform.position);
                }
            
        }
        if(Input.GetMouseButtonUp(0))
        {
            joint.enabled = false;
            rope.enabled = false;
        }
        if(rope.enabled == true)
        {
            rope.SetPosition(0, pointGrapler);
            rope.SetPosition(1, transform.position);
            joint.connectedAnchor = pointGrapler;
        }
    }
}
