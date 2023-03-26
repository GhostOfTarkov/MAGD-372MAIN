using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{

    [Header("Does the player start with full health?")]
    public bool startsFullHealth = true;
    int startingHealth = -1;

    override protected void Awake()
    {
        if (maxHealth <= 0)
        {
         
            maxHealth = 1;
        }

        dead = false;
        if (startsFullHealth) currentHealth = startingHealth = maxHealth;
        else startingHealth = currentHealth;
    }

    override public void TakeDamage(int amount)
    {
        if (!dead && !immortal)
        {
            currentHealth -= amount;
     
            if (currentHealth <= 0) WhenDead();
        }
    }

    override public void WhenDead()
    {
        if (!immortal)
        {
            dead = true;
        }
    }


    override public void revive()
    {
        currentHealth = startingHealth;
        dead = false;
    }
}
