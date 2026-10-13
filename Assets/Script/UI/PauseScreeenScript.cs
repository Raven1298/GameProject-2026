using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseScreenScript : MonoBehaviour
{

    bool paused = false;

    void Start()
    {
        

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
        
        if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			return(true);	
		}
    }





}