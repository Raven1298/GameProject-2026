using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    [SerializeField] private float sceneFadeDur;
    private SceneFade sceneFade;
    private GameObject Player;

    private void Awake()
    {
        Player = GameObject.FindWithTag("Player");
        sceneFade = GetComponentInChildren<SceneFade>();
    }

    private IEnumerator Start()
    {
        yield return sceneFade.FadeInCoroutine(sceneFadeDur);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCourotine(sceneName));
        Vector2 respawn = new Vector2(2, -4);
        Player.transform.position = respawn;
    }


    private IEnumerator LoadSceneCourotine(string sceneName)
    {
        yield return sceneFade.FadeOutCoroutine(sceneFadeDur);
        yield return SceneManager.LoadSceneAsync(sceneName);

    }


}
