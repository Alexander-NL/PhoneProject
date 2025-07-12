using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float swipeThreshold = 50f; // Minimum swipe distance in pixels
    public bool canChangeDirection = true;

    [Header("Layer Masks")]
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LayerMask enemyLayer;

    [Header("References")]
    public PlayerHealth playerHealth;

    private Rigidbody2D rb;
    private Vector2 lastInput;
    private Vector2 touchStartPos;
    
    private bool isDead;
    private bool isTouching;
    private bool playerWon;

    public bool isPaused;
    private Vector2 prePauseVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerWon = false;
    }


    private void OnEnable()
    {
        InputSystem.EnableDevice(Touchscreen.current);
    }


    private void Update()
    {
        HandleTouchInput();
    }

    public void PlayerWon()
    {
        playerWon = !playerWon;
    }
    public void PauseMovement()
    {
        if (isPaused) return;

        isPaused = true;
        prePauseVelocity = rb.linearVelocity;
        rb.linearVelocity = Vector2.zero;
        rb.simulated = false;
    }

    public void ResumeMovement()
    {
        if (!isPaused) return;

        isPaused = false;
        rb.simulated = true;
        rb.linearVelocity = prePauseVelocity;
    }


    /// <summary>
    /// to get the touch & swipe input
    /// </summary>
    private void HandleTouchInput()
    {
        var touch = Touchscreen.current.primaryTouch;

        if (touch.press.wasPressedThisFrame)
        {
            touchStartPos = touch.position.ReadValue();
            isTouching = true;
        }

        if (isTouching && touch.press.wasReleasedThisFrame)
        {
            isTouching = false;
            Vector2 touchEndPos = touch.position.ReadValue();
            ProcessSwipe(touchEndPos);
        }
    }

    /// <summary>
    /// Check if player is dead before taking swipe input
    /// </summary>
    /// <param name="touchEndPos"></param>
    private void ProcessSwipe(Vector2 touchEndPos)
    {
        if (isPaused || isDead || !canChangeDirection || playerWon) return;

        Vector2 swipeDelta = touchEndPos - touchStartPos;
        if (swipeDelta.magnitude < swipeThreshold) return;

        swipeDelta.Normalize();

        if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
        {
            lastInput = new Vector2(Mathf.Sign(swipeDelta.x), 0); // Left or Right
        }
        else
        {
            lastInput = new Vector2(0, Mathf.Sign(swipeDelta.y)); // Up or Down
        }

        ApplyMovement();
        canChangeDirection = false;
    }

    private void ApplyMovement()
    {
        rb.linearVelocity = lastInput * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsWall(collision.gameObject))
        {
            canChangeDirection = true;
        }

        if (IsEnemy(collision.gameObject))
        {
            playerHealth.ReduceHP();
        }
    }

    /// <summary>
    /// to turn on the bool since its a private boolean
    /// </summary>
    public void IsDead()
    {
        isDead = true;  
    }

    private bool IsEnemy(GameObject obj)
    {
        return enemyLayer == (enemyLayer | (1 << obj.layer));
    }

    private bool IsWall(GameObject obj)
    {
        return wallLayer == (wallLayer | (1 << obj.layer));
    }
}