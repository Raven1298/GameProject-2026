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




[SerializeField] private Image Claire;
[SerializeField] private Sprite HealthyClaire;
[SerializeField] private Sprite PartialDamageClaire;
[SerializeField] private Sprite FullDamageClaire;

private PlayerHealth playerHealthScript;
private GameObject DeathScreen; 

private bool on;

void Start()
{
on = true;
GameObject Player = GameObject.FindWithTag("Player");
playerHealthScript = Player.GetComponent<PlayerHealth>();
health = playerHealthScript.health;   
//DeathScreen = GameObject.FindWithTag("Death");
}


void Update()
{

    health = playerHealthScript.health;   

    if(health>=12)
    {
    H1.sprite = Full;
    H2.sprite = Full;
    H3.sprite = Full;
    Claire.sprite = HealthyClaire;
    }
    else if(health==11)
    {
    H1.sprite = Full;
    H2.sprite = Full;
    H3.sprite = P1;
    Claire.sprite = HealthyClaire;
    }
    else if(health==10)
    {
    H1.sprite = Full;
    H2.sprite = Full;
    H3.sprite = P2;
    Claire.sprite = PartialDamageClaire;         
    }
    else if(health==9)
    {
    H1.sprite = Full;
    H2.sprite = Full;
    H3.sprite = P3;  
    Claire.sprite = PartialDamageClaire;         
    }
    else if(health==8)
    {
    H1.sprite = Full;
    H2.sprite = Full;
    H3.sprite = Empt;   
    Claire.sprite = PartialDamageClaire;         
    }
    else if(health==7)
    {
    H1.sprite = Full;
    H2.sprite = P1;
    H3.sprite = Empt;
    Claire.sprite = PartialDamageClaire;         
    }
    else if(health==6)
    {
    H1.sprite = Full;
    H2.sprite = P2;
    H3.sprite = Empt;   
    Claire.sprite = PartialDamageClaire;         
    }
    else if(health==5)
    {
    H1.sprite = Full;
    H2.sprite = P3;
    H3.sprite = Empt;  
    Claire.sprite = PartialDamageClaire;         
    }else if(health==4)
    {
    H1.sprite = Full;
    H2.sprite = Empt;
    H3.sprite = Empt;    
    Claire.sprite = FullDamageClaire;         
    }else if(health==3)
    {
    H1.sprite = P1;
    H2.sprite = Empt;
    H3.sprite = Empt;    
    Claire.sprite = FullDamageClaire;         
    }else if(health==2)
    {
    H1.sprite = P2;
    H2.sprite = Empt;
    H3.sprite = Empt;    
    Claire.sprite = FullDamageClaire;         
    }
    else if(health==1)
    {
    H1.sprite = P3;
    H2.sprite = Empt;
    H3.sprite = Empt;
    Claire.sprite = FullDamageClaire;         
    }
    else if(health<=0)
    {
    H1.sprite = Empt;
    H2.sprite = Empt;
    H3.sprite = Empt;
    Claire.sprite = FullDamageClaire;         
    //DeathScreen.SetActive(true);    
    }



}


    public void ToggleHUDImages()
    {
        if(on == true)
        {
        H1.gameObject.SetActive(false); 
        H2.gameObject.SetActive(false); 
        H3.gameObject.SetActive(false); 
        Claire.gameObject.SetActive(false);
        on = false;
        }
        else if(on == false)
        {
        H1.gameObject.SetActive(true); 
        H2.gameObject.SetActive(true); 
        H3.gameObject.SetActive(true); 
        Claire.gameObject.SetActive(true);
        on = true;

        }

    }

    

}