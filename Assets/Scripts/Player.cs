using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 5;
    void Start()
    {
        Debug.Log("Hello Mess!");
    }

    void Update()
    { 
        var velocity = speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(Vector3.up * velocity);
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            transform.Translate(Vector3.down * velocity);
        }
    }
}
