using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    bool alive = true;

    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;
    public float jumpForce = 10.0f; // Fuerza del salto
    private bool isGrounded = true;

    private void FixedUpdate ()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Aplicar una fuerza hacia arriba para simular el salto
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // El personaje ya no está en el suelo después del salto
        }
       
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Suelo"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Suelo"))
        {
            isGrounded = false;
        }
    }

    private void Update () {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5) {
            Die();
        }/*
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Aplicar una fuerza hacia arriba para simular el salto
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // El personaje ya no está en el suelo después del salto
        }*/
	}

    public void Die ()
    {
        alive = false;
        // Restart the game
        Invoke("Restart", 1);
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}