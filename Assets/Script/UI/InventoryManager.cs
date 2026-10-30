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

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for(int i = 0; i < itemSlot.Length; i++)
        {
            if(itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                if(leftOverItems > 0)
                     leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);


                    return leftOverItems;
            }

        }
        return quantity;
    }


    public void DeselectAllSlots()
    {
        for(int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].ThisItemIsSelected = false;
        }


    }
}
