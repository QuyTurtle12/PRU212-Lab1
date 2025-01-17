using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuManager : MonoBehaviour
{

    // Return to main menu scene
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Quit Game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
