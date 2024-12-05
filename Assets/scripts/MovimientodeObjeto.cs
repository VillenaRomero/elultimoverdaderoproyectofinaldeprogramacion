using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientodeObjeto : herenciadevelocidad
{
    private Rigidbody2D rigibody2d;
    public string nametag;

    private void Awake()
    {
        rigibody2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rigibody2d.velocity = new Vector2(speedx, speedy);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == nametag)
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "vacio")
        {
            Destroy(this.gameObject);
        }
    }
}

