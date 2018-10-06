using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : DamageableObject
{
    public int currentHealth;
    public int maxHealth;
    public int regenPerSecond;

    public Slider healthbar;

    public void Update()
    {
        currentHealth = Mathf.Min(currentHealth + (int)(regenPerSecond * Time.deltaTime), maxHealth);
        healthbar.value = (float)currentHealth / (float)maxHealth;
    }

    public override void damage(int damage)
    {
        Debug.Log(currentHealth);
        currentHealth -= damage;
        Debug.Log(currentHealth);
        Debug.Log((float)currentHealth / (float)maxHealth);
    }

    public void heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }
}