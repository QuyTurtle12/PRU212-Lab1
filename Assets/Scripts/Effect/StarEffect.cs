using System.Collections;
using UnityEngine;

public class StarEffect : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float minAlpha = 0.2f; // Minimum alpha value for twinkling
    private float maxAlpha = 1f;   // Maximum alpha value for twinkling
    private float duration = 1f;    // Duration of the twinkle effect

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Twinkle());
    }

    private IEnumerator Twinkle()
    {
        while (true)
        {
            // Fade in
            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                float normalizedTime = t / duration;
                float alpha = Mathf.Lerp(minAlpha, maxAlpha, normalizedTime);
                SetAlpha(alpha);
                yield return null;
            }

            // Fade out
            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                float normalizedTime = t / duration;
                float alpha = Mathf.Lerp(maxAlpha, minAlpha, normalizedTime);
                SetAlpha(alpha);
                yield return null;
            }
        }
    }

    private void SetAlpha(float alpha)
    {
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }
}