using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[AddComponentMenu("AnhDuy/Player")]

public interface ICanTakeDamage
{
    void TakeDamage(GameObject source, int amount);
}


public class Player : MonoBehaviour, ICanTakeDamage
{
    public int MaxHealth { get; private set; } = 100;
    public int CurrentHealth { get; private set; }
    private Animator anim;
    private int isDeadId;
     private PlayerControl playerController;
     private PlayerAttack playerAttack;

  
    void Start()
    {
        CurrentHealth = MaxHealth;
        anim=GetComponentInChildren<Animator>();
        isDeadId=Animator.StringToHash("isDead");
        if (PlayerHealth.Instance != null)
        {
            PlayerHealth.Instance.SetMaxHealth(MaxHealth);
        }
        else
        {
            Debug.LogError("PlayerHealth instance is not set.");
        }
    }

    
    public void TakeDamage(GameObject source, int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Damage amount cannot be negative.");

        CurrentHealth -= amount;
        if (CurrentHealth < 0) 
           { CurrentHealth = 0;
            Dead();
           }
        if (PlayerHealth.Instance != null)
        {
            PlayerHealth.Instance.SetHealth(CurrentHealth);
        }
        else
        {
            Debug.LogError("PlayerHealth instance is not set.");
        }

        
    }
    private void Dead()
    {
        anim.SetTrigger(isDeadId);
        if (playerController != null||playerAttack!=null)
        {
            playerController.enabled = false;
            playerAttack.enabled=false;     
        }

        StartCoroutine(DestroyAfterDelay(1f));
    }
      private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 
        Destroy(gameObject); 
    }
}
