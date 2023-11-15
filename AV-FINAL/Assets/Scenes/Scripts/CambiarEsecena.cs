using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEsecena : MonoBehaviour
{
    
    public void CambiarAEscena(string SettingsScene)
    {
        SceneManager.LoadScene(SettingsScene);
    }
}
