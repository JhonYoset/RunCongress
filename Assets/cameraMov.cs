using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UnityEngine;

public class CameraMov : MonoBehaviour
{
    public Transform jugador; // El objeto jugador que la cámara seguirá
    public Vector3 offset = new Vector3(-24f, 10f, -10f); // Offset de la cámara desde el jugador

    void LateUpdate()
    {
        if (jugador != null)
        {
            // Actualiza la posición de la cámara para que siga al jugador con el offset
            transform.position = jugador.position + offset;

            // Haz que la cámara mire al jugador
            transform.LookAt(jugador);
        }
    }
}