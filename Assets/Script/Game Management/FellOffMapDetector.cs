using UnityEngine;

public class FellOffMapDetector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject Player;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D()
    {
        Vector2 respawn = new Vector2(2, -4);
        Player.transform.position = respawn;
    }


}
