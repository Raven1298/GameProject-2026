using UnityEngine;


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

    public void Settings()
    {
        sceneController.LoadScene("Settings");
    }

}
