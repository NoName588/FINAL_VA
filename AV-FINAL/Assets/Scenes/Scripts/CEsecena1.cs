using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CEsecena1 : MonoBehaviour
{
    public AudioClip audioClip; // Nuevo campo para el AudioClip
    private AudioSource audioSource; // Nuevo campo para el AudioSource

    void Start()
    {
        // Obtener el componente AudioSource adjunto al objeto
        audioSource = GetComponent<AudioSource>();
    }

    public void RotarEscena(string SampleScene)
    {
        // Reproducir el audio antes de cambiar de escena
        if (audioClip != null && audioSource != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        // Invocar el m�todo CambiarEscenaDespuesDeAudio despu�s de un retraso de 0.5 segundos
        Invoke("GameTime", 0.5f);
    }

    public void CambiarAEscena(string SampleScene)
    {
        // Reproducir el audio antes de cambiar de escena
        if (audioClip != null && audioSource != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        // Invocar el m�todo CambiarEscenaDespuesDeAudio despu�s de un retraso de 0.5 segundos
        Invoke("CambiarEscenaDespuesDeAudio", 0.5f);
        // En otro script o m�todo que se ejecuta despu�s de cambiar de escena
        

    }

    // M�todo para cambiar de escena despu�s de reproducir el audio
    void CambiarEscenaDespuesDeAudio()
    {
        // Cambiar a la escena especificada
        SceneManager.LoadScene("Tutorial");
    }

    void GameTime()
    {
        // Cambiar a la escena especificada
        SceneManager.LoadScene("Game");
    }
}


