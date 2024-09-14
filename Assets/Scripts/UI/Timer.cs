// Time the game


using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timer;
    [SerializeField] PlayerHealth health;

    WaitForSeconds delay = new WaitForSeconds(1f);

    public static int hours, minutes, seconds;

    private void Start() {
        StartCoroutine(Time());
    }

    IEnumerator Time() {
        while (health.currentHealth > 0) {
            yield return delay;

            seconds++;

            if (seconds >= 60) {
                seconds = 0;
                minutes++;
            }

            if (minutes >= 60) {
                minutes = 0;
                hours++;
            }

            timer.text = hours.ToString("00.") + ":" + 
                minutes.ToString("00.") + ":" + 
                seconds.ToString("00.");
        }
    }

    public static int CalculateScore() {
        int score = 0;  
        score += hours * 60;  // Convert hours to minutes
        score += minutes * 60;  // Convert minutes to seconds
        score += seconds;

        return score;
    }

    public static string ConvertToTime(int totalSeconds) {
        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = totalSeconds % 60;
        return hours.ToString("00.") + ":" + minutes.ToString("00.") + ":" + seconds.ToString("00.");
    }
}
