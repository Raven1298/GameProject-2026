using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseScreenScript : MonoBehaviour
{

    bool paused = false;
    public GameObject ChildObject;

    void Start()
    {
        ChildObject.SetActive(false);
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
			return(true);	
		}
    }





}