using System.Collections; // Espacio de nombres para manejar colecciones básicas.
using System.Collections.Generic; // Espacio de nombres para manejar colecciones genéricas.
using UnityEngine; // Espacio de nombres principal de Unity.
using UnityEngine.SceneManagement; // Espacio de nombres para la gestión de escenas.

public class MenuInicial : MonoBehaviour
{
    // Método que se ejecuta cuando el jugador presiona el botón "Jugar".
    public void Jugar()
    {
        // Carga la siguiente escena en el índice de compilación.
        // Esto asume que las escenas están ordenadas correctamente en el Build Settings.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Método que se ejecuta cuando el jugador presiona el botón "Salir".
    public void Salir()
    {
        // Imprime un mensaje en la consola para confirmar que se activó la función.
        Debug.Log("Salir...");

        // Cierra la aplicación. Este método solo funciona en compilaciones (no en el editor de Unity).
        Application.Quit();
    }
}
