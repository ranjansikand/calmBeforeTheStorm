// Tracks gold

using System.Collections;
using UnityEngine;
using TMPro;

public class GoldCounter : MonoBehaviour
{
    [SerializeField] TMP_Text counter;
    [SerializeField] TurnNumber countPrefab;

    int currentValue = 0;

    WaitForSecondsRealtime delay = new WaitForSecondsRealtime(0.1f);


    private void OnEnable() {
        PlayerStats.goldChanged += UpdateValue;

        currentValue = PlayerStats.gold;
        counter.text = PlayerStats.gold.ToString();
    }

    private void OnDisable() {
        PlayerStats.goldChanged -= UpdateValue;
    }


    void UpdateValue() {
        TurnNumber newCount = Instantiate(
            countPrefab, 
            transform.position + new Vector3(0, -24, 0), 
            Quaternion.identity
        );

        int change = PlayerStats.gold - currentValue;

        if (change > 0) {
            newCount.Set("+ " + change);
        } else {
            newCount.Set(change.ToString());
            newCount.SetColor(Color.red);
        }

        StartCoroutine(AdjustValue(newCount, change));
    }

    IEnumerator AdjustValue(TurnNumber number, int change) {
        yield return delay;

        while (currentValue != PlayerStats.gold) {
            currentValue = (int)Mathf.MoveTowards(currentValue, PlayerStats.gold, 1);
            change = (int)Mathf.MoveTowards(change, 0, 1);

            counter.text = currentValue.ToString();
            number.Set(change.ToString());

            yield return delay;
        }

        currentValue = PlayerStats.gold;
        counter.text = PlayerStats.gold.ToString();

        yield return delay;
        Destroy(number.gameObject);
    }
}