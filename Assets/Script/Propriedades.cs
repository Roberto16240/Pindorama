using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propriedades : MonoBehaviour
{
    public int vida, preço, tempo;
    void Update()
    {
        CheckDeath(); 
    }
    void CheckDeath()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
