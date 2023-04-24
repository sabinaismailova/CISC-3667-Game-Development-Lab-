using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    [SerializeField] GameObject InstructionsPanel;
    [SerializeField] GameObject SettingsPanel;
    [SerializeField] GameObject MenuButtons;
    // Start is called before the first frame update
    void Start()
    {
        InstructionsPanel.SetActive(false);
        SettingsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadInstructions(){
        InstructionsPanel.SetActive(true);
        MenuButtons.SetActive(false);
    }

    public void LoadSettings(){
        SettingsPanel.SetActive(true);
        MenuButtons.SetActive(false);
    }

    public void GoBackToMenu(){
        MenuButtons.SetActive(true);
        if(InstructionsPanel.active==true){
            InstructionsPanel.SetActive(false);
        }
        else if(SettingsPanel.active==true){
            SettingsPanel.SetActive(false);
        }
    }

    public void Play(){
        SceneManager.LoadScene("Level 1");
    }
}
