using System.Collections;
using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.SceneManagement;



public class SceneController : MonoBehaviour
{

    [SerializeField] private float sceneFadeDur;
    private SceneFade sceneFade;
    private GameObject Player;
    private CinemachineCamera vcam;

    private GameManager gameManager;
    string currentScene;
    


    private IEnumerator Start()
    {
        Player = GameObject.FindWithTag("Player");
        vcam = FindAnyObjectByType<CinemachineCamera>(); 
        gameManager = FindAnyObjectByType<GameManager>();
        currentScene = SceneManager.GetActiveScene().name;
        sceneFade = GetComponentInChildren<SceneFade>();

        
        if(gameManager != null && gameManager.IsPlayerFound() == false)
        {
            gameManager.FindPlayer();
        }
        if (vcam != null && Player != null)
        {
            vcam.Target.TrackingTarget = Player.transform;
        }
        if(currentScene == "PuzzleRoom")
        {
            Debug.Log("SceneController!");
            gameManager.ChangeJumpHeight(15);
        }
        


        yield return sceneFade.FadeInCoroutine(sceneFadeDur);
    }

    public void LoadScene(string sceneName, int x, int y)
    {
        if(currentScene != "Settings" && currentScene != "StartMenu")
        {
            if(gameManager != null)
            gameManager.LastScene(currentScene);
        }
        StartCoroutine(LoadSceneCourotine(sceneName, x, y));
    }

    public void LoadScene(string sceneName)
    {
        if(currentScene != "Settings" && currentScene != "StartMenu")
        {
            if(gameManager != null)
            gameManager.LastScene(currentScene);
        }
        StartCoroutine(LoadSceneCourotine(sceneName, 2, -4));
    }


    private IEnumerator LoadSceneCourotine(string sceneName, int x, int y)
    {
        yield return sceneFade.FadeOutCoroutine(sceneFadeDur);
        TeleportPlayer(x, y);
        yield return SceneManager.LoadSceneAsync(sceneName);


    }

    public void TeleportPlayer(int x, int y)
    {
    Vector2 respawn = new Vector2(x, y);
    Vector3 Cameraoffset = new Vector3(0,0,0);
    if(Player != null)
        {
        Cameraoffset = (Vector3)respawn - Player.transform.position;
        Player.transform.position = respawn;
        Player.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0,0);

        }   
        if (vcam != null)
        {
            vcam.OnTargetObjectWarped(Player.transform, Cameraoffset);
        }
    }


}
