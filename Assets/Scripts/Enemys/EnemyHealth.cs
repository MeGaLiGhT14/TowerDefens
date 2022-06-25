using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _baseMaxHealth;
    public int BaseMaxHealth => _baseMaxHealth;

    private int _maxHealth;
    private int _health;

    private void OnValidate()
    {
        if (_baseMaxHealth < 1)
            _baseMaxHealth = 1;
    }

    private void Start()
    {
        if (_maxHealth == 0)
        {
            _maxHealth = _baseMaxHealth;
            _health = _maxHealth;
        }
    }

    public void ReceivingDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
            DieEnemy();
    }

    public void MultiplyHealth(float multiplierHealth)
    {
        _maxHealth = (int)(_baseMaxHealth * multiplierHealth);
        _health = _maxHealth;
    }

    private void DieEnemy()
    {
        GetComponent<EnemyPrice>().Reward();

        Destroy(gameObject);
    }
}