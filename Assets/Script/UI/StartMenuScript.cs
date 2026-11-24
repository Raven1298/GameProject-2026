using UnityEngine;


public class StartMenuScript : MonoBehaviour
{


    [SerializeField] private SceneController sceneController;
    private GameManager gameManager;

    public void Start()
    {
    gameManager = FindAnyObjectByType<GameManager>();
    //SoundManager.PlaySound(SoundType.startMusic, .2f);
    }

    public void Play()
    {
        if(gameManager.lastscene == "")
        {
        //Debug.Log("Empty");
        sceneController.LoadScene("clairsBedroom");
        //sceneController.LoadScene("Playtest1");
        
        }
        else
        {
         //Debug.Log("Scene: " + gameManager.lastscene);
         sceneController.LoadScene(gameManager.lastscene);   
        }
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
