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

    // Start is called before the first frame update
    void Start()
    {
        rigibody = GetComponent<Rigidbody>();
        comTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
