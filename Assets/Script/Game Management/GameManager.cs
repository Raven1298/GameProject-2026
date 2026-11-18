using Unity.VisualScripting;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    
    private GameObject Player;
    [SerializeField]bool playerFound = false;
    private playerMovement move;
    private InventoryManager inventoryManager;
    public float volume = 1;
    string up;
    string down;
    string run;
    int runSpeed;

    public string lastscene = "";
    
    public void Start()
    {
        Player = GameObject.FindWithTag("Player");
        if(Player!=null)
        {        
            move = Player.GetComponent<playerMovement>();
            playerFound = true;
        }
        inventoryManager = FindAnyObjectByType<InventoryManager>();

    }

    
    public void changeVolume(float v)
    {
    volume = v;
    }
    public void changeWalkSpeed(int s)
    {
         if(Player != null)
         {
          move.speed = s;
         }
         else
        {
            move.speed = 10;
            Debug.Log("Failed to Set Speed");
        }
    }
    public void changeDashSpeed(int s)
    {
         if(Player != null)
         {
          move = Player.GetComponent<playerMovement>();
          move.dashSpeed = s;
         }
    }
    public void ChangeJumpHeight(int j)
    {
        if(Player != null)
         {
            Debug.Log("GameManager!");
          move = Player.GetComponent<playerMovement>();
          move.jumpForce = j;
         } 
    }
    public void FindPlayer()
    {

        Player = GameObject.FindWithTag("Player");
        if(Player!=null)
        {   
            move = Player.GetComponent<playerMovement>();
            playerFound = true;
        }
    }

    public bool IsPlayerFound()
    {
        return playerFound;
    }

    public void LastScene(string name)
    {
            lastscene = name;
            Debug.Log(lastscene);
    }

    public float GetMove()
    {
        if(move!=null)
        {
        return move.speed;
        }
        else
        {
        return 5;
        }
    }
    public float GetDash()
    {
        if(move!=null)
        {
        return move.dashSpeed;
        }
        else
        {
          return 7;  
        }
    }

    public void ClearInventory()
    {
        if(inventoryManager==null){inventoryManager = FindAnyObjectByType<InventoryManager>();}
        inventoryManager.RemoveInventory();
    }




}