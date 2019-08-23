using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoInstantiate : MonoBehaviour
{
    public GameObject prefabChao;
    private GameObject chao;
    private float currentX = -5.46f, currentY = 2.759f, distanceX, distanceY;
    private bool newLine = true;

    void Start()
    {
        distanceX = prefabChao.GetComponent<SpriteRenderer>().bounds.size.x;
        distanceY = prefabChao.GetComponent<SpriteRenderer>().bounds.size.y;

        for (int i = 0; i < 45; i++)
        {
            if (i % 9 == 0 && i != 0)
            {
                newLine = true;
                currentY = chao.transform.position.y - distanceX;
            }
            if (newLine)
            {
                newLine = false;
                chao = Instantiate(prefabChao, new Vector2(-5.46f, currentY), Quaternion.identity) as GameObject;
            }
            else
            {
                chao = Instantiate(prefabChao, new Vector2(currentX, currentY), Quaternion.identity) as GameObject;
            }
            currentX = chao.transform.position.x + distanceX;
            chao.transform.SetParent(transform);
        }

    }
}
