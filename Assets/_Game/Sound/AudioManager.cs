using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : Singleton<AudioManager>
{
    // Start is called before the first frame update
    [SerializeField] AudioSource Musix;
    [SerializeField] AudioSource SFX;
    

    [Header("-----------------------------------------------")]
    public AudioClip background;
    public AudioClip backgroundboss;
    public AudioClip death;
    
    public AudioClip touch;
    public AudioClip dash;
    public AudioClip attack_sword;
    public AudioClip attack_magic;
    public AudioClip arrow;
    public AudioClip take_coin;
    public AudioClip eatBrain;
    
    private void Start()
    {
        Musix.clip = background;
        Musix.Play();
    }
    
    public void ChangeMusic(AudioClip clip)
    {
        Musix.Stop();
        Musix.clip = clip;
        Musix.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}

