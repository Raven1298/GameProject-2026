using UnityEngine;
using TMPro;


public class SettingsScript : MonoBehaviour
{

     [SerializeField] private SceneController sceneController;
     private HealthChange HUD;
     private GameManager gameManager;
     public TMP_InputField dashInputField;
     public TMP_InputField runInputField;
     public TMP_InputField JumoInputField;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        HUD = FindAnyObjectByType<HealthChange>();
        if(HUD != null)
        HUD.ToggleHUDImages();
    }


    public void MainMenu()
    {
        SetRunSpeed();
        if(HUD != null)
        HUD.ToggleHUDImages();
        sceneController.LoadScene("StartMenu");
    }
    public void ReturnToLastScene()
    {
        
        SetRunSpeed();
        if(HUD != null)
        HUD.ToggleHUDImages();
        if(gameManager.lastscene !="")
        sceneController.LoadScene(gameManager.lastscene);
        else
        sceneController.LoadScene("StartMenu");

    }

    private void SetRunSpeed()
    {
        int v = 5;
        try
        {
        v = int.Parse(runInputField.text);
        }
        catch
        {
        Debug.Log("Not an Integer");
        v = 5;
        }
        gameManager.changeDashSpeed(v);
    }
    private void SetDashSpeed()
    {
        int v = 5;
        try
        {
        v = int.Parse(dashInputField.text);
        }
        catch
        {
        Debug.Log("Not an Integer");
        v = 5;
        }
        gameManager.changeRunSpeed(v);
    }
}
