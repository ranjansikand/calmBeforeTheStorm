// Spawns clouds


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    [SerializeField] float spawnInterval;

    WaitForSeconds delay;

    private void Start() {
        delay = new WaitForSeconds(spawnInterval);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn() {
        while (true) {
            float x = Random.Range(-1f, 1f) > 0 ? 50 : -50;
            float y = Random.Range(-1f, 1f) > 0 ? 50 : -50;

            Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(x, y, 0), Quaternion.identity);

            yield return delay;
        }
    }
}
