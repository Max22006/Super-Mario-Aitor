using UnityEngine;
using UnityEngine.UI;

public class GoombaController : MonoBehaviour
{
    
    public float movementSpeed = 2f;
    public int direction = 1;
    private int _goombaHealth = 3;

    private Rigidbody2D rigidbody2D;
    private Animator animator;
    public WallSensor sensor;
    private AudioSource _audioSource;
    public AudioClip deathSFX;
    private BoxCollider2D _boxCollider;
    private GameManager _gameManager;
    private Slider _healthSlider;

    public Transform[] patrolPoints;
    public int patrolIndex = 0;


    private Transform _playerPosition;  
    public float detectionRange = 5;  
    public float attackRange = 2;
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        sensor = GetComponentInChildren<WallSensor>();

        _audioSource = GetComponent<AudioSource>();

        _boxCollider = GetComponent<BoxCollider2D>();

        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        _healthSlider = GetComponentInChildren<Slider>();

        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        
    }

    void Start()
    {
        _healthSlider.maxValue = _goombaHealth;
        _healthSlider.value = _goombaHealth;

    }

    void FixedUpdate()
    {
        //rigidbody2D.linearVelocity = new Vector2(direction * movementSpeed, rigidbody2D.linearVelocity.y);

        //if (sensor.isCollision)
        //{
           // direction *= -1;
       // }
      
       float distanceToPlayer = Vector3.Distance(_playerPosition.position, transform.position);

       if(distanceToPlayer > detectionRange)
       {
        Patrol();
       }
       else if(distanceToPlayer < detectionRange && distanceToPlayer > attackRange)
       {
        FollowPlayer();
       }
       else if (distanceToPlayer < attackRange)
       {
            Attack(); 
       }

    }
    void Patrol ()
    {
        
        float distanceToPoint = Vector3.Distance(transform.position, patrolPoints[patrolIndex].position);

        if (distanceToPoint < 0.5f)
        {
            if(patrolIndex == 0)
            {
                patrolIndex = 1;
            }
            else
            {
                patrolIndex = 0;
            }
        }

        Vector3 moveDirection = patrolPoints[patrolIndex].position - transform.position;

        Movement(moveDirection);
    }
    void FollowPlayer()
    {
        Vector3 moveDirection = _playerPosition.position - transform.position;

        Movement(moveDirection);
    }
    void Movement(Vector3 moveDirection)
    {
        if (moveDirection.x < 0)
        {
            direction = -1;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(moveDirection.x > 0)
        {
            direction = 1;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        rigidbody2D.linearVelocity = new Vector2(direction * movementSpeed, rigidbody2D.linearVelocity.y);
    }
    void Attack()
    {
        direction = 0;
        Debug.Log("Atacando");
    }
    public void TakeDamage(int damage, Vector3 impactDirection, float impactForce)
    {
        _goombaHealth -= damage;
        _healthSlider.value = _goombaHealth;

        rigidbody2D.AddForce(impactDirection * impactForce, ForceMode2D.Impulse);

        if (_goombaHealth <= 0)
        {
            GoombaDeath();
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