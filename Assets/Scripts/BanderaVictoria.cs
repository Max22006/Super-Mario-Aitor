using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;
    private AudioSource _audioSource;
    public AudioClip flagSFX;
    private BGMManager _bgmMusic;
    private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
        _bgmMusic = GameObject.Find("BGM Manager").GetComponent<BGMManager>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _bgmMusic.audioSource.Stop();
            _audioSource.PlayOneShot(flagSFX);
            StartCoroutine(_gameManager.DelayVictory());

        }
    }
}
