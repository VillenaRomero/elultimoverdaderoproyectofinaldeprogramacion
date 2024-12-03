using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientodesubjefe : MonoBehaviour
{
    private Rigidbody rigibody;
    private Transform comTransform;
    public float speed;
    public float xDirection = 1;
    public float yDirection = 1;

    public GameObject prefabBullet;
    public GameObject PrefabMisiles;

    public float timeTiCreate = 5;
    public float currentTimetuCreate;

    public float timeTibalagigante = 15;
    public float currentTimetuCreate2;

    public Transform spawner1;
    public Transform spawner2;

    public Transform cañongiagnte;
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

            currentTimetuCreate = 0;
        }
        currentTimetuCreate2 = currentTimetuCreate2 + Time.deltaTime;
        if (currentTimetuCreate2 >= timeTiCreate)
        {
            BalaGigante();
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

    private void BalaGigante()
    {
        GameObject bullet = Instantiate(PrefabMisiles);
        bullet.transform.position = cañongiagnte.position;
        bullet.transform.rotation = transform.rotation;
    }
    void FixedUpdate()
    {
        comTransform.position = new Vector3(comTransform.position.x + speed * xDirection * Time.deltaTime, comTransform.position.y + speed * yDirection * Time.deltaTime);
        if (comTransform.position.y >= 1.34)
        {
            yDirection = -1;
        }
        else if (comTransform.position.y <= -1.42)
        {
            yDirection = 1;
        }
    }
}
