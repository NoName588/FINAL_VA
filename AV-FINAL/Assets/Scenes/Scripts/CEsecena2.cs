using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CEsecena2 : MonoBehaviour
{
    
    public void CambiarAEscena(string Credits)
    {
        SceneManager.LoadScene(Credits);
    }
}
