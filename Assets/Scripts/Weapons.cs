// Script controlling the player's attacking abilities


using UnityEngine;
using UnityEngine.InputSystem;

public class Weapons : MonoBehaviour
{
    Controls controls;

    private void Awake() {
        controls = new Controls();
    }

    private void OnEnable() {
        controls.Enable();

        controls.Player.LeftCannons.performed += OnLeftCannons;
        controls.Player.RightCannons.performed += OnRightCannons;
        controls.Player.ForwardCannon.performed += OnForwardCannon;
        controls.Player.Mine.performed += OnMine;
    }


    private void OnDisable() {
        controls.Disable();

        
        controls.Player.LeftCannons.performed -= OnLeftCannons;
        controls.Player.RightCannons.performed -= OnRightCannons;
        controls.Player.ForwardCannon.performed -= OnForwardCannon;
        controls.Player.Mine.performed -= OnMine;
    }

    private void OnLeftCannons(InputAction.CallbackContext context) {

    }

    
    private void OnRightCannons(InputAction.CallbackContext context) {
        
    }

    private void OnForwardCannon(InputAction.CallbackContext context) {
        
    }

    private void OnMine(InputAction.CallbackContext context) {
        
    }

}
