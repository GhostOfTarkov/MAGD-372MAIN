using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamageable
{
    [Header("Max health of object")]
    public int maxHealth = 10;
    [SerializeField]
    protected int currentHealth = 0;

    [Header("Does this object not lose health?")][Tooltip("Some attacks require health to tell if they are enemies or not, but you can turn off taking damage using this")]
    public bool immortal = false;

    public bool dead { get; protected set; }

    virtual protected void Awake()
    {
        if (maxHealth <= 0)
        {
            maxHealth = 1;
        }

        dead = false;
        currentHealth = maxHealth;
    }

    virtual public void TakeDamage(int amount)
    {
        if (!dead && !immortal)
        {
            currentHealth -= amount;
            if (currentHealth <= 0) WhenDead();
    
        }
    }

    virtual public void WhenDead()
    {
        if(!immortal) Debug.LogWarning(gameObject.name + " is dead.", gameObject);
    }


    virtual public void revive()
    {
        currentHealth = maxHealth;
        dead = false;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
