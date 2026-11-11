using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class SettingsScript : MonoBehaviour
{

     [SerializeField] private SceneController sceneController;
     private HealthChange HUD;
     private GameManager gameManager;
     public TMP_InputField dashInputField;
     public TMP_InputField walkInputField;
     public TMP_InputField JumoInputField;
     public Slider slider;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        HUD = FindAnyObjectByType<HealthChange>();
        if(HUD != null)
        HUD.ToggleHUDImages();
        slider.value = gameManager.volume;
        walkInputField.text = ((int)gameManager.GetMove()).ToString();
        dashInputField.text = ((int)gameManager.GetDash()).ToString();

        

    }


    public void MainMenu()
    {
        SetWalkSpeed();
        SetDashSpeed();
        SetVolume();
        if(HUD != null)
        HUD.ToggleHUDImages();
        sceneController.LoadScene("StartMenu");
    }
    public void ReturnToLastScene()
    {
        
        SetWalkSpeed();
        SetDashSpeed();
        SetVolume();
        if(HUD != null)
        HUD.ToggleHUDImages();
        if(gameManager.lastscene !="")
        sceneController.LoadScene(gameManager.lastscene);
        else
        sceneController.LoadScene("StartMenu");

    }

    private void SetWalkSpeed()
    {
        int v = 5;
        string input = walkInputField.text;
        Debug.Log(input);
        if (int.TryParse(input, out v))
        {
            gameManager.changeWalkSpeed(v);
        }
        else
        {
            Debug.LogWarning("Not an Integer");
        }

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
        gameManager.changeDashSpeed(v);
    }
    private void SetVolume()
    {
        float v = 5;
        v = slider.value;
        gameManager.changeVolume(v);

    }
}
