using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource audioSource;
    
    public AudioClip gameMusic;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartBGM();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartBGM()
    {
        audioSource.loop = true;
        audioSource.clip =gameMusic;
        audioSource.Play();

       // _audioSource.Pause(); (si luego vuelves a poner play se reanuda por donde se a pausado)
       //_audioSource.Stop(); (La cancion se reinicia)
    }
}
