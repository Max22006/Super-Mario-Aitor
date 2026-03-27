using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rBody2;
    public float bulletSpeed = 10;

    public int bulletDamage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _rBody2 = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        _rBody2.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Coin"))
        {
            return;
        } 
        if (collision.gameObject.layer == 7)
        {
          GoombaController _enemyScript = collision.gameObject.GetComponent<GoombaController>();
          _enemyScript.TakeDamage(bulletDamage);
        }
          Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
