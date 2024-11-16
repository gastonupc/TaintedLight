using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Este es un identificador único para cada checkpoint
    public string checkpointID;

    // Este método se llama cuando el jugador entra en la zona del checkpoint
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Verifica si el que entra es el jugador
        {
            // Llama al método de PlayerProgress para guardar la posición del checkpoint
            PlayerProgress.Instance.SetCheckpoint(transform.position, checkpointID);
            UnityEngine.Debug.Log("Checkpoint alcanzado. Posición guardada en: " + transform.position);
        }
    }
}
