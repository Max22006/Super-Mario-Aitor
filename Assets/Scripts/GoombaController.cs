using UnityEngine;

public class GoombaControl : MonoBehaviour
{
    public Vector3 startPosition;
    public float movementSpeed = 2f;
    public int direction = 1;

    public Rigidbody2D rigidbody2D;
    private Animator animator;
    private WallSensor sensor;
    
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        sensor = GetComponentInChildren<WallSensor>();
    }

    void Start()
    {
        transform.position = startPosition;
    }

    void Update()
    {
        rigidbody2D.linearVelocity = new Vector2(movementSpeed, rigidbody2D.linearVelocity.y);

        if (sensor.isCollision)
        {
            movementSpeed *= -1;
        }

    }
}