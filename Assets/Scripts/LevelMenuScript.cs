using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelMenuScript : MonoBehaviour
{
    public void TryAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
