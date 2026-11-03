using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{

//========Item Data===============//
public string itemName;
public int quantity;
public Sprite itemSprite;
public bool isFull;
public string itemDescription;
[SerializeField] private int MaxNumberOfItems;
 

 //=================Item Slot======================//
[SerializeField] private TMP_Text quantityText;
[SerializeField] private Image itemImage;


//============Item Description Slot================//
public Image ItemDescriptionImage;
public TMP_Text ItemDescriptionNameText;
public TMP_Text ItemDescriptionText;



public GameObject selectedShader;
public bool ThisItemIsSelected;

private InventoryManager inventoryManager;

private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        //Check to see if the slot is already full
        if(isFull)
            return quantity;

        //Update Name    
        this.itemName = itemName;

        //Update Image
        this.itemSprite = itemSprite;
        itemImage.gameObject.SetActive(true);
        itemImage.sprite = itemSprite;

        //Update Description
        this.itemDescription = itemDescription;

        //Update Quantity
        this.quantity += quantity;
        if (this.quantity >= MaxNumberOfItems)
        {
            quantityText.text = MaxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;
            //if (isFull == true)
            //{
               // quantityText.text = MaxNumberOfItems.ToString();
            //}

            //Return the leftovers
            int extraItems = this.quantity - MaxNumberOfItems;
            this.quantity = MaxNumberOfItems;
            return extraItems;
        }

        //Update the Quantity Text
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;
        return 0;

    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if(eventData.button == PointerEventData.InputButton.Right)
        {
             OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        ThisItemIsSelected = true;
        ItemDescriptionNameText.text = itemName;
        ItemDescriptionText.text = itemDescription;
        ItemDescriptionImage.sprite = itemSprite;
    }

    public void OnRightClick()
    {
        


    }

}
