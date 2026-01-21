using UnityEngine;

public class GoombaController : MonoBehaviour
{
    
    public float movementSpeed = 2f;
    public int direction = 1;

    private Rigidbody2D rigidbody2D;
    private Animator animator;
    public WallSensor sensor;
    private AudioSource _audioSource;
    public AudioClip deathSFX;
    private BoxCollider2D _boxCollider;
    private GameManager _gameManager;

    
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        sensor = GetComponentInChildren<WallSensor>();

        _audioSource = GetComponent<AudioSource>();

        _boxCollider = GetComponent<BoxCollider2D>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        
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
    public void GoombaDeath()
    {
        _gameManager.AddKill();
        //Destroy(gameObject.CompareTag("Wall Sensor"));
        sensor.enabled = false;

        _audioSource.PlayOneShot(deathSFX);

        //_audioSource.clip = deathSFX;
        //_audioSource.Play();

        movementSpeed = 0;

       _boxCollider.enabled = false;
       

        //WallSensor _sensorScript = collision.gameObject.GetComponent<WallSensor>();
        //sensor.isCollision = false;
        
        //Destroy(gameObject, 0.5f);
        


    }
}