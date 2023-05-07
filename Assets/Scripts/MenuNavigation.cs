using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuNavigation : MonoBehaviour
{
    [SerializeField] TMP_Text playerName;

    public void LoadInstructions(){
        SceneManager.LoadScene("Instructions");
    }

    public void LoadSettings(){
        SceneManager.LoadScene("Settings");
    }

    public void LoadMenu(){
        SceneManager.LoadScene("Menu");
    }

    public void LoadHighScores(){
        SceneManager.LoadScene("Win");
    }

    public void Play(){
        PersistentData.Instance.SetScore(0);
        PersistentData.Instance.SetName(playerName.text);
        SceneManager.LoadScene("Level1");
    }
}
