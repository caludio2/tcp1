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
    [SerializeField] int currentLife;
    [SerializeField] Transform lifePositionPivot;
    void Start()
    {
        UpdateLifeDisplay();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageble>(out IDamageble dm))
        {
            UpdateCurrentLife(dm.Damage);
            UpdateLifeDisplay();
        }
    }

    public void UpdateCurrentLife(int damage)
    {
        this.currentLife -= damage;
    }

    void UpdateLifeDisplay()
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
