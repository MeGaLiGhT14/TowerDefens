using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Base : MonoBehaviour
{
    [SerializeField] private int _health;

    [SerializeField] private TMP_Text _text;

    [SerializeField] private GameOverPanel _gameOverPanel;

    #region MonoBehaviour

    private void OnValidate()
    {
        if (_health < 0)
            _health = 0;
    }

    private void Start()
    {
        _text.text = _health.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyDamage enemyDamage;
        if (enemyDamage = collision.GetComponent<EnemyDamage>())
        {
            ReceivingDamage(enemyDamage.Damage);
            Destroy(collision.gameObject);
        }
    }

    #endregion

    private void ReceivingDamage(int damage)
    {
        _health -= damage;
        _text.text = _health.ToString();

        if (_health <= 0)
            _gameOverPanel.GameOver();            
    }
}