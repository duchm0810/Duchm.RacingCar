using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {


    public static SoundManager sm;
    public AudioClip Click, Crash;
    AudioSource audio;
    private void Awake()
    {
        if(sm == null)
        {
            sm = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        audio = GetComponent<AudioSource>();
    }
    public void ClickSound()
    {
        audio.PlayOneShot(Click);
    }
    public void CrashSound()
    {
        audio.PlayOneShot(Crash);
    }

}
