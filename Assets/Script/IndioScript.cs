using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndioScript : MonoBehaviour
{
    public GameObject prefabFlecha;
    private float distance;
    void Start()
    {
        InvokeRepeating("Atirar", 0, 1);
        distance = 5.61f - transform.position.x;
    }
    void Atirar()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, distance, LayerMask.GetMask("Portugueses"));
        if (hit.collider != null)
        {
            Instantiate(prefabFlecha, transform.position, Quaternion.identity);
        }
    }

}
