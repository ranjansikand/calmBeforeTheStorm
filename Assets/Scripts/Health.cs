// Script that lets units be damaged


using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    public int currentHealth {get; set; }

    private void Awake() {
        currentHealth = maxHealth;
    }


    public void Damage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }
}
