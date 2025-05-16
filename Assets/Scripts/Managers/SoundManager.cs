using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioClip buttonPressed;
    private Vector3 button_pos;

    void Awake()
    {
        Instance = this;
        button_pos = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, button_pos);
    }

    public void PlayButtonClip()
    {
        PlaySound(buttonPressed);
    }
}