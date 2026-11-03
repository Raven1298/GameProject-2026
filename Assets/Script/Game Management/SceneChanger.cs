using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
   
   
   [SerializeField] private string SceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void OnTriggerEnter2D(Collider2D other)
    {
         SceneManager.LoadScene(SceneName);

    }
}
