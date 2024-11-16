using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public static PlayerProgress Instance; // Instancia �nica (Singleton)

    private Vector2 lastCheckpointPosition; // Almacena la �ltima posici�n del checkpoint
    private string lastCheckpointID; // Almacena el ID del �ltimo checkpoint

    private void Awake()
    {
        // Asegura que solo haya una instancia de PlayerProgress
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Establece la posici�n y el ID del checkpoint
    public void SetCheckpoint(Vector2 checkpointPosition, string checkpointID)
    {
        lastCheckpointPosition = checkpointPosition;
        lastCheckpointID = checkpointID;
    }

    // Obtiene la �ltima posici�n guardada del checkpoint
    public Vector2 GetLastCheckpointPosition()
    {
        return lastCheckpointPosition;
    }

    // Obtiene el ID del �ltimo checkpoint guardado
    public string GetLastCheckpointID()
    {
        return lastCheckpointID;
    }
}
