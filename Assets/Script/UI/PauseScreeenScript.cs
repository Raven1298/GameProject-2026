using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseScreenScript : MonoBehaviour
{

    bool paused = false;
    public GameObject ChildObject;
    [SerializeField] private SceneController sceneController;
    private InventoryManager inventoryManager;


    void Start()
    {
        ChildObject.SetActive(false);
        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }


    void Update()
    {
        
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            paused = TogglePause();

        }
    }

    bool TogglePause()
    {
        
        if(Time.timeScale == 0f) //Unpauses the Game
		{
			Time.timeScale = 1f;
            ChildObject.SetActive(false);
			return(false);
            
		}
		else  //Pauses the Game
		{
			Time.timeScale = 0f;
            ChildObject.SetActive(true);
            inventoryManager.Inventory.SetActive(false);
			return(true);	
		}
    }

    public void MainMenu()
    {
        TogglePause();
        FindSceneController();
        sceneController.LoadScene("StartMenu");
    }
    public void Settings()
    {
        TogglePause();
        FindSceneController();
        sceneController.LoadScene("Settings");
    }
    public void FindSceneController()
    {
        sceneController = FindAnyObjectByType<SceneController>();
    }


}