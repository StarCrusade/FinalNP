using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    public AudioSource menuAudioSource;
    public Slider VolumeSlider;
    public float volume;    

    void Start()
    {
        menuAudioSource = this.GetComponent<AudioSource>();           
    }

    // Update is called once per frame
    void Update()
    {
        menuAudioSource.volume = VolumeSlider.value;        
    }
}
