using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Sphere : MonoBehaviour
{
    public float bounciness = 1;
    private Vector3 speed = new Vector3(300, 15);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector3 vel = new Vector3();
            var ballVelocity = ball_rb.velocity;

            var player = collision.collider.attachedRigidbody.velocity.y;

            vel.x = ballVelocity.x * 1.1f; // Increases the speed of the ball velocity
            vel.y = (ballVelocity.y * 1.1f) + (player / 3.0f);

            ball_rb.velocity = vel;
        }

        if (collision.collider.CompareTag("Enemy"))
        {
            Vector3 vel = new Vector3();
            var ballVelocity = ball_rb.velocity;

            var enemy = collision.collider.attachedRigidbody;

            vel.x = ballVelocity.x * 1.1f; // Increases the speed of the ball velocity
            vel.y = (ballVelocity.y * 1.1f) + (enemy.velocity.y / 3.0f);

            ball_rb.velocity = vel;

            enemy.velocity.y = ball_rb.velocity.y;
        }
    }
}