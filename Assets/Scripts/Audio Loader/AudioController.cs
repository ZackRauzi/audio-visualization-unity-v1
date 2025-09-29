using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;

    public void ToggleAudio()
    {
        if (audioSource == null)
        {
            Debug.LogWarning("audio source not found");
            return;
        }

        if (audioSource.isPlaying) { audioSource.Pause(); }
        else { audioSource.Play(); }
    }
}