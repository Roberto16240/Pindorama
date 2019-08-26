using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaScript : MonoBehaviour
{
    public float vel, danoHit;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(vel * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("Portugues"))
        {
            col.gameObject.GetComponent<PortuguesScript>().vida -= danoHit;
            Destroy(gameObject);
        }
    }
}
