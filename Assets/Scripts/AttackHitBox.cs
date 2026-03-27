using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    public int attackDamage = 3;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<Collider>().gameObject.layer == 7)
        {
             GoombaController _enemyScript = collision.gameObject.GetComponent<GoombaController>();
          _enemyScript.TakeDamage(attackDamage);
        }
    }
}
