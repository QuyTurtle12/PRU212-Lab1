using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuManager : MonoBehaviour
{
    public SceneTransition sceneTransition;

    // Return to main menu scene
    public void EndGame()
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
