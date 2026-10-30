
using UnityEngine;
using System.Collections;


public class ChangeHealh : MonoBehaviour
{

    GameObject Player;  
    private SpriteRenderer spriteRenderer;
    private Color currentColor;
    private Coroutine repeatCoroutine;
    private PlayerHealth playerHealthScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentColor = spriteRenderer.color;

        Player = GameObject.FindWithTag("Player");
        playerHealthScript = Player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
{
    if(other.gameObject.tag == "Player")
    {
            

        
    // Define a small tolerance window for precision errors
    float tolerance = 0.01f;

    // Check if the current color is close to the expected Red color
    if (Mathf.Abs(currentColor.r - (234f / 255f)) < tolerance)
    {
        if (repeatCoroutine == null)    
        {
            repeatCoroutine = StartCoroutine(Hurt());
        }
    }
    // Check if the current color is close to the expected Green color
    else if (Mathf.Abs(currentColor.g - (199f / 255f)) < tolerance)
    {
        if (repeatCoroutine == null)    
        {
            repeatCoroutine = StartCoroutine(Heal());
        }        
    }

    }
}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (repeatCoroutine != null)
        {
            StopCoroutine(repeatCoroutine);
            repeatCoroutine = null;
        }
    } 

    private IEnumerator Heal()
        {
            while (true)
            {
                playerHealthScript.health++;
                yield return new WaitForSeconds(2f);
            }
        }

private IEnumerator Hurt()
    {
        while (true)
        {
            playerHealthScript.health--;
            yield return new WaitForSeconds(2f);
        }
    }



}




