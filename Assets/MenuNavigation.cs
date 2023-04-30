using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    public void LoadInstructions(){
        SceneManager.LoadScene("Instructions");
    }

    public void LoadSettings(){
        SceneManager.LoadScene("Settings");
    }

    public void LoadMenu(){
        SceneManager.LoadScene("Menu");
    }

    public void Play(){
        SceneManager.LoadScene("Level 1");
    }
}
