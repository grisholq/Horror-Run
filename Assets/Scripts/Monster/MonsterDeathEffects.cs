using UnityEngine;

public class MonsterDeathEffects : MonoBehaviour
{
    [SerializeField] private int _particlesCount;
    [SerializeField] private ParticleSystem _particles;

    public void Play()
    {
        ParticleSystem particles = Instantiate(_particles);
        particles.transform.position = transform.position;
        particles.transform.position += new Vector3(0, 2f, 0);
        particles.Play();
    }
}