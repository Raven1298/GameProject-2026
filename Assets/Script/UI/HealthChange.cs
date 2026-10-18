using UnityEngine;
using UnityEngine.UI;


public class HealthChange : MonoBehaviour
{

[SerializeField] private int health = 12;
//int maxHealth = 12;
[SerializeField] private Image H1;
[SerializeField] private Image H2;
[SerializeField] private Image H3;
[SerializeField] private Sprite Full;
[SerializeField] private Sprite P1;
[SerializeField] private Sprite P2;
[SerializeField] private Sprite P3;
[SerializeField] private Sprite Empt;


private PlayerHealth playerHealthScript;
private GameObject DeathScreen; 

void Start()
{
GameObject Player = GameObject.FindWithTag("Player");
playerHealthScript = Player.GetComponent<PlayerHealth>();
health = playerHealthScript.health;   
//DeathScreen = GameObject.FindWithTag("Death");
}


void Update()
{

    health = playerHealthScript.health;   

    if(health==12)
    {
    H1.sprite = Full;
    H2.sprite = Full;
    H3.sprite = Full;
    }
    else if(health==11)
    {
    H1.sprite = Full;
    H2.sprite = Full;
    H3.sprite = P1;
    }
    else if(health==10)
    {
    H1.sprite = Full;
    H2.sprite = Full;
    H3.sprite = P2;         
    }
    else if(health==9)
    {
    H1.sprite = Full;
    H2.sprite = Full;
    H3.sprite = P3;      
    }
    else if(health==8)
    {
    H1.sprite = Full;
    H2.sprite = Full;
    H3.sprite = Empt;      
    }
    else if(health==7)
    {
    H1.sprite = Full;
    H2.sprite = P1;
    H3.sprite = Empt;    
    }
    else if(health==6)
    {
    H1.sprite = Full;
    H2.sprite = P2;
    H3.sprite = Empt;    
    }else if(health==5)
    {
    H1.sprite = Full;
    H2.sprite = P3;
    H3.sprite = Empt;    
    }else if(health==4)
    {
    H1.sprite = Full;
    H2.sprite = Empt;
    H3.sprite = Empt;    
    }else if(health==3)
    {
    H1.sprite = P1;
    H2.sprite = Empt;
    H3.sprite = Empt;    
    }else if(health==2)
    {
    H1.sprite = P2;
    H2.sprite = Empt;
    H3.sprite = Empt;    
    }
    else if(health==1)
    {
    H1.sprite = P3;
    H2.sprite = Empt;
    H3.sprite = Empt;    
    }else if(health==0)
    {
    H1.sprite = Empt;
    H2.sprite = Empt;
    H3.sprite = Empt;
    DeathScreen.SetActive(true);    
    }



}


    void GetHealth()
    {
        //int T = PlayerHealth.



    }

    

}