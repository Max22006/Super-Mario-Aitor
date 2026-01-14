using UnityEngine;

public class WallSensor : MonoBehaviour
{
     public bool isCollision;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            isCollision = true;
        }
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            isCollision = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            isCollision = false;
        }
    }
    
}
