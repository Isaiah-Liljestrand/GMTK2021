using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public List<AudioClip> music;
    public List<float> musicvolumes;

    private int lastsong;
    private AudioSource source;
    private float defaultvolume;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        defaultvolume = source.volume;
        lastsong = -1;
    }

    public void PlaySong(int song)
    {
        source.clip = music[song];
        source.Play();
        source.volume = defaultvolume;
        if (musicvolumes.Count > song)
        {
            if (musicvolumes[song] != 0)
                source.volume = musicvolumes[song];
        }
        lastsong = song;
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            if (music.Count > 0)
            {
                int chosen = lastsong;
                while (chosen == lastsong)
                    chosen = Random.Range(0, music.Count);
                PlaySong(chosen);
            }
        }
    }
}
