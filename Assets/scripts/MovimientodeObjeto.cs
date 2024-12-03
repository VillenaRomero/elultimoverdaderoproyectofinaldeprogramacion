using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientodeObjeto : MonoBehaviour
{
    private Rigidbody2D rigibody2d;
    public float speedy;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Awake()
    {
        rigibody2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rigibody2d.velocity = new Vector2(0, speedy);
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bala")
        {
            Destroy(this.gameObject);
        }
    }
}
