using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientodenaveenemiga : MonoBehaviour
{
    public int life = 3;
    private Rigidbody2D rigibody2d;
    public float speedx;
    public float speedy;

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

        if (collision.gameObject.tag == "Bala")
        {
            life--;
            if (life < 0)
            {
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.tag == "jugador")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "vacio")
        {
            Destroy(this.gameObject);
        }
    }
}
