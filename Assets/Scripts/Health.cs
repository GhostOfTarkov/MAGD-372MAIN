using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
  //  private ObjectPool objectPool;
    /*  void OnTriggerEnter2D()
      {
          health
      }
    */
    [Header("Max health of object")]
    public int maxHealth = 10;
    [SerializeField]
    protected int currentHealth = 0;
    int correctLayer;

 
    [Header("Does this object not lose health?")]
    [Tooltip("Some attacks require health to tell if they are enemies or not, but you can turn off taking damage using this")]
    public bool immortal = false;
    private IEnemy enemy;

    void Start()
    {
        correctLayer = gameObject.layer;
    }

    virtual protected void Awake()
    {
       
        if (maxHealth <= 0)
        {
            maxHealth = 1;
        }
        enemy = GetComponent<IEnemy>();
        currentHealth = maxHealth;
    }

    virtual public void TakeDamage(int amount)
    {
        
        if (!immortal)
        {
            if (enemy != null)
            {
                enemy.TakeDamage(amount);
            }
           
            currentHealth -= amount;

        }
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D()
    {
        currentHealth--;   
        if (CompareTag("Projectile"))
        {
            currentHealth--;
            if (currentHealth < 0)
            {
                 Die();
             }
        }    
        
    }
}
