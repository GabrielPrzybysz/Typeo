using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    private static AudioSource efxSource;

    private void Awake()
    {
        efxSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }


    public static void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;

        efxSource.Play();
    }

}
