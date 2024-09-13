// Turn counter number


using UnityEngine;
using TMPro;

public class TurnNumber : MonoBehaviour {
    public TMP_Text counter;

    public void Set(string text) {
        counter.text = text;
    }

    public void SetColor(Color color) {
        counter.color = color;
    }
}