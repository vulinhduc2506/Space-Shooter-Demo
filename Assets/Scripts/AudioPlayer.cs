using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float ShootingVolume = 1f;

    [Header("DamgeTaken")]
    [SerializeField] AudioClip damageTakenClip;
    [SerializeField] [Range(0f, 1f)] float damageTakenVolume = 1f;

    static AudioPlayer instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, ShootingVolume);
    }

    public void PlayDamageTakenClip()
    {
        PlayClip(damageTakenClip, damageTakenVolume);
    }

    public void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            AudioSource.PlayClipAtPoint(clip,
                                        Camera.main.transform.position,
                                        volume);
        }
    }
}
