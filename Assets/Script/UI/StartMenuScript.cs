using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{


    [SerializeField] private SceneController sceneController;

    public void Play()
    {
        sceneController.LoadScene("Playtest1");
    }


    public void Quit()
    {
        Application.Quit();
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
