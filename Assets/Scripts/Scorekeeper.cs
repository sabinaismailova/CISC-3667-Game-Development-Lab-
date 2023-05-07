using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] public int score;
    const int DEFAULT_POINTS = 1;
    const int SCORE_THRESHOLD = 1;
    [SerializeField] TMP_Text scoreTXT;
    [SerializeField] TMP_Text Scene;
    [SerializeField] int level;
    public int start;

    // Start is called before the first frame update
    void Start()
    {
        start = SceneManager.GetActiveScene().buildIndex;
        level = start -(start/2);
        score = PersistentData.Instance.GetScore();
        DisplayLevel();
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int points)
    {
        score = PersistentData.Instance.GetScore();
        score += points;
        PersistentData.Instance.SetScore(score);
        Debug.Log("score " + score);
        DisplayScore();

        if(score >SCORE_THRESHOLD){
            Invoke("AdvanceLevel", (float)0.9);
        }
    }

    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
    }

    public void DisplayScore()
    {
        scoreTXT.text = "Score: " + score;
    }

    public void DisplayLevel()
    {
        Scene.text = "Level: " + (level);
    }

    public void AdvanceLevel()
    {
        SceneManager.LoadScene(start+1);
    }
}
