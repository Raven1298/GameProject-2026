using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{

    public GameObject Inventory;
    private bool menuActivated;
    public ItemSlot[] itemSlot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Keyboard.current.tabKey.wasPressedThisFrame && menuActivated)
        {
            Inventory.SetActive(false);
            menuActivated = false;
        }
        else if(Keyboard.current.tabKey.wasPressedThisFrame && !menuActivated)
        {
            Inventory.SetActive(true);
            menuActivated = true;
        }


    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        for(int i = 0; i < itemSlot.Length; i++)
        {
            if(itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, quantity, itemSprite);
                return;
            }

        }
    }
}
