using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour, IDamagable
{
    protected Target owner = null;   

    public void Setup(Target newOwner)
    {
        owner = newOwner;      
    }
    
    
    public void Damage(int amount)
    {
        //Damage owner        
        owner.TakeDamage(amount);
        ArenaScoreSystem.theScore += 500;
    }  


}
