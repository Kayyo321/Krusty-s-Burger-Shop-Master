using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region AudioClips
    [SerializeField] AudioClip PhoneCall;
    [SerializeField] AudioClip Death;
    #endregion

    public AudioSource AudioPlayer;

    public void PlayPhoneCall()
    {
        print("Playing Phone Call");
        AudioPlayer.PlayOneShot(PhoneCall);
    }

    public void PlayDeath()
    {
        print("Sorry For Your Ears");
        AudioPlayer.PlayOneShot(Death);
    }
}
