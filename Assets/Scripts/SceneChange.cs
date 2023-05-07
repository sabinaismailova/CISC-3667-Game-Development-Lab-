using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public int scene;
    
    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        Invoke("LoadLevelAfterDelay", 1);
    }
 
    void LoadLevelAfterDelay()
    {
        scene = scene +1;
        SceneManager.LoadScene(scene);
    }
}
