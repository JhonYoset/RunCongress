using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float velocidadX = 5.0f; // Velocidad en el eje X
    public float fuerzaSalto = 10.0f; // Fuerza del salto
    public float yMin = -12.0f; // Valor mínimo en el eje Y
    public float yMax = 12.0f; // Valor máximo en el eje Y

    private Rigidbody rb;
    private bool enSuelo = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Mover el jugador en el eje X
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        Vector3 movimiento = new Vector3(movimientoHorizontal * velocidadX, 0, 0);
        rb.velocity = movimiento;

        // Saltar si se presiona la tecla de espacio y el jugador está en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            enSuelo = false;
        }

        // Limitar el valor de Y dentro del intervalo deseado
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, yMin, yMax), transform.position.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Comprobar si el jugador ha tocado el suelo
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
}