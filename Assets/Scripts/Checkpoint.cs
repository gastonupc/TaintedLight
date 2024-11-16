using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Este es un identificador �nico para cada checkpoint
    public string checkpointID;

    // Este m�todo se llama cuando el jugador entra en la zona del checkpoint
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Verifica si el que entra es el jugador
        {
            // Llama al m�todo de PlayerProgress para guardar la posici�n del checkpoint
            PlayerProgress.Instance.SetCheckpoint(transform.position, checkpointID);
            UnityEngine.Debug.Log("Checkpoint alcanzado. Posici�n guardada en: " + transform.position);
        }
    }
}
