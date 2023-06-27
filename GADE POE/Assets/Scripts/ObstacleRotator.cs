using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    public float rotationSpeed = 90f; // speed of rotation in degrees per second

    void Update()
    {
        // Rotate the obstacle in the z axis
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}