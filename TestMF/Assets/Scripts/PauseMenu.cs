using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void ActivePauseMenu()
    {
        if(gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            ContinueButton();
        }
             
    }
    public void ContinueButton()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void BackToMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
