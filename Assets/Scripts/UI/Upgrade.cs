// Base script for the upgrade panel
// Controls opening and closing the panel


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] GameObject upgradePanel;

    public void OpenPanel() {
        UISFX.playClick(0);
        upgradePanel.SetActive(true);

        Time.timeScale = 0;
    }

    public void ClosePanel() {
        UISFX.playClick(1);
        upgradePanel.SetActive(false);

        Time.timeScale = 1;
    }
}
