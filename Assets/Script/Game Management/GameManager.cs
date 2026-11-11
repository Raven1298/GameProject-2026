using Unity.VisualScripting;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    
    private GameObject Player;
    bool playerFound = false;
    private playerMovement move;
    [SerializeField] private int volume;
    string up;
    string down;
    string run;
    int runSpeed;
    
    public void Start()
    {
        Player = GameObject.FindWithTag("Player");
        if(Player!=null)
        {        
            playerFound = true;
        }
    }

    
    public void ChangeVolume(int v)
    {
    volume = v;
    }
    public void changeRunSpeed(int s)
    {
         if(Player != null)
         {
          move = Player.GetComponent<playerMovement>();
          move.speed = s;
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
            playerFound = true;
        }
    }

    public bool IsPlayerFound()
    {
        Debug.Log(playerFound);
        return playerFound;
    }







}