using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public AudioSource asSounds;
    public AudioClip scoreSound;
    public AudioClip winSound;
    public AudioClip wallSound;
    public AudioClip paddleSound;

    public void PlayWallSound()
    {
        asSounds.PlayOneShot(wallSound);
    }

    public void PlayPaddleSound()
    {
        asSounds.PlayOneShot(paddleSound);
    }

    public void PlayScoreSound()
    {
        asSounds.PlayOneShot(scoreSound);
    }

    public void PlayWinSound()
    {
        asSounds.PlayOneShot(winSound);
    }
}