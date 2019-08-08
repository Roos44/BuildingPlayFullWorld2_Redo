using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets I
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }


    }
    /*
    public AudioClip Sound;
    public AudioClip MoveSound1;
    public AudioClip MoveSound2;
    public AudioClip EffectSwoosh;
    public AudioClip EffectChime;
    public AudioClip gameOverSound;
    */
    public SoundAudioClip[] soundAudioClipArray;


    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }


}