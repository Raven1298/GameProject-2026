using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    [SerializeField] private float sceneFadeDur;
    private SceneFade sceneFade;


    private void Awake()
    {
        sceneFade = GetComponentInChildren<SceneFade>();
    }

    private IEnumerator Start()
    {
        yield return sceneFade.FadeInCoroutine(sceneFadeDur);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCourotine(sceneName));
    }


    private IEnumerator LoadSceneCourotine(string sceneName)
    {
        yield return sceneFade.FadeOutCoroutine(sceneFadeDur);
        yield return SceneManager.LoadSceneAsync(sceneName);


    }


}
