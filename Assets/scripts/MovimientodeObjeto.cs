using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientodeObjeto : MonoBehaviour
{
    private Rigidbody2D rigibody2d;
    public float speedx;
    public float speedy;
    public string nametag;

    private void Awake()
    {
        rigibody2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rigibody2d.velocity = new Vector2(speedx, speedy);
    }
    public void OnCollisionEnter2D(Collision collision)
    {
        if (collision.gameObject.tag == nametag)
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "vacio")
        {
            Destroy(this.gameObject);
        }
    }
}

