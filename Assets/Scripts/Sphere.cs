using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Sphere : MonoBehaviour
{
    
    public float bounciness = 1;
    private Vector3 speed = new Vector3(500, 5, 0);
    private Rigidbody ball_rb;
    
    private void StartRandom()
    {
        float rand = Random.Range(0, 2);
        Debug.Log(rand);
        if (rand < 1)
        {
            ball_rb.AddForce(speed);
        }
        else
        {
            ball_rb.AddForce(-speed);
        }
    }
    
    void Start()
    {
        ball_rb = GetComponent<Rigidbody>();
        StartRandom();
    }

    // Update is called once per frame
    void Update()
    {
         // speed.x = Mathf.Clamp(speed.x, 0, 20);
         // ball_rb.AddForce(speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector3 vel = new Vector3();
            vel.x = ball_rb.velocity.x;
            Debug.Log(vel);
        }
        Debug.Log(collision.collider.tag);
    }
}
