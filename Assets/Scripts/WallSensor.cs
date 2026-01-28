using UnityEngine;

public class WallSensor : MonoBehaviour
{
     public bool isCollision;
     private Animator animator;
     
     void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tuberias" || collision.gameObject.layer == 7)
        {
            isCollision = true;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
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
