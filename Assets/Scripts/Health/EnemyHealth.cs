using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EnemyHealth : Health
{

    public delegate void deathEvent();

    public static event deathEvent EnemyDeath;

    override public void TakeDamage(int amount)
    {
        if (!dead && !immortal)
        {
            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                dead = true;

                if (EnemyDeath != null)
                {
                    EnemyDeath();
                }

                if (GetComponent<Rigidbody2D>())
                {
                    Rigidbody2D rb = GetComponent<Rigidbody2D>();
                    rb.bodyType = RigidbodyType2D.Static;
                }
                
                foreach (Collider2D a in GetComponents<Collider2D>()) a.enabled = false;

                Invoke("WhenDead", 0.1f);
            }
         
        }
    }

    override public void WhenDead()
    {
        if (!immortal)
        {
            Destroy(gameObject);
        }
    }

    protected override void Awake()
    {
        base.Awake();
    }
}