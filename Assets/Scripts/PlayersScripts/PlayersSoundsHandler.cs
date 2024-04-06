using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Shooter))]
public class PlayersSoundsHandler : MonoBehaviour
{
    private AudioSource _audioSource;
    private Shooter _shooter;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _shooter = GetComponent<Shooter>();
    }

    private void OnEnable()
    {
        _shooter.IsShoot += PlayShootSound;
    }

    private void OnDisable()
    {
        _shooter.IsShoot -= PlayShootSound;
    }

    private void PlayShootSound()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
    }
}
