
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("---Audio Source---")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioMixer audioMixer;

    [Header("---Audio Clip---")]
    public AudioClip background;
    public AudioClip[] walk;
    public AudioClip death;

    [Header("---Footsteps---")]
    [SerializeField] private float stepDelay = 0.5f;

    private Coroutine footstepCoroutine;
    private bool isWalking;

    // ================= MUSIC =================

    public void StartMusic()
    {
        if (background == null || audioSource == null) return;

        audioSource.clip = background;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PauseMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
            audioSource.Pause();
    }

    public void ResumeMusic()
    {
        if (audioSource != null)
            audioSource.UnPause();
    }

    public void StopMusic()
    {
        if (audioSource != null)
            audioSource.Stop();
    }

    // ================= VOLUME =================

    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f);
    }

    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f);
    }

    // ================= SFX =================

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null || SFXSource == null) return;

        SFXSource.pitch = 1f;
        SFXSource.PlayOneShot(clip);
    }
    public void SetWalking(bool walking)
    {
        if (isWalking == walking) return;

        isWalking = walking;

        if (isWalking)
        {
            footstepCoroutine = StartCoroutine(FootstepLoop());
        }
        else
        {
            StopFootsteps();
        }
    }

    private IEnumerator FootstepLoop()
    {
        while (isWalking)
        {
            PlayRandomFootstep();
            yield return new WaitForSeconds(stepDelay);
        }
    }
    private void StopFootsteps()
    {
        if (footstepCoroutine != null)
        {
            StopCoroutine(footstepCoroutine);
            footstepCoroutine = null;
        }
    }
    private void PlayRandomFootstep()
    {
        int index = Random.Range(0, walk.Length);
        float originalPitch = SFXSource.pitch;
        float originalVolume = SFXSource.volume;

        SFXSource.pitch = Random.Range(0.9f, 1.1f);
        SFXSource.volume = Random.Range(0.8f, 1f);
        SFXSource.PlayOneShot(walk[index]);

        SFXSource.pitch = originalPitch;
        SFXSource.volume = originalVolume;
    }

}
