using UnityEngine;

public class CoinSensor : MonoBehaviour

{
    private GameManager _gameManager;
    private BoxCollider2D _boxCollider2D;

    private AudioSource _audioSource;
     public AudioClip coinSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameManager.AddCoins();

            _audioSource.PlayOneShot(coinSFX);

            Destroy(gameObject, 0.5f);
        }
    }

}
