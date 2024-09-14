// Title screen


using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene("Play");
    }
}
