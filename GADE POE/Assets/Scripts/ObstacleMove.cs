using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float speed = 10f; // speed of obstacle movement in units per second

    void Update()
    {
        // Move the obstacle in the negative z direction
        Vector3 movement = new Vector3(0, 0, -speed * Time.deltaTime);
        transform.position += movement;
    }
}