using UnityEngine;
using UnityEngine.SceneManagement;


public class SettingsScript : MonoBehaviour
{

     [SerializeField] private SceneController sceneController;
     private HealthChange HUD;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HUD = FindAnyObjectByType<HealthChange>();
        if(HUD != null)
        HUD.ToggleHUDImages();
    }


    public void MainMenu()
    {
        if(HUD != null)
        HUD.ToggleHUDImages();
        sceneController.LoadScene("StartMenu");
    }
}
