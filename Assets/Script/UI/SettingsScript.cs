using UnityEngine;
using UnityEngine.SceneManagement;


public class SettingsScript : MonoBehaviour
{

     [SerializeField] private SceneController sceneController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    public void MainMenu()
    {
        sceneController.LoadScene("StartMenu");
        Debug.Log("Hi");
    }
}
