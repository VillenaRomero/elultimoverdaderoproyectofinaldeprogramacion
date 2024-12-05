using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jefefinal : herenciadevelocidad
{
    public int life;
    private Rigidbody rigibody;
    private Transform comTransform;
    public float speed;

    public GameObject prefabBullet;
    public GameObject PrefabMisiles;

    public float timeTiCreate = 5;
    public float currentTimetuCreate;

    public float timeTibalagigante = 15;
    public float currentTimetuCreate2;

    public Transform spawner1;
    public Transform spawner2;
    public Transform spawner3;
    public Transform spawner4;

    public Transform cañongiagnte;
    public Transform cañongiagnte2;

    public naveprincipal player;
    // Start is called before the first frame update
    void Start()
    {
        rigibody = GetComponent<Rigidbody>();
        comTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTimetuCreate = currentTimetuCreate + Time.deltaTime;
        if (currentTimetuCreate >= timeTiCreate)
        {
            ShootBullet1();
            ShootBullet2();
            ShootBullet3();
            ShootBullet4();

            currentTimetuCreate = 0;
        }
        currentTimetuCreate2 = currentTimetuCreate2 + Time.deltaTime;
        if (currentTimetuCreate2 >= timeTibalagigante)
        {
            balagiggante();
            BalaGigante2();
            currentTimetuCreate2 = 0;
        }
    }
    private void ShootBullet1()
    {
        GameObject bullet = Instantiate(prefabBullet);
        bullet.transform.position = spawner1.position;
        bullet.transform.rotation = transform.rotation;
    }
    private void ShootBullet2()
    {
        GameObject bullet = Instantiate(prefabBullet);
        bullet.transform.position = spawner2.position;
        bullet.transform.rotation = transform.rotation;
    }
    private void ShootBullet3()
    {
        GameObject bullet = Instantiate(prefabBullet);
        bullet.transform.position = spawner3.position;
        bullet.transform.rotation = transform.rotation;
    }
    private void ShootBullet4()
    {
        GameObject bullet = Instantiate(prefabBullet);
        bullet.transform.position = spawner4.position;
        bullet.transform.rotation = transform.rotation;
    }

    private void balagiggante() { 
        GameObject bullet = Instantiate(PrefabMisiles);
        bullet.transform.position = cañongiagnte.position;
        bullet.transform.rotation = transform.rotation;
    }
    private void BalaGigante2()
    {
        GameObject bullet = Instantiate(PrefabMisiles);
        bullet.transform.position = cañongiagnte2.position;
        bullet.transform.rotation = transform.rotation;
    }

    void FixedUpdate()
    {
        comTransform.position = new Vector3(comTransform.position.x + speed * speedx * Time.deltaTime, comTransform.position.y + speed * speedy * Time.deltaTime);
        if (comTransform.position.x >= 8)
        {
            speedx = -1;
        }
        else if (comTransform.position.x <= -8)
        {
            speedx = 1;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            life--;
            if (life < 0)
            {
                Destroy(this.gameObject);
                player.OnEnemyDestroyed();
            }
        }
    }
}
