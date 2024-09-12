// Enemy ship movement


using System.Collections;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 targetDirection;
    Vector2 boundsMin = new Vector2(-25f, -25f);
    Vector2 boundsMax = new Vector2(-25f, 25f);

    [SerializeField] float speed = 2f;
    [SerializeField] float turnSmoothness = 0.1f;
    [SerializeField] float directionChangeInterval = 3f;
    [SerializeField] float rotationSpeed = 200f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeDirectionRoutine());
    }

    void FixedUpdate()
    {
        MoveShip();
        RotateShipTowardsMovementDirection();

        if (transform.position.x > 50 || transform.position.y > 50) Destroy(gameObject);
    }

    private void MoveShip()
    {
        Vector2 newVelocity = Vector2.Lerp(rb.velocity, targetDirection * speed, turnSmoothness);
        rb.velocity = newVelocity;
    }

    private void RotateShipTowardsMovementDirection()
    {
        if (rb.velocity.magnitude > 0.1f)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg - 90f;
            float angleDifference = Mathf.DeltaAngle(rb.rotation, angle);
            float rotationAmount = Mathf.Clamp(angleDifference, -rotationSpeed * Time.fixedDeltaTime, rotationSpeed * Time.fixedDeltaTime);
            rb.rotation += rotationAmount;
        }
    }

    private IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            SetRandomTargetDirection();
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    private void SetRandomTargetDirection()
    {
        Vector2 randomPoint = new Vector2(
            Random.Range(boundsMin.x, boundsMax.x),
            Random.Range(boundsMin.y, boundsMax.y)
        );

        targetDirection = (randomPoint - rb.position).normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ReverseDirection();
    }

    private void ReverseDirection()
    {
        rb.velocity = -rb.velocity;
    }
}
