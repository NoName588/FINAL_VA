using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject buttonPause;
    [SerializeField] private GameObject menuPause;

    [SerializeField] public GameObject[] art;


    public void Start()
    {
        Time.timeScale = 1;
        buttonPause.SetActive(true);
        menuPause.SetActive(false);
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

    public void Change(string Game)
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