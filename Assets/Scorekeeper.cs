using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] static int score = 0;
    const int DEFAULT_POINTS = 1;
    const int SCORE_THRESHOLD = 1;
    [SerializeField] TMP_Text scoreTXT;
    [SerializeField] TMP_Text Scene;
    [SerializeField] int level;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        DisplayLevel();
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("score " + score);
        DisplayScore();

        if(score >SCORE_THRESHOLD){
            Invoke("AdvanceLevel", (float)0.3);
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
        Scene.text = "Level: " + (level+1);
    }

    public void AdvanceLevel()
    {
        SceneManager.LoadScene(level + 1);
    }
}
