using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Player player;
    private Rigidbody2D rb;
    public int startingLives;
    public int Force;
    Vector2 moveInput;
    int jumpCounter;
    private bool isJumpingFinished;
    public Camera camera;
    private float cameraeOffSet;
    void Awake()
    {
        player = new Player(startingLives);
        rb = GetComponent<Rigidbody2D>();
        isJumpingFinished = true;
        cameraeOffSet = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(moveInput.x, 0f));

    }
    private void LateUpdate()
    {
        camera.transform.position = new Vector3(transform.position.x, transform.position.y + cameraeOffSet, camera.transform.position.z);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>().normalized;

    }
    void OnJump()
    {
        if (isJumpingFinished)
        {
            rb.AddForce(Vector2.up * Force, ForceMode2D.Impulse);
            ++jumpCounter;
            if (jumpCounter >= 2)
            {
                isJumpingFinished = false;
                jumpCounter = 0;
            }

        }
        Debug.Log("jump");

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumpingFinished = true;
        }
    }
}
