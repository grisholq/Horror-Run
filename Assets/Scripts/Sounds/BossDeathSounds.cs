using UnityEngine;

public class BossDeathSounds : MonoBehaviour
{
    private AudioSource[] _sounds;

    private void Awake()
    {
        _sounds = GetComponentsInChildren<AudioSource>();
    }

    public void PlayRandomSound()
    {
        _sounds[Random.Range(0, _sounds.Length)].Play();
    }
}