using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public Vector3 startPosition;

    public float movementSpeed = 5f;
    public float jumpForce = 10;
    public float bounceForce = 4;

    public int direction = 1;

    private InputAction moveAction;
    private Vector2 moveDirection;
    private InputAction jumpAction;

    public Rigidbody2D rigidbody2D;
    private SpriteRenderer render;

    private GroundSensor sensor;

    private Animator animator;

    public AudioClip jumpSFX;
    private AudioSource _audioSource;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        render = GetComponent<SpriteRenderer>();

        sensor = GetComponentInChildren<GroundSensor>();

        animator = GetComponent<Animator>();

        _audioSource = GetComponent<AudioSource>();

        moveAction = InputSystem.actions["Move"];

        jumpAction = InputSystem.actions["Jump"];
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = startPosition; 
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x + direction * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        //transform.Translate(new Vector3(direction * movementSpeed * Time.deltaTime, 0, 0));

        //transform.position = Vector2.MoveTowards(transform.position, transform.position + new Vector3(10, 0, 0), movementSpeed * Time.deltaTime);

        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position. x + direction, transform.position.y), movementSpeed * Time.deltaTime);

        moveDirection = moveAction.ReadValue<Vector2>();

        //transform.position = new Vector3(transform.position.x + moveDirection.x * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        //transform.Translate(new Vector3(moveDirection.x * movementSpeed * Time.deltaTime, 0, 0));

       // transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + moveDirection.x, transform.position.y), movementSpeed * Time.deltaTime);
        
        rigidbody2D.linearVelocity = new Vector2(moveDirection.x * movementSpeed, rigidbody2D.linearVelocity.y);
        
        if (jumpAction.WasPressedThisFrame() && sensor.isGrounded)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
            _audioSource.PlayOneShot(jumpSFX);
        }

        animator.SetBool("IsJumping", !sensor.isGrounded);

        if (moveDirection.x > 0)
        {
            render.flipX = false;
            animator.SetBool("IsRunning", true);
        }
        else if (moveDirection.x < 0)
        {
            render.flipX = true;
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

    }
    public void Bounce()
    {
        rigidbody2D.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
    }
}
