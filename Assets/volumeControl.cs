using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeControl : MonoBehaviour
{
    [SerializeField] GameObject volumeSlider;

    void Start()
    {
        volumeSlider = GameObject.Find("VolumeSlider");
    }

    void Update(){
        PersistentData.Instance.SetVolume(volumeSlider.GetComponent<Slider>().value);
    }

/*
    
    private void ContinueVolume()
    {
        volumeFloat = PlayerPrefs.GetFloat(VolumePref);

        volumeSlider.value = volumeFloat;

        audio.volume = volumeSlider.value;
    }
    

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(VolumePref, volumeSlider.value);
    }

    void OnApplicationFocus(bool inFocus){
        if(!inFocus){
            SaveSoundSettings();
        }
    }

    public void UpdateSound(){
        audio.volume = volumeSlider.value;
    }
    */

}
