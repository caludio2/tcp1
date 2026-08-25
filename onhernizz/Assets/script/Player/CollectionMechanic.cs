using UnityEngine;

public class CollectionMechanic2D : MonoBehaviour
{
    public float radius = 5f;
    public string collectibleTag = "coletavel";
    private GameObject inventario;
    public Vector3 offSet;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject target = GetClosest();
            if (target != null)
            {
                Debug.Log("Peguei: " + target.name);
                inventario = target;
                inventario.SetActive(false);
            }
            else
            {
                Debug.Log("Nenhum objeto próximo!");
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (inventario != null)
            {
                Debug.Log("Soltei: " + inventario.name);
                inventario.SetActive(true);
                inventario.transform.position = transform.position + offSet;
                inventario = null;
            }
        }
    }

    GameObject GetClosest()
    {
        // Usa OverlapCircle para 2D
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

        GameObject closest = null;
        float minDistance = Mathf.Infinity;

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag(collectibleTag))
            {
                float dist = Vector2.Distance(transform.position, hit.transform.position);
                if (dist < minDistance)
                {
                    closest = hit.gameObject;
                    minDistance = dist;
                }
            }
        }

        return closest;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
