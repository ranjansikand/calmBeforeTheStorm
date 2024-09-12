// Script that lets units be damaged


using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] protected int maxHealth = 10;


    public int currentHealth {get; set; }

    protected virtual void Awake() {
        currentHealth = maxHealth;
    }


    public virtual void Damage(int damage) {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
    }
}
