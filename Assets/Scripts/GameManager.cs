using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public int killedEnemies = 0;
    public int collectedCoins = 0;

    public Text goombaText;
    public Text coinText;

    public bool _pause;
    public GameObject pauseCanvas;
    public GameObject victoryCanvas;

    public List<GameObject> enemiesInScreen;
    

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.K))
       {
            KillEnemiesInScreen();
       } 
    }
    void KillEnemiesInScreen()
    {
        foreach (GameObject enemy in enemiesInScreen)
        {
            Destroy(enemy);
        }
    }
    public void AddKill()
    {
        killedEnemies++;
        goombaText.text = killedEnemies.ToString();
    }
    public void AddCoins()
    {
        collectedCoins++;
        coinText.text = collectedCoins.ToString();
    }
    public void Pause()
    {
        if (!_pause)
        {
           Time.timeScale = 0; 
           _pause = true;
        }
        else
        {
            Time.timeScale = 1;
            _pause = false;
        }
        
        pauseCanvas.SetActive(_pause);
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        //LoadSceneAsync
    }
    public IEnumerator DelayScene()
    {
        
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Game Over");
        
    }
    public IEnumerator DelayVictory()
    {
        
        yield return new WaitForSeconds(1.5f);
        victoryCanvas.SetActive(true);
        
    }
}
