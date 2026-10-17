using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{

    public GameObject Inventory;
    private bool menuActivated;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Keyboard.current.escapeKey.wasPressedThisFrame && menuActivated)
        {
            Inventory.SetActive(false);
            menuActivated = false;
        }
        else if(Keyboard.current.escapeKey.wasPressedThisFrame && !menuActivated)
        {
            Inventory.SetActive(true);
            menuActivated = true;
        }


    }
}
