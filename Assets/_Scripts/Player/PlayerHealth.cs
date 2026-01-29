using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public TextMeshProUGUI health;

    public int regenAmount = 2;
    public float regenInterval = 10f;

    float lastDamageTimer;
    float regenTimer;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void Update()
    {
        HealthRegen();
    }

    void HealthRegen()
    {
        //Regen if no damage in last 10 seconds
        if (Time.time - lastDamageTimer >= regenInterval)
        {
            regenTimer += Time.deltaTime;

            if (regenTimer >= regenInterval)
            {
                Heal(regenAmount);
                regenTimer = 0f;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(5);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(5);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        lastDamageTimer = Time.time;
        regenTimer = 0f; //reset timer

        UpdateHealthUI();
    }



    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        health.text = "Health: " + currentHealth;
    }
}
