// AUtomatically delete the cannonballs


using UnityEngine;

public class Cannonball : MonoBehaviour
{
    private void Start() {
        Invoke(nameof(Delete), 1.5f);
    }

    void Delete() {
        if (gameObject.activeSelf) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        var damagedObj = other.gameObject.GetComponent<Health>();
        damagedObj?.Damage(PlayerStats.damage);

        Invoke(nameof(Delete), 0.01f);
    }
}
