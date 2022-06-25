using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected int _damage;
    public int Damage => _damage;

    private void OnValidate()
    {
        if (_damage < 0)
            _damage = 0;
    }
}