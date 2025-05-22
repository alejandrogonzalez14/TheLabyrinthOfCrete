using UnityEngine;

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
}