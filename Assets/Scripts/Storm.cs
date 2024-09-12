// Script for storm clouds to damage other objects


using UnityEngine;

public class Storm : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        var damagedObj = other.gameObject.GetComponent<Health>();
        damagedObj?.Damage(10);
    }
}
