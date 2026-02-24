using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinhos : MonoBehaviour , IDamageble
{
    [SerializeField] private int damage;

    public int Damage => damage;
}
