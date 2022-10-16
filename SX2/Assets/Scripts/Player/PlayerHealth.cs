using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float currentHealth, maxHealth = 10f;
    [SerializeField] private float interval = 2f;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    } 
    
    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if(gameObject.GetComponent<PlayerMovement>().enabled)
        {
            FindObjectOfType<AudioManager>().Play("Hit");
        }

        if (currentHealth <= 0)
        {
            StartCoroutine(StunPlayer());
        }
    }

    IEnumerator StunPlayer()
    {
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponentInChildren<PlayerShoot>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(interval);
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        gameObject.GetComponentInChildren<PlayerShoot>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        currentHealth = maxHealth;
    }
}
