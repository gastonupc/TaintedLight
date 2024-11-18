using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables p�blicas para controlar la velocidad de movimiento, salto, y f�sicas del salto
    public float moveSpeed = 4f;
    public float jumpForce = 5f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    // Variables privadas para el control del personaje
    private bool isGrounded; // Verifica si el jugador est� en el suelo
    private Rigidbody2D rb;  // Componente de f�sica 2D
    private Animator anim;   // Componente del Animator para las animaciones
    private SpriteRenderer spr; // Para cambiar la orientaci�n del sprite
    private bool isFacingRight = true; // Direcci�n en la que est� mirando el jugador

    public GameObject checkpoint1; // Referencia al primer checkpoint

    void Start()
    {
        // Inicializa los componentes
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();

        // Si el checkpoint est� asignado, mueve al jugador a esa posici�n al comenzar
        if (checkpoint1 != null)
        {
            transform.position = checkpoint1.transform.position;
        }
        else
        {
            Debug.LogError("Checkpoint1 no est� asignado.");
        }
    }

    void Update()
    {
        // Llama a las funciones de movimiento y salto
        Move();
        Jump();
        ApplyJumpPhysics();

        // Actualiza las animaciones en funci�n del movimiento y la velocidad vertical
        anim.SetFloat("movement", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("ySpeed", rb.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
    }

    // Funci�n para mover al jugador
    void Move()
    {
        // Obtiene la entrada de movimiento horizontal
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y); // Aplica la velocidad al movimiento horizontal

        // Voltea al jugador seg�n la direcci�n en la que se mueve
        if (moveInput > 0 && !isFacingRight)
        {
            isFacingRight = true;
            spr.flipX = false;
        }
        else if (moveInput < 0 && isFacingRight)
        {
            isFacingRight = false;
            spr.flipX = true;
        }
    }

    // Funci�n para saltar
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) // Solo salta si est� en el suelo
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Aplica una fuerza de salto
        }
    }

    // Ajusta la f�sica del salto para mejorar la respuesta
    void ApplyJumpPhysics()
    {
        // Si el jugador est� cayendo
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        // Si el jugador est� saltando y no mantiene el salto
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    // Detecta si el jugador est� tocando el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Detecta cuando el jugador deja de tocar el suelo
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // M�todo que se llama para que el jugador reaparezca en el �ltimo checkpoint
    public void Respawn()
    {
        if (PlayerProgress.Instance != null)
        {
            // Obtiene la posici�n guardada del �ltimo checkpoint
            Vector2 respawnPosition = PlayerProgress.Instance.GetLastCheckpointPosition();

            if (respawnPosition != Vector2.zero) // Si existe una posici�n guardada
            {
                transform.position = respawnPosition; // Reposiciona al jugador
                Debug.Log("Reapareciendo en el checkpoint: " + respawnPosition);
            }
            else
            {
                // Si no hay un checkpoint guardado, reaparece en la posici�n inicial
                Debug.LogWarning("No hay un checkpoint guardado. Reapareciendo en la posici�n inicial.");
                transform.position = Vector2.zero;
            }

            // Reinicia la velocidad del jugador al reaparecer
            rb.velocity = Vector2.zero;
        }
        else
        {
            Debug.LogError("PlayerProgress.Instance es nulo. No se puede reaparecer.");
        }
    }

}
