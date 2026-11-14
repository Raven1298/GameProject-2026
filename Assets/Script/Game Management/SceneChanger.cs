using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
   
   
   [SerializeField] private string SceneName;
   [SerializeField] private SceneController sceneController;

     [SerializeField] private int x = 2; 
     [SerializeField] private int y = -4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void OnTriggerEnter2D(Collider2D other)
    {
          if(other.gameObject.tag == "Player")
               sceneController.LoadScene(SceneName, x, y);

    }
}
