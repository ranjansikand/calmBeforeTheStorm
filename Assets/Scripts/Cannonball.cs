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
}
