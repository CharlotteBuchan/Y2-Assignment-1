using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] AudioSource ButtonEffects;
    [SerializeField] Slider volumeSlider;
    void Start()
    {
        ButtonEffects = GameObject.Find("Button Effects").GetComponent<AudioSource>();
        volumeSlider.value = ButtonEffects.volume;
    }

    public void ChangeVolume()
    {
        ButtonEffects.volume = volumeSlider.value;
    }
}
