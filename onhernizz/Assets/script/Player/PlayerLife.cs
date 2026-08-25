using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] GameObject hearthDisplay;
    GameObject[] herthList;
    [SerializeField] int maxLife;
    [SerializeField] public int currentLife;
    [SerializeField] Transform lifePositionPivot;

    [SerializeField] SaveManager saveManager;
    void Start()
    {
        UpdateLifeDisplay();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto está na layer "Inimigo"
        if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            if (collision.gameObject.TryGetComponent<IDamageble>(out IDamageble dm))
            {
                UpdateCurrentLife(dm.Damage);
                UpdateLifeDisplay();
            }

            // Adiciona força oposta à direção da colisão
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null && collision.contacts.Length > 0)
            {
                // Pega o ponto de contato
                Vector2 collisionPoint = collision.contacts[0].point;

                // Direção contrária ao impacto
                Vector2 direction = (transform.position - (Vector3)collisionPoint).normalized;

                // Aplica força
                float forceMagnitude = 10; // ajuste conforme necessário
                rb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);
            }
        }
    }



    public void UpdateCurrentLife(int damage)
    {
        this.currentLife -= damage;
    }

    public void UpdateLifeDisplay()
    {
        foreach (Transform child in lifePositionPivot)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < currentLife; i++)
        {
            GameObject heart = Instantiate(hearthDisplay, lifePositionPivot);

            // Ajusta posição horizontal
            RectTransform rt = heart.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(i * 80, 0);
        }

        if(currentLife <= 0)
        {
            saveManager.Load();
        }
    }

}
