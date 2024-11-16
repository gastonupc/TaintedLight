using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public static PlayerProgress Instance; // Instancia única (Singleton)

    private Vector2 lastCheckpointPosition; // Almacena la última posición del checkpoint
    private string lastCheckpointID; // Almacena el ID del último checkpoint

    private void Awake()
    {
        // Asegura que solo haya una instancia de PlayerProgress
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Establece la posición y el ID del checkpoint
    public void SetCheckpoint(Vector2 checkpointPosition, string checkpointID)
    {
        lastCheckpointPosition = checkpointPosition;
        lastCheckpointID = checkpointID;
    }

    // Obtiene la última posición guardada del checkpoint
    public Vector2 GetLastCheckpointPosition()
    {
        return lastCheckpointPosition;
    }

    // Obtiene el ID del último checkpoint guardado
    public string GetLastCheckpointID()
    {
        return lastCheckpointID;
    }
}
