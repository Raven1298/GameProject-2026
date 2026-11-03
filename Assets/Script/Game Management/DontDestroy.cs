using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private static GameObject[] persistantObjects = new GameObject[7]; 
    public int objectIndex;
    void Awake()
    {
        if(persistantObjects[objectIndex] == null)
        {
            persistantObjects[objectIndex] = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (persistantObjects[objectIndex] != gameObject)
        {
            Destroy(gameObject);
        }

    }





}