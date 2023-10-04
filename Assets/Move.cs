using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Move : MonoBehaviour{
public float velocidad = 15.0f; // Velocidad de movimiento
    public float fuerzaDeSalto = 10.0f; // Fuerza del salto

    private bool enElSuelo = true; // Variable para rastrear si el personaje está en el suelo

    void Update()
    {
        // Obtener las entradas del teclado
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular el desplazamiento en los ejes X y Z
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical) * velocidad * Time.deltaTime;

        // Aplicar el movimiento al objeto
        transform.Translate(movimiento);

        // Manejar el salto
        if (Input.GetKeyDown(KeyCode.Space) && enElSuelo)
        {
            // Aplicar una fuerza hacia arriba para simular el salto
            GetComponent<Rigidbody>().AddForce(Vector3.up * fuerzaDeSalto, ForceMode.Impulse);
            enElSuelo = false; // El personaje ya no está en el suelo después del salto
        }
    }

    // Detectar si el personaje toca el suelo
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Suelo"))
        {
            enElSuelo = true;
        }
    }

    // Detectar si el personaje se aleja del suelo
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Suelo"))
        {
            enElSuelo = false;
        }
    }
}