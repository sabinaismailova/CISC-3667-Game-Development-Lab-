using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] int playerScore;
    [SerializeField] float volume;
    AudioSource audio;

    public static PersistentData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        playerScore = 0;
        volume = 1;
    }

    public void SetScore(int s)
    {
        playerScore = s;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void SetVolume(float n)
    {
        volume = n;
        audio.volume = volume;
    }

    public float GetVolume()
    {
        return volume;
    }

    public AudioSource GetAudio(){
        return audio;
    }
}
