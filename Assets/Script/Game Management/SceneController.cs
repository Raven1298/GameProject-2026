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
        if(gameManager.IsPlayerFound() == false)
        {
            gameManager.FindPlayer();
        }
        currentScene = SceneManager.GetActiveScene().name;
        sceneFade = GetComponentInChildren<SceneFade>();
        yield return sceneFade.FadeInCoroutine(sceneFadeDur);
    }

    public void LoadScene(string sceneName)
    {
        if(currentScene != "Settings" && currentScene != "StartMenu")
        gameManager.LastScene(currentScene);
        StartCoroutine(LoadSceneCourotine(sceneName));
    }


    private IEnumerator LoadSceneCourotine(string sceneName)
    {
        yield return sceneFade.FadeOutCoroutine(sceneFadeDur);
        TeleportPlayer(2, -4);
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
        }   
        if (vcam != null)
        {
            vcam.OnTargetObjectWarped(Player.transform, Cameraoffset);
        }
    }


}
