using UnityEngine;

public class GroundSensor : MonoBehaviour
{

    PlayerControler _playerScript;
    public int marioDamage = 3;

    public ParticleSystem _jumpParticle;
    
    void Awake ()
    {
        _playerScript = GetComponentInParent<PlayerControler>();

        
    }
    
    public bool isGrounded;

    void OnTriggerEnter2D(Collider2D collision)   
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = true;

            _jumpParticle.Play();
        }
        if (collision.gameObject.layer == 7)
        {
          //Destroy(collision.gameObject);  
          GoombaController _enemyScript = collision.gameObject.GetComponent<GoombaController>();
          _enemyScript.TakeDamage(marioDamage, Vector3.zero, 0);

          _playerScript.Bounce();
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
    if (collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = false;
        }
    }
}
