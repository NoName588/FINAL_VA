using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    [SerializeField] private GameObject buttonPause;
    [SerializeField] private GameObject menuPause;

    [SerializeField] public GameObject[] art;
    [SerializeField] public GameObject[] lose;
    [SerializeField] public GameObject[] win;


    public void Start()
    {
        Time.timeScale = 1;
        buttonPause.SetActive(true);
        menuPause.SetActive(false);
    }
    public void Seguirlose()
    {
        Time.timeScale = 1;
        foreach (GameObject obj in lose)
        {
            obj.SetActive(false);
        }
    }

    public void Seguirwin()
    {
        Time.timeScale = 1;
        foreach (GameObject obj in win)
        {
            obj.SetActive(false);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        buttonPause.SetActive(false);
        menuPause.SetActive(true);

        foreach (GameObject obj in art)
        {
            obj.SetActive(false);
        }

    }

    public void Continue()
    {
        Time.timeScale = 1;
        buttonPause.SetActive(true);
        menuPause.SetActive(false);
    }
    public void Resetion()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menudo(string Tutorial)
    {
        SceneManager.LoadScene(Tutorial);

    }

    public void Seguir(string Game)
    {
        SceneManager.LoadScene(Game);

    }

    public void ExitMainmenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLvl2()
    {
        SceneManager.LoadScene("Lvl2");
    }
    
    public void LoadLvl3()
    {
        SceneManager.LoadScene("Lvl3");
    }
}

