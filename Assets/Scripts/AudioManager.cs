using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup soundEffectMixer;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de AudioManager dans la scène");
            return;
        }

        instance = this;
    }

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject temp = new GameObject("TempAudio");
        temp.transform.position = pos;
        AudioSource audioSource = temp.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        audioSource.Play();
        Destroy(temp, clip.length);
        return audioSource;
    }
}
