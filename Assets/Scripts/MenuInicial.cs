using System.Collections; // Espacio de nombres para manejar colecciones b�sicas.
using System.Collections.Generic; // Espacio de nombres para manejar colecciones gen�ricas.
using UnityEngine; // Espacio de nombres principal de Unity.
using UnityEngine.SceneManagement; // Espacio de nombres para la gesti�n de escenas.

public class MenuInicial : MonoBehaviour
{
    // M�todo que se ejecuta cuando el jugador presiona el bot�n "Jugar".
    public void Jugar()
    {
        // Carga la siguiente escena en el �ndice de compilaci�n.
        // Esto asume que las escenas est�n ordenadas correctamente en el Build Settings.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // M�todo que se ejecuta cuando el jugador presiona el bot�n "Salir".
    public void Salir()
    {
        // Imprime un mensaje en la consola para confirmar que se activ� la funci�n.
        Debug.Log("Salir...");

        // Cierra la aplicaci�n. Este m�todo solo funciona en compilaciones (no en el editor de Unity).
        Application.Quit();
    }
}
