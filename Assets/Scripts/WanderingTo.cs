using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : MonoBehaviour
{
    public float speed = 1.0f;
    public float rotationSpeed = 45.0f; // Grados por segundo
    public float wanderInterval = 2.0f;
    public Vector3 wanderCenter = Vector3.zero;
    public float wanderRadius = 1.5f;

    private float timeSinceLastWander;
    private Vector3 wanderTarget;

    private void Start()
    {
        timeSinceLastWander = wanderInterval;
    }

    private void Update()
    {
        timeSinceLastWander += Time.deltaTime;

        if (timeSinceLastWander >= wanderInterval)
        {
            // Generate a random target position within the 3x3 space
            float randomX = Random.Range(-1.5f, 1.5f);
            float randomZ = Random.Range(-1.5f, 1.5f);
            wanderTarget = wanderCenter + new Vector3(randomX, 0, randomZ);

            timeSinceLastWander = 0.0f;
        }

        // Rotate the object
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);

        // Move towards the wander target
        transform.position = Vector3.MoveTowards(transform.position, wanderTarget, speed * Time.deltaTime);
    }
}
