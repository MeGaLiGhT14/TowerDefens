using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class DetectorEnemys : MonoBehaviour
{
    [SerializeField] private float _rangeDetection;

    private List<GameObject> _enemys = new List<GameObject>();
    public List<GameObject> Enemys => _enemys;

    private void OnValidate()
    {
        if (_rangeDetection < 0)
            _rangeDetection = 0;
    }

    private void Start()
    {
        CircleCollider2D zoneShotting = GetComponent<CircleCollider2D>();
        zoneShotting.radius = _rangeDetection;
    }

    private void Update()
    {
        if (_enemys.Count != 0 && _enemys[0] == null)
            _enemys.RemoveAt(0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<MovementEnemy>())
            _enemys.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _enemys.Remove(collision.gameObject);
    }
}