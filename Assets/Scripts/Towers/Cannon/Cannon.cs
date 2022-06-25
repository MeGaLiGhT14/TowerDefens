using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Cannon : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;

    private CannonShooting _cannonShooting;

    #region MonoBehaviour

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _cannonShooting = GetComponent<CannonShooting>();
    }

    #endregion

    public void StartShooting(GameObject target)
    {
            _animator.SetTrigger("Shoot");

            _audioSource.pitch = Random.Range(0.8f , 1.2f);
            _audioSource.Play();

            _cannonShooting.Shoot(target);
        }
}