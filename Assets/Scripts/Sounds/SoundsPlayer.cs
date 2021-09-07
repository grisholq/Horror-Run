using UnityEngine;

public class SoundsPlayer : Singleton<SoundsPlayer>
{
    [SerializeField] private AudioSource _ambient;
    [SerializeField] private AudioSource _steps;
    [SerializeField] private AudioSource _monsterTouch;
    [SerializeField] private AudioSource _monsterComing;
    [SerializeField] private AudioSource _playerDeath;
    [SerializeField] private BossDeathSounds _bossDeath;

    [SerializeField] private bool _musicOn;
    [SerializeField] private bool _soundsOn;

    public bool MusicOn 
    { 
        get => _musicOn;
        set
        {
            _musicOn = value;

            if(_musicOn == false)
            {
                DisableAmbient();
            }
            else
            {
                EnableAmbient();
            }
        }
    }
    public bool SoundsOn { get => _soundsOn; set => _soundsOn = value; }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void EnableSteps()
    {
        if (_soundsOn == false) return;
        _steps.Play();
    }

    public void DisableSteps()
    {
        _steps.Stop();
    }

    public void EnableAmbient()
    {
        if (_musicOn == false) return;
        _ambient.Play();
    }
    
    public void DisableAmbient()
    {
        _ambient.Stop();
    }

    public void PlayMonsterTouch()
    {
        if (_soundsOn == false) return;
        _monsterTouch.Play();
    }
    
    public void PlayMonsterComing()
    {
        if (_soundsOn == false) return;
        if (_monsterComing.isPlaying == false)
        {
            _monsterComing.Play();
        }
    }

    public void PlayPlayerDeath()
    {
        if (_soundsOn == false) return;
        _playerDeath.Play();
    }
    
    public void PlayBossDeath()
    {
        if (_soundsOn == false) return;
        _bossDeath.PlayRandomSound();
    }
}