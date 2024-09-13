// Player-specific health


using UnityEngine;

public class PlayerHealth : Health
{
    SpriteRenderer sr;
    [SerializeField] Weapons weapons;
    [SerializeField] Ship ship;
    [SerializeField] Sprite[] sprites;
    [SerializeField] ParticleSystem explosion, smallExplosion;

    [SerializeField] Collider2D boxCollider;


    protected override void Awake() {
        sr = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;
    }

    
    public override void Damage(int damage) {
        base.Damage(damage);

        Debug.Log(Mathf.FloorToInt(1.0f * currentHealth / maxHealth));
        sr.sprite = sprites[Mathf.FloorToInt(1.0f * currentHealth / maxHealth)];

        if (currentHealth <= 0) {
            weapons.enabled = false;
            ship.enabled = false;
            boxCollider.enabled = false;

            Instantiate(explosion, transform);
        } else {
            Instantiate(smallExplosion, transform);
        }
    }
}
