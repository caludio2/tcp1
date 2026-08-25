using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetingSystem : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;

    public int moeda, vagalume;

    public void Start()
    {
        UpdateText();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            moeda += 1;
            ColectFeedBack(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("coletavel"))
        {
            vagalume += 1;
            ColectFeedBack(collision.gameObject);
        }
    }

    public void ColectFeedBack(GameObject collisionGO)
    {
        collisionGO.SetActive(false);
        UpdateText();
    }
    public void UpdateText()
    {
        text2.text = vagalume + "/4 vagalumes";
        text.text = "Score:   :" + moeda;
    }
}
