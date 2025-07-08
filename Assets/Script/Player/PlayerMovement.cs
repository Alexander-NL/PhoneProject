using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private LayerMask wallLayer; // Assign "Wall" layer in Inspector

    private Rigidbody2D rb;
    private Vector2 lastInput;
    private Vector2 currentVelocity;
    private bool canChangeDirection = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
        moveAction.action.performed += OnMovementInput;
    }

    private void OnDisable()
    {
        moveAction.action.performed -= OnMovementInput;
        moveAction.action.Disable();
    }

    // Store input but don't apply it yet
    private void OnMovementInput(InputAction.CallbackContext context)
    {
        if (canChangeDirection)
        {
            lastInput = context.ReadValue<Vector2>().normalized;
            ApplyMovement();
            canChangeDirection = false; // Lock until next wall collision
        }
    }

    private void ApplyMovement()
    {
        rb.linearVelocity = lastInput * moveSpeed;
    }

    // Reset movement on wall collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsWall(collision.gameObject))
        {
            canChangeDirection = true; // Allow new input
        }
    }

    // Check if collided object is a wall (via Layer or Tag)
    private bool IsWall(GameObject obj)
    {
        return wallLayer == (wallLayer | (1 << obj.layer));
        // Alternative: return obj.CompareTag("Wall");
    }
}