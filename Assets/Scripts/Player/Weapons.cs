// Script controlling the player's attacking abilities


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapons : MonoBehaviour
{
    Controls controls;
    Rigidbody2D rb;

    [SerializeField] PlayerSFX sfx;

    [SerializeField] Transform leftCannons, rightCannons, forwardCannons;
    [SerializeField] Rigidbody2D cannonBall;

    [SerializeField] float firingForce = 6.0f;

    Coroutine firingRoutine;
    WaitForSeconds cannonLoadTime = new WaitForSeconds(1f);

    private void Awake() {
        controls = new Controls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        controls.Enable();

        controls.Player.LeftCannons.performed += OnLeftCannons;
        controls.Player.RightCannons.performed += OnRightCannons;
        controls.Player.ForwardCannon.performed += OnForwardCannon;
        controls.Player.LeftCannons.canceled += CancelFiring;
        controls.Player.RightCannons.canceled += CancelFiring;
        controls.Player.ForwardCannon.canceled += CancelFiring;
        controls.Player.Mine.performed += OnMine;
    }


    private void OnDisable() {
        controls.Disable();

        
        controls.Player.LeftCannons.performed -= OnLeftCannons;
        controls.Player.RightCannons.performed -= OnRightCannons;
        controls.Player.ForwardCannon.performed -= OnForwardCannon;
        controls.Player.LeftCannons.canceled -= CancelFiring;
        controls.Player.RightCannons.canceled -= CancelFiring;
        controls.Player.ForwardCannon.canceled -= CancelFiring;
        controls.Player.Mine.performed -= OnMine;
    }

    private void OnLeftCannons(InputAction.CallbackContext context) {
        firingRoutine = StartCoroutine(LeftSideCannons());
    }

    
    private void OnRightCannons(InputAction.CallbackContext context) {
        firingRoutine = StartCoroutine(RightSideCannons());
    }

    private void OnForwardCannon(InputAction.CallbackContext context) {
        firingRoutine = StartCoroutine(ForwardCannons());
    }

    private void OnMine(InputAction.CallbackContext context) {
        
    }

    private void CancelFiring(InputAction.CallbackContext context) {
        StopCoroutine(firingRoutine);
        firingRoutine = null;
    }


    IEnumerator LeftSideCannons() {
        yield return cannonLoadTime;

        for (int i = 0; i < 5; i++) {
            Rigidbody2D projectile = Instantiate(cannonBall, leftCannons);
            projectile.velocity = rb.velocity;
            projectile.transform.localPosition = new Vector3(Random.Range(-1f, 1f), 0, 0);
            projectile.AddForce(leftCannons.up * firingForce, ForceMode2D.Impulse);
        }

        sfx.PlaySound(3);
    }

    IEnumerator RightSideCannons() {
        yield return cannonLoadTime;

        for (int i = 0; i < 5; i++) {    
            Rigidbody2D projectile = Instantiate(cannonBall, rightCannons);
            projectile.velocity = rb.velocity;
            projectile.transform.localPosition = new Vector3(Random.Range(-1f, 1f), 0, 0);
            projectile.AddForce(rightCannons.up * firingForce, ForceMode2D.Impulse);
        }

        sfx.PlaySound(3);
    }

    IEnumerator ForwardCannons() {
        yield return cannonLoadTime;

        for (int i = 0; i < 2; i++) {    
            Rigidbody2D projectile = Instantiate(cannonBall, forwardCannons);
            projectile.transform.localPosition = new Vector3(Random.Range(-1f, 1f), 0, 0);
            projectile.AddForce(forwardCannons.up * firingForce, ForceMode2D.Impulse);
        }

        sfx.PlaySound(3);
    }
}
