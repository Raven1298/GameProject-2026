using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Collections.Tests.CoreCLR.TestJobs;

public class DeathEvent : MonoBehaviour
{



     [SerializeField] private SceneController sceneController;
    private GameManager gameManager;
    private GameObject player;
    private Rigidbody2D Rb;
    private BoxCollider2D Bc;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneController = FindAnyObjectByType<SceneController>();
        player = GameObject.FindWithTag("Player");
        gameManager = FindAnyObjectByType<GameManager>();
        Rb = player.GetComponent<Rigidbody2D>();
        Bc = player.GetComponent<BoxCollider2D>();
        Bc.enabled = false;
        Rb.simulated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        Bc.enabled = true;
        Rb.simulated = true;
        sceneController.LoadScene(SceneManager.GetActiveScene().name);
        if(gameManager!=null)
            gameManager.ClearInventory();
    }

    public void Exit()
    {
        Bc.enabled = true;
        Rb.simulated = true;
        sceneController.LoadScene("StartMenu");
        if(gameManager!=null)
            gameManager.ClearInventory();
    }




}
