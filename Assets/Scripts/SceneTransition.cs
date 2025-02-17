using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{

    public static SceneTransition instance;
    [SerializeField] Animator sceneTransAnim;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeAndLoad(sceneName));
    }

    private IEnumerator FadeAndLoad(string sceneName)
    {
        sceneTransAnim.SetTrigger("End");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneName);
        sceneTransAnim.SetTrigger("Start");
    }
}

