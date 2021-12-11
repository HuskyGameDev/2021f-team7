using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void ClickOnStartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ClickOnExitButton()
    {
        Application.Quit();
    }
}