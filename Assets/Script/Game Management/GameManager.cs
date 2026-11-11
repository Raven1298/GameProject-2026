using Unity.VisualScripting;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    
    private GameObject Player;
    [SerializeField]bool playerFound = false;
    private playerMovement move;
    public float volume;
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
        return move.speed;
    }
    public float GetDash()
    {
        return move.dashSpeed;
    }






}