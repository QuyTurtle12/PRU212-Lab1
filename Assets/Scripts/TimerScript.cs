using UnityEngine;
using UnityEngine.SceneManagement;  // To manage scenes
using UnityEngine.UI; // Optional, if you want to display the countdown on UI

public class TimerScript : MonoBehaviour
{
    // Time in seconds
    public float timeLimit = 10f;  
    private float currentTime;
    public Text timerText;

    private bool isTimerActive = false;  

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        ResetTimer();

    }

    void Update()
    {
        if (isTimerActive)
        {
            currentTime -= Time.deltaTime;

            if (timerText != null)
            {
                timerText.text = "Time left: " + Mathf.Round(currentTime).ToString() + "s";
            }

            if (currentTime <= 0)
            {
                GoToNextScene();
            }
        }
    }

    void GoToNextScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        isTimerActive = false;

        // Check for the next scene and load it
        if (currentSceneName == "1-1")
        {
            SceneManager.LoadScene("1-2");  // Transition from 1-1 to 1-2
        }
        else if (currentSceneName == "1-2")
        {
            SceneManager.LoadScene("1-3");  // Transition from 1-2 to 1-3
        }
        else if (currentSceneName == "1-3")
        {
            SceneManager.LoadScene("MainMenu");  // Transition from 1-3 to MainMenu or another scene
        }

    }

    void ResetTimer()
    {
        currentTime = timeLimit;  // Reset the timer for the new scene
        isTimerActive = true;  // Start the timer for the new scene
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetTimer();  // Reset the timer every time a new scene is loaded
    }


}
