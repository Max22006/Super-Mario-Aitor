using UnityEngine;

public class WallSensor : MonoBehaviour
{
     public bool isCollision;
     private Animator animator;
     private AudioSource _audioSource;
     public AudioClip killSFX;
     private BGMManager _bgmMusic;
     
     
     void Awake()
    {
        animator = GameObject.Find("Mario_0").GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _bgmMusic = GameObject.Find("BGM Manager").GetComponent<BGMManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tuberias" || collision.gameObject.layer == 7)
        {
            isCollision = true;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool.
            _bgmMusic.audioSource.Stop();
            _audioSource.PlayOneShot(killSFX);
            Destroy(collision.gameObject);
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
