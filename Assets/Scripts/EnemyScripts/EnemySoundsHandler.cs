using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemySoundsHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _explosionSound;

    private AudioSource _audioSource;
    private EnemyShooter _shooter;
    private Enemy _enemy;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _shooter = GetComponent<EnemyShooter>();
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.IsDead += PlayExplosionSound;
        _shooter.IsShoot += PlayShootSound;
    }

    private void OnDisable()
    {
        _enemy.IsDead += PlayExplosionSound;
        _shooter.IsShoot += PlayShootSound;
    }

    private void PlayShootSound()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
    }

    private void PlayExplosionSound()
    {
        _audioSource.PlayOneShot(_explosionSound);
    }
}
