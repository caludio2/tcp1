using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [Serializable]
    public class TransformData
    {
        public bool exists;

        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;

        // Rigidbody
        public bool hasRigidbody;
        public bool isKinematic;
        public bool useGravity;
        public Vector3 velocity;
        public Vector3 angularVelocity;
        public RigidbodyConstraints constraints;
    }

    [Serializable]
    public class UIData
    {
        public int amount;
    }

    [Serializable]
    public class SaveData
    {
        public List<TransformData> transforms = new List<TransformData>();
        public List<UIData> UI = new List<UIData>();
    }

    [Header("Referências")]
    [SerializeField] private List<Transform> objectsToSave = new List<Transform>();
    [SerializeField] private GetingSystem gettingSystems;
    [SerializeField] private PlayerLife playerLife;

    private string SavePath => Path.Combine(Application.persistentDataPath, "save.json");

    public void Save()
    {
        var data = new SaveData();

        foreach (Transform target in objectsToSave)
        {
            if (target == null)
            {
                data.transforms.Add(new TransformData { exists = false });
                continue;
            }

            Rigidbody rb = target.GetComponent<Rigidbody>();

            var transformData = new TransformData
            {
                exists = target.gameObject.activeSelf,
                position = target.position,
                rotation = target.rotation,
                scale = target.localScale,
                hasRigidbody = rb != null
            };

            if (rb != null)
            {
                transformData.isKinematic = rb.isKinematic;
                transformData.useGravity = rb.useGravity;
                transformData.velocity = rb.velocity;
                transformData.angularVelocity = rb.angularVelocity;
                transformData.constraints = rb.constraints;
            }

            data.transforms.Add(transformData);
        }

        // UI Data
        data.UI.Add(new UIData { amount = gettingSystems.moeda });
        data.UI.Add(new UIData { amount = playerLife.currentLife });
        data.UI.Add(new UIData { amount = gettingSystems.vagalume });

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SavePath, json);

        Debug.Log($"Jogo salvo em: {SavePath}");
    }

    public void Load()
    {
        if (!File.Exists(SavePath))
        {
            Debug.Log("Nenhum save encontrado.");
            return;
        }

        string json = File.ReadAllText(SavePath);
        var data = JsonUtility.FromJson<SaveData>(json);

        int count = Mathf.Min(objectsToSave.Count, data.transforms.Count);

        for (int i = 0; i < count; i++)
        {
            Transform target = objectsToSave[i];
            if (target == null) continue;

            TransformData saved = data.transforms[i];

            target.gameObject.SetActive(saved.exists);
            target.position = saved.position;
            target.rotation = saved.rotation;
            target.localScale = saved.scale;

            if (saved.hasRigidbody)
            {
                Rigidbody rb = target.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = saved.isKinematic;
                    rb.useGravity = saved.useGravity;
                    rb.constraints = saved.constraints;
                    rb.velocity = saved.velocity;
                    rb.angularVelocity = saved.angularVelocity;
                }
            }
        }

        // Restaurar UI
        if (data.UI.Count >= 3)
        {
            gettingSystems.moeda = data.UI[0].amount;
            playerLife.currentLife = data.UI[1].amount;
            gettingSystems.vagalume = data.UI[2].amount;

            gettingSystems.UpdateText();
            playerLife.UpdateLifeDisplay();
        }

        Debug.Log("Jogo carregado.");
    }
}
