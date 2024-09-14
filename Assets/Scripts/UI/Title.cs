// Title screen


using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] GameObject controlPanel;

    public void Play() {
        SceneManager.LoadScene("Play");
    }

    public void Controls() {
        controlPanel.SetActive(!controlPanel.activeSelf);
    }
}
