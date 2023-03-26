using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int amount = (int)1f;
    public string targetTag = "Enemy";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(amount);
            }
        }

        Destroy(gameObject);
    }
}

  /*  public void TakeDamage(int amount)
    {
        Destroy(gameObject);
    }

    public void WhenDead()
    {
        
            dead = true;
       
    } */

