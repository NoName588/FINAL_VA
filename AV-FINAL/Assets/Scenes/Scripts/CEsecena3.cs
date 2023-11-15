using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CEsecena3 : MonoBehaviour
{
    
    public void CambiarAEscena(string SampleScene)
    {
        SceneManager.LoadScene(SampleScene);
    }
}
