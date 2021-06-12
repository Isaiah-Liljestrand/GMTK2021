using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    public List<AudioClip> clips;
    public bool playonawake;
    public float pitchoffset;
    private AudioSource asource;

    // Start is called before the first frame update
    void Start()
    {
        asource = GetComponent<AudioSource>();
        if (playonawake)
            PlaySound();
    }

    public void PlaySound()
    {
        asource.clip = clips[Random.Range(0, clips.Count)];
        asource.Play();
        asource.pitch = Random.Range(1 - pitchoffset, 1 + pitchoffset);
    }

    public void PlaySound(AudioClip addedclip)
    {
        asource.clip = addedclip;
        asource.Play();
        asource.pitch = Random.Range(1 - pitchoffset, 1 + pitchoffset);
    }
}
