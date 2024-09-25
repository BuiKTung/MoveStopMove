using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSetting : MonoBehaviour
{
    [SerializeField]private AudioMixer audioMixer;
    [SerializeField] private Slider slider;

    // Start is called before the first frame update
    public void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }
    }
    public void SetMusicVolume()
    {
        float volume = slider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume)*20);
    }
    public void LoadVolume()
    {
        slider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVolume();
    }
}
