using Score;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{
    public int scoreValue = 1; // score when take a star
    public AudioClip pickupSound; // sound when eat star
    public GameObject starEffect; // effect when eat star

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("no find AudioSource on star! check Inspector.");
        }
        else
        {
            audioSource.enabled = true;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Va chạm với: " + other.gameObject.name); // check 

        if (other.CompareTag("Player"))
        {
            Debug.Log("Va chạm với Player!"); // check Player "tag"

            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(scoreValue); // add score
                Debug.Log("Score sau khi ăn sao: " + ScoreManager.Instance.GetScore());
            }
            else
            {
                Debug.LogError("ScoreManager.Instance không tồn tại!");
            }

            // play sound when take a star
            if (pickupSound != null && audioSource != null)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(pickupSound);
                }

            }


            // effect star 
            if (starEffect != null)
            {
                Instantiate(starEffect, transform.position, Quaternion.identity);
            }

            // delete star when eat
            Destroy(gameObject);
        }
    }
}
