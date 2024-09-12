// Spawns clouds


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] cloudPrefabs;

    WaitForSeconds delay = new WaitForSeconds(0.5f);

    private void Start() {
        StartCoroutine(SpawnStorm());
    }

    IEnumerator SpawnStorm() {
        while (true) {
            float x = Random.Range(-1f, 1f) > 0 ? 50 : -50;
            float y = Random.Range(-1f, 1f) > 0 ? 50 : -50;

            Instantiate(cloudPrefabs[Random.Range(0, cloudPrefabs.Length)], new Vector3(x, y, 0), Quaternion.identity);

            yield return delay;
        }
    }
}
