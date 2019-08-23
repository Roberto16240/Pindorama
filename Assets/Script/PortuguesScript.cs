using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortuguesScript : MonoBehaviour
{
    public float vida, vel;
    private bool podeAndar, podeAtacar;
    private Rigidbody2D rb;

    void Start()
    {
        podeAtacar = true;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckIndio();
        CheckDeath();
    }
    void FixedUpdate()
    {
        rb.velocity = podeAndar ? new Vector2(-vel * Time.deltaTime, 0) : Vector2.zero;
    }
    void CheckDeath()
    {
        if (vida<= 0)
        {
            Destroy(gameObject);
        }
    }
    void CheckIndio()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.right, 0.3f, LayerMask.GetMask("Índios"));
        if (hit.collider != null)
        {
            podeAndar = false;
            if (podeAtacar)
            {
                StartCoroutine(Atacando(hit.collider));

            }
        }
        else
        {
            podeAndar = true;
            StopCoroutine("Atacando");
        }
    }
    IEnumerator Atacando(Collider2D col)
    {
        podeAtacar = false;
        yield return new WaitForSeconds(2);
        podeAtacar = true;
        if (col != null)
        {
            col.gameObject.GetComponent<Propriedades>().vida--;
        }
    }
}
