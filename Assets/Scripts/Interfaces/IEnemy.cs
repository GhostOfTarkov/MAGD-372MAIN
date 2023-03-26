using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy 
{
    int Health { get; set; }
    void TakeDamage(float projDamage);
    void Die();
}
