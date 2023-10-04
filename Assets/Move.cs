using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Move : MonoBehaviour
{
    public float velocidad = 10.0f; // Velocidad de movimiento

    void Update()
    {
        // Obtener las entradas del teclado
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular el desplazamiento en los ejes X y Z
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical) * velocidad * Time.deltaTime;

        // Aplicar el movimiento al objeto
        transform.Translate(movimiento);
    }
}