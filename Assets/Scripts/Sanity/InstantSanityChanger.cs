using UnityEngine;
using UnityEngine.Events;

public class InstantSanityChanger : SanityChanger
{
    [SerializeField] private float _sanityChange;
    [SerializeField] private bool _destoryOnEnter;
    [SerializeField] private ParticleSystem _destroyParticles;

    private void OnTriggerEnter(Collider other)
    {
        CharacterSanity sanity;
        if(other.TryGetComponent<CharacterSanity>(out sanity))
        {
            ChangeSanity(sanity, _sanityChange);
            if (_destoryOnEnter)
            {
                SpawnDeathParticles();
                Destroy(gameObject);           
            }          
        }
    }

    private void SpawnDeathParticles()
    {
        ParticleSystem particles = Instantiate(_destroyParticles);
        particles.transform.position = transform.position;
        particles.Play();
        Destroy(particles.gameObject, 1f);
    }
}