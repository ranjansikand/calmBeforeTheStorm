// Enacts upgrades

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgPanel : MonoBehaviour
{
    [SerializeField] GameObject weapon, movement;

    [SerializeField] Ship playerShip;

    [SerializeField] TMP_Text acceleration, damage;

    int accelerationLevel = 1, damageLevel = 1;

    public void WeaponPanel() {
        UISFX.playClick(0);
        weapon.SetActive(true);
        movement.SetActive(false);
    }

    
    public void MovementPanel() {
        UISFX.playClick(0);
        weapon.SetActive(false);
        movement.SetActive(true);
    }


    #region Movement

    public void Acceleration() {
        if (PlayerStats.gold >= accelerationLevel * 5) {
            UISFX.playClick(0);

            PlayerStats.gold -= (accelerationLevel * 5);
            playerShip.thrustForce += 5;
            accelerationLevel++;
            acceleration.text = "Thrust (" + accelerationLevel + ") - $" + (accelerationLevel * 5);
        } else {
            UISFX.playClick(1);
        }
    }

    #endregion


    #region Weapons

    public void Damage() {
        if (PlayerStats.gold >= damageLevel * 5) {
            UISFX.playClick(0);

            PlayerStats.gold -= (damageLevel * 5);
            PlayerStats.damage++;
            damageLevel++;
            damage.text = "Damage (" + damageLevel + ") - $" + (damageLevel * 5);
        } else {
            UISFX.playClick(1);
        }
    }

    #endregion
}
