using UnityEngine;

public class EndMenuManager : MonoBehaviour
{
    // Return to main menu scene
    public void EndGame()
    {
        SceneTransition.instance.FadeToScene("1-1");
    }

    // Quit Game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
