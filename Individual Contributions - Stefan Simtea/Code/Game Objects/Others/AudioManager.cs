using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Script used to play sound effects when needed

    static AudioSource audioSource;
    public static AudioClip fireSound;
    public static AudioClip explosionSound;
    public static AudioClip dashSound;
    public static AudioClip jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        // We load the resources needed (audio clips) at the start and we get the audio source which will be emitting said resources
        fireSound = Resources.Load<AudioClip>("Fireball");
        explosionSound = Resources.Load<AudioClip>("Explosion");
        dashSound = Resources.Load<AudioClip>("Dash");
        jumpSound = Resources.Load<AudioClip>("Jump");
        audioSource = GetComponent<AudioSource>();
    }


    public static void playFireSound() // plays fire sound
    {
        audioSource.PlayOneShot(fireSound);

    }

    public static void playExplosion() // plays explosion sound
    {
        audioSource.PlayOneShot(explosionSound);

    }

    public static void playJump() // plays jump sound
    {
        audioSource.PlayOneShot(jumpSound);

    }

    public static void playDash() // plays dash sound
    {
        audioSource.PlayOneShot(dashSound);

    }

}
