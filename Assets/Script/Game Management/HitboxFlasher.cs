using UnityEngine;
using System.Collections;

public class HitboxFlasher : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void Flash(Color flashColor, float duration)
    {
        StartCoroutine(FlashRoutine(flashColor, duration));
    }

    private IEnumerator FlashRoutine(Color flashColor, float duration)
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(duration);
        spriteRenderer.color = originalColor;
    }
}
