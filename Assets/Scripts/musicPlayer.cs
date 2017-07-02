using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour {

    public AudioClip intro = null;
    public AudioClip loop = null;

    private AudioSource audioPlayer;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.loop = true;

        StartCoroutine(playBGMusic());
    }

    IEnumerator playBGMusic()
    {
        audioPlayer.clip = intro;
        audioPlayer.Play();

        yield return new WaitForSeconds(audioPlayer.clip.length);

        audioPlayer.clip = loop;
        audioPlayer.Play();

    }
}
