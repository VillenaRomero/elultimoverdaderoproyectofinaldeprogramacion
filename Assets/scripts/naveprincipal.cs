using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class naveprincipal : MonoBehaviour
{
    public int life;
    public float speedx;
    public float speedy;
    private Rigidbody2D _compRigidbody2D;
    public Transform spawner;
    public GameObject bulletprefab;

    public float timeTiCreate = 30;
    public float currentTimetuCreate;

    public string nivel;
    void Start()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject bullet = Instantiate(bulletprefab);
            bullet.transform.position = spawner.position;
            bullet.transform.rotation = transform.rotation;
        }
        currentTimetuCreate = currentTimetuCreate + Time.deltaTime;
        if (currentTimetuCreate >= timeTiCreate)
        {
            SceneManager.LoadScene(nivel);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _compRigidbody2D.velocity = new Vector2(speedx * horizontal, speedy * vertical);


        /*if (puntos == 320)
        {
            SceneManager.LoadScene("nivel2");
        }*/
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemigo")
        {
            life--;

            if (life < 0)
            {
                SceneManager.LoadScene("derrota");
            }
        }
    }
}