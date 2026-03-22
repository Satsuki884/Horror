
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---Audio Source---")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("---Audio Clip---")]
    public AudioClip background;
    public AudioClip[] walk;
    public AudioClip death;

    [Header("---Footsteps---")]
    [SerializeField] private float stepDelay = 0.5f;

    private Coroutine footstepCoroutine;
    private bool isWalking;

    private void Start()
    {
        audioSource.clip = background;
        audioSource.loop = true;
        audioSource.Play();

    }
    public void PlaySFX(AudioClip clip)
    {
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
        SFXSource.pitch = Random.Range(0.9f, 1.1f);
        SFXSource.PlayOneShot(walk[index]);
    }

}
