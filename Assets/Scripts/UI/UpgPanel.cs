// Enacts upgrades

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgPanel : MonoBehaviour
{
    [SerializeField] GameObject weapon, movement;

    [SerializeField] Ship playerShip;
    [SerializeField] Weapons playerWeapon;


    // Movement
    [SerializeField] TMP_Text acceleration, maxSpeed, rotation;
    int accelerationLevel = 1, speedLevel = 1, rotLevel;

    // Weapons
    [SerializeField] TMP_Text damage, range;
    int damageLevel = 1, rangeLevel = 1;

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

    public void MaxSpeed() {
        if (PlayerStats.gold >= speedLevel * 5) {
            UISFX.playClick(0);

            PlayerStats.gold -= (speedLevel * 5);
            playerShip.maxSpeed += 3;
            speedLevel++;
            maxSpeed.text = "Speed (" + speedLevel + ") - $" + (speedLevel * 5);
        } else {
            UISFX.playClick(1);
        }
    }

    public void Rotation() {
        if (PlayerStats.gold >= rotLevel * 5) {
            UISFX.playClick(0);

            PlayerStats.gold -= (rotLevel * 5);
            playerShip.rotationSpeed += 3;
            rotLevel++;
            rotation.text = "Rotation (" + rotLevel + ") - $" + (rotLevel * 5);
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

    public void Range() {
        if (PlayerStats.gold >= rangeLevel * 5) {
            UISFX.playClick(0);

            PlayerStats.gold -= (rangeLevel * 5);
            playerWeapon.firingForce++;
            rangeLevel++;
            range.text = "Range (" + rangeLevel + ") - $" + (rangeLevel * 5);
        } else {
            UISFX.playClick(1);
        }
    }

    #endregion
}
