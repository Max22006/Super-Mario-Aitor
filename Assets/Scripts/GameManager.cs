using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int killedEnemies = 0;
    public int collectedCoins = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddKill()
    {
        killedEnemies++;
    }
    public void AddCoins()
    {
        collectedCoins++;
    }
}
