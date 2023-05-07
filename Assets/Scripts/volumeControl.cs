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

}
