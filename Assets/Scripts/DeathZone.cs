using UnityEngine;

public class DeathZone : MonoBehaviour
{
    // Detecta cuando el jugador entra en la zona de muerte
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra en la zona de muerte es el jugador
        if (other.CompareTag("Player"))
        {
            // Obtiene el componente PlayerController del jugador
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Respawn();  // Llama al método Respawn del jugador
            }
        }
    }
}
