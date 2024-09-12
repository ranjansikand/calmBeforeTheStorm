// Script to move clouds across the map

using System.Collections;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        StartCoroutine(Move());
    }

    IEnumerator Move() {
        while (true) {
            float time = Random.Range(1f, 20f);
            
            Vector3 destination = new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), 0);
            Vector3 direction = (destination - transform.position).normalized * 4f;
            
            rb.velocity = direction;
            yield return new WaitForSeconds(time);
        }
    }
}
