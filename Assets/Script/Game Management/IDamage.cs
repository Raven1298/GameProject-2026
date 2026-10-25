using UnityEngine;

public interface IDamage
{
    public void Damage(float damageAmount);

    public bool HasTakenDamage  {get; set;}
} 
