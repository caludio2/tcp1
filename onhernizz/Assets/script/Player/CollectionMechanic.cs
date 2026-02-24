using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionMechanic : MonoBehaviour
{
    public float radius = 5f;
    public string collectibleTag = "Collectible"; // Tag dos objetos que podem ser pegos

    GameObject inventario;
    public Vector3 offSet;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject target = GetClosest();
            if (target != null)
            {
                inventario = target;
                target.SetActive(false);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (inventario != null)
            {
                inventario.SetActive(true);
                inventario.transform.position = transform.position + offSet;
                inventario = null;
            }
        }
    }

    GameObject GetClosest()
    {
        // Pega todos os colliders na cena dentro do raio
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);
        GameObject closest = null;
        float minDistance = Mathf.Infinity;

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag(collectibleTag))
            {
                float dist = Vector3.Distance(transform.position, hit.transform.position);
                if (dist < minDistance)
                {
                    closest = hit.gameObject;
                    minDistance = dist;
                }
            }
        }

        return closest;
    }

    void OnDrawGizmos()
    {
        // Raio do círculo
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);

        // Objeto mais próximo
        GameObject closest = GetClosest();
        if (closest != null)
        {
            Gizmos.color = Color.red;
            Vector3 size = closest.GetComponent<Renderer>()?.bounds.size ?? Vector3.one;
            Gizmos.DrawWireCube(closest.transform.position, size);

            // Linha até o jogador
            Gizmos.DrawLine(transform.position, closest.transform.position);
        }
    }
}