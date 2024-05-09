using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapllinggun : MonoBehaviour
{
    public LineRenderer rope;
    private Vector3 pointGrapler;
    private DistanceJoint2D joint;
    public LayerMask layer;
    public float praplleDistance;
    public float Distancia;

    void Start()
    {
        joint = gameObject.GetComponent<DistanceJoint2D>();
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
            if(Distancia < 1000)
            {
                if(hit.collider != null)
                {
                    pointGrapler = hit.point;
                    pointGrapler.z = 0;
                    joint.connectedAnchor = pointGrapler;
                    joint.enabled = true;
                    //joint.distance = praplleDistance;
                    rope.enabled = true;

                    rope.SetPosition(0,pointGrapler);
                    rope.SetPosition(1,transform.position);
                }
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            joint.enabled = false;
            rope.enabled = false;
        }
        if(rope.enabled == true)
        {
            rope.SetPosition(1,transform.position);
        }
    }
}
