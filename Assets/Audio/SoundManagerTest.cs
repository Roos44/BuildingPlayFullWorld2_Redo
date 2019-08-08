using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;


namespace UnityStandardAssets._2D
{





    public class SoundManager : MonoBehaviour
    {
        public AudioSource efxSource;
        public AudioSource musicSource;
        public static SoundManager Instance = null;

        public float LowPitchRange = .95f;
        public float HighPitchRange = 1.05f;

        void Awake()
        {

            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);

        }

        public void PlaySingle(AudioClip clip)
        {
            efxSource.clip = clip;
            efxSource.Play();

        }


        public void RandomizeSfx(params AudioClip[] clips)
        {
            int randomIdex = Random.Range(0, clips.Length);
            float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

            efxSource.pitch = randomPitch;
            efxSource.clip = clips[randomIdex];
            efxSource.Play();

        }



    }
}