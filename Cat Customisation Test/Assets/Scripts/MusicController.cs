using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioSource BackgroundMusic;
    [SerializeField] Slider volumeSlider;
    void Start()
    {
        BackgroundMusic = GameObject.Find("Background Music").GetComponent<AudioSource>();
        volumeSlider.value = BackgroundMusic.volume;
    }

    public void ChangeVolume()
    {
        BackgroundMusic.volume = volumeSlider.value;
    }
}
