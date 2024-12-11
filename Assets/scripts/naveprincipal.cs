using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class naveprincipal : herenciadevelocidad
{
    public int life;
    private Rigidbody2D _compRigidbody2D;
    public Transform spawner;
    public GameObject bulletprefab;

    public float timeTiCreate = 30;
    public float currentTimetuCreate;

    public float recoveryTime = 5f;
    public float currentRecoveryTime = 0f;

    private bool canRecoverLife = true;

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
        currentRecoveryTime +=  Time.deltaTime;
        if (currentTimetuCreate >= timeTiCreate)
        {
            SceneManager.LoadScene(nivel);
        }

        if (currentRecoveryTime >= recoveryTime && canRecoverLife)
        {
            this.life += 1; 
            canRecoverLife = false; 
        }

        if (currentRecoveryTime >= recoveryTime)
        {
            currentRecoveryTime = 0f;
            canRecoverLife = true;
        }
    }
    public void OnEnemyDestroyed()
    {
        SceneManager.LoadScene(nivel);
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _compRigidbody2D.velocity = new Vector2(speedx * horizontal, speedy * vertical);
    }
    public static naveprincipal operator +(naveprincipal player, int amount)
    {
        player.life += amount;
        return player; 
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