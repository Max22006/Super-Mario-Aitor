using UnityEngine;

public class WallSensor : MonoBehaviour
{
     public bool isCollision;
     private Animator animator;
     private AudioSource _audioSource;
     public AudioClip killSFX;
     private BGMManager _bgmMusic;

     private GameManager _gameManager;
     
     
     void Awake()
    {
        animator = GameObject.Find("Mario_0").GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _bgmMusic = GameObject.Find("BGM Manager").GetComponent<BGMManager>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
       
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tuberias" || collision.gameObject.layer == 7)
        {
            isCollision = true;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            
            animator.SetBool("IsDeath", true);
            _bgmMusic.audioSource.Stop();
            _audioSource.PlayOneShot(killSFX);
            Destroy(collision.gameObject, 1.5f);

            StartCoroutine(_gameManager.DelayScene());
        }
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tuberias" || collision.gameObject.layer == 7)
        {
            isCollision = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tuberias" || collision.gameObject.layer == 7)
        {
            isCollision = false;
        }
    }
    
}
