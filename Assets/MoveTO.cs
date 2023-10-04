using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTO : MonoBehaviour{
// Velocidad del objeto
    public float speed = 2.0f;
    // Precisión
    public float accuracy = 0.01f;
    // Objetivo del objeto
    public Transform goal;

    // Método llamado al inicio antes del primer fotograma
    void Start() {
        // Hace que el objeto mire hacia la posición del objetivo
        this.transform.LookAt(goal.position);
    }

    // Método llamado en cada fotograma, después de que se hayan realizado todas las actualizaciones
    void LateUpdate() {

        // Calcula la dirección hacia la que está mirando el objeto
        this.transform.LookAt(goal.position);

        // Encuentra el vector de dirección
        Vector3 direction = goal.position - this.transform.position;

        // Dibuja un rayo de depuración en la dirección hacia la que se encuentra el objeto
        Debug.DrawRay(this.transform.position, direction, Color.red);

        // Comprueba qué tan cerca está el personaje del objetivo
        if (direction.magnitude > accuracy) {

            // Mueve el objeto hacia el objetivo
            this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}