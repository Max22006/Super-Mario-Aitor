using UnityEngine;

public class GoombaControl : MonoBehaviour
{
    
    public float movementSpeed = 2f;
    public int direction = 1;

    private Rigidbody2D rigidbody2D;
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
        
    }

    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(direction * movementSpeed, rigidbody2D.linearVelocity.y);

        if (sensor.isCollision)
        {
            direction *= -1;
        }

    }
   // void OnCollisionEnter2D(Collider2D collision)
    //{
        //if (collision.gameObject.tag == "Tuberias")
      //  {
            
       // }
   // }
}