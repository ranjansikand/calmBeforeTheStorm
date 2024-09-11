// Player ship controls


using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour
{
    Controls controls;
    Rigidbody2D rb;

    float inputRotation, inputSails;

    [SerializeField] float rotationSpeed = 3f;
    [SerializeField] float thrustForce = 5f;
    [SerializeField] float maxSpeed = 10f;
    [SerializeField] float turnSmoothness = 0.5f;


    private void Awake() {
        controls = new Controls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        controls.Enable();
        controls.Player.Sails.performed += OnSailsInput;
        controls.Player.Sails.canceled += OnSailsInput;
        controls.Player.Rotate.performed += OnRotateInput;
        controls.Player.Rotate.canceled += OnRotateInput;
    }

    private void OnDisable() {
        controls.Disable();
        controls.Player.Sails.performed -= OnSailsInput;
        controls.Player.Sails.canceled -= OnSailsInput;
        controls.Player.Rotate.performed -= OnRotateInput;
        controls.Player.Rotate.canceled -= OnRotateInput;
    }

    private void OnSailsInput(InputAction.CallbackContext context) {
        inputSails = context.ReadValue<float>();
    }

    private void OnRotateInput(InputAction.CallbackContext context) {
        inputRotation = context.ReadValue<float>();
    }

    private void FixedUpdate() {
        if (inputSails != 0) {
            Vector2 force = transform.up * inputSails * thrustForce;
            rb.AddForce(force);

            // Speed limit
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }

        if (inputRotation != 0) {
            float rotation = inputRotation * rotationSpeed * Time.fixedDeltaTime;

            rb.MoveRotation(rb.rotation - rotation);
        }

        AdjustVelocityToDirection();
    }

    private void AdjustVelocityToDirection() {
        Vector2 forward = transform.up;
        float speed = rb.velocity.magnitude;
        Vector2 newVelocity = forward * speed;

        rb.velocity = Vector2.Lerp(rb.velocity, newVelocity, turnSmoothness * Time.fixedDeltaTime); 
    }
}
