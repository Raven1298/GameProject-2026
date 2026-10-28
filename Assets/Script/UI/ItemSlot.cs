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

public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        this.itemDescription = itemDescription;
        isFull = true;

        itemImage.gameObject.SetActive(true);
        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemSprite;


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
