using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
   
  [SerializeField] private bool pick = false;   
   [SerializeField] private string SceneName;
   [SerializeField] private SceneController sceneController;
   private Coroutine repeatCoroutine;

     [SerializeField] private int x = 2; 
     [SerializeField] private int y = -4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void OnTriggerEnter2D(Collider2D other)
    {
        if(pick)
        {
          if (repeatCoroutine == null)    
            {
                repeatCoroutine = StartCoroutine(Purpose(other));
            }
        }
        else
        {
          if (repeatCoroutine == null)    
          {
            repeatCoroutine = StartCoroutine(Contact(other));
          }
        }       
    }

  private IEnumerator Contact(Collider2D other)
  {
    while(true)
    {
      if(other.gameObject.tag == "Player")
        sceneController.LoadScene(SceneName, x, y);
      //yield return new WaitForSeconds(0.1f);
      yield return null;
    }  
  }


  private IEnumerator Purpose(Collider2D other)
  {
    while(true)
    {
      if(other.gameObject.tag == "Player" && Keyboard.current.fKey.wasPressedThisFrame)
        sceneController.LoadScene(SceneName, x, y);
      yield return new WaitForSeconds(0.1f);;
    }
  }


  private void OnTriggerExit2D(Collider2D other)
    {
        if (repeatCoroutine != null)
        {
            StopCoroutine(repeatCoroutine);
            repeatCoroutine = null;
        }
    
    } 


}
