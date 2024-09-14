// Lets enemies get shot


using System.Collections;
using UnityEngine;

public class EnemyHealth : Health
{
    AudioSource audioSource;
    Coroutine deleteRoutine;
    WaitForSeconds delay = new WaitForSeconds(0.1f);
    
    [SerializeField] ParticleSystem explosion;
    [SerializeField] AudioClip destroySound;

    private void OnEnable() {
        audioSource = GetComponent<AudioSource>();
    }

    public override void Damage(int damage) {
        base.Damage(damage);

        if (currentHealth <= 0) {
            Instantiate(explosion, transform.position, Quaternion.identity);

            if (deleteRoutine == null) {
                deleteRoutine = StartCoroutine(Delete());
            }
        }
    }

    IEnumerator Delete() {
        yield return delay;

        PlayerStats.gold += 5;
        Destroy(gameObject);
    }
}
