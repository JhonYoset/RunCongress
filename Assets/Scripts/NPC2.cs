using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2 : MonoBehaviour
{
    private Transform player;
    private float moveSpeed = 3f;
    private float seekRange = 10f;
    PlayerMovement playerMovement;
    // Velocidad del objeto
    public float speed = 2.0f;
    // Precisión
    public float accuracy = 0.01f;
    // Objetivo del objeto
    public Transform goal;

    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        player = GameObject.FindObjectOfType<PlayerMovement>().transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Kill the player
            playerMovement.Die();
        }
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= seekRange)
        {
            SeekPlayer();
        }
    }

    private void SeekPlayer()
    {
        // Calcula la dirección hacia la que está mirando el objeto
        transform.LookAt(player.position);

        // Encuentra el vector de dirección
        Vector3 direction = player.position - transform.position;

        // Establece el componente Y de la dirección a cero para evitar el movimiento en ese eje
        direction.y = 0;

        // Dibuja un rayo de depuración en la dirección hacia la que se encuentra el objeto
        Debug.DrawRay(transform.position, direction, Color.red);

        // Comprueba qué tan cerca está el personaje del objetivo
        if (direction.magnitude > accuracy)
        {
            // Mueve el objeto hacia el objetivo en el plano XZ
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
