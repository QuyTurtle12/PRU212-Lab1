using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage;  // Reference to the UI Image (Fade Image)

    public static SceneTransition instance;

    // Ensure there is only one instance of this object
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);  // Destroy any duplicate instances
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Keep this object between scenes
        }
    }

    // This method will be called to fade to a scene
    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeAndLoad(sceneName));
    }

    private IEnumerator FadeAndLoad(string sceneName)
    {
        fadeImage = GameObject.Find("FadeImage").GetComponent<Image>();

        // Fade out (make the image visible)
        fadeImage.gameObject.SetActive(true);
        float fadeTime = 1f;
        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            fadeImage.color = Color.Lerp(Color.clear, Color.black, t / fadeTime);
            yield return null;
        }

        // Load the new scene
        SceneManager.LoadScene(sceneName);

        // Fade in (make the image invisible)
        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            fadeImage.color = Color.Lerp(Color.black, Color.clear, t / fadeTime);
            yield return null;
        }

        fadeImage.gameObject.SetActive(false);  // Deactivate the image after the fade-in
    }
}
