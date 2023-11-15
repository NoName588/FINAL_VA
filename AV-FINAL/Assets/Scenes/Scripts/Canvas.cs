using UnityEngine;

public class Canvas : MonoBehaviour
{

    public GameObject[] objectsToActivate;  // Lista de objetos para activar
    public GameObject[] objectsToDeactivate;
    public GameObject[] objectsToK;// Lista de objetos para desactivar

    private void Start()
    {
        // Pausar el juego al inicio
        Time.timeScale = 0f;

    }

    // Función para ser llamada por un botón
    public void ActivateObjects()
    {
        // Activar objetos y desactivar otros
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
        }

        foreach (GameObject obj in objectsToK)
        {
            obj.SetActive(false);
        }


    }

    // Función para ser llamada por otro botón
    public void DeactivateObjects()
    {
        // Desactivar objetos
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }
        Time.timeScale = 1f;
    }
}
