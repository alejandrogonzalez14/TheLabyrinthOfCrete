using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField]
    private SoundLibrary sfxLibrary;

    [SerializeField]
    private AudioSource sfxSource;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Vector3.zero);
        }
    }

    public void PlaySound(string soundName)
    {
        sfxSource.PlayOneShot(sfxLibrary.GetClipFromName(soundName));
    }

    public void PlaySoundWithDelay(string soundName, float delay)
    {
        StartCoroutine(PlaySoundDelayedCoroutine(soundName, delay));
    }

    private IEnumerator PlaySoundDelayedCoroutine(string soundName, float delay)
    {
        yield return new WaitForSeconds(delay);
        sfxSource.PlayOneShot(sfxLibrary.GetClipFromName(soundName));
    }


    public bool isPlaying()
    {
        return sfxSource.isPlaying;
    }
}