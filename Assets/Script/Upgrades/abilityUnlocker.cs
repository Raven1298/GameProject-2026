using UnityEngine;

public class abilityUnlocker : MonoBehaviour
{
    private bool unlockedDash = false;
    private playerMovement player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null && player.hasDash && !unlockedDash){
            unlockedDash = true;
            Debug.Log("Unlocked Dash");
        }

        if(player != null && !player.hasDash && unlockedDash)
        {
            player.hasDash = true;
            Debug.Log("Dash Presisted");
        }
    }
}
