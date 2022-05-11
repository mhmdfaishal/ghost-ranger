using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("ARScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
