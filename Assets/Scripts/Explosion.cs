using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Explosion : MonoBehaviour
{
    [SerializeField] private int _damage;

    [SerializeField] private float _dispersionTime;

    #region MonoBehaviour

    private void OnValidate()
    {
        if (_damage < 0)
            _damage = 0;

        if (_dispersionTime < 0)
            _dispersionTime = 0;
    }

    private void Start()
    {
        StartCoroutine(ExplosionDispersion());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EnemyHealth>().ReceivingDamage(_damage);
    }

    #endregion

    IEnumerator ExplosionDispersion()
    {
        yield return new WaitForSeconds(_dispersionTime);

        GetComponent<Rigidbody2D>().simulated = false;

        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }
}