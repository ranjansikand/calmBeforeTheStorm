// Lets enemies get shot


using UnityEngine;

public class EnemyHealth : Health
{
    
    [SerializeField] ParticleSystem explosion;

    public override void Damage(int damage) {
        base.Damage(damage);

        if (currentHealth <= 0) {
            Instantiate(explosion, transform.position, Quaternion.identity);

            Invoke(nameof(Delete), 0.1f);
        }
    }

    void Delete() {
        PlayerHealth.playerGold += 5;
        Destroy(gameObject);
    }
}
