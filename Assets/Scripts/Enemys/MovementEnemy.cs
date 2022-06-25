using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3[] _wayPoints;
    private int _numberWayPoint;

    private void OnValidate()
    {
        if (_speed < 0)
            _speed = 0;
    }

    private void Start()
    {
        _numberWayPoint = 0;
    }

    private void FixedUpdate()
    {
        if (_wayPoints != null)
        {
            transform.position = Vector3.MoveTowards(transform.position , _wayPoints[_numberWayPoint] , _speed * Time.deltaTime);

            if (transform.position == _wayPoints[_numberWayPoint])
                SwitchWayPoint();
        }
    }

    public void GetWay(Vector3[] wayPoints)
    {
        _wayPoints = wayPoints;
    }

    private void SwitchWayPoint()
    {
        if (++_numberWayPoint == _wayPoints.Length)
        {
            _wayPoints = null;
        }
        else
        {
            float angle = Vector2.SignedAngle(Vector2.up, _wayPoints[_numberWayPoint] - transform.position);
            DirectionRotate(angle);
        }
    }

    private void DirectionRotate(float angle)
    {
        transform.rotation = new Quaternion(0 , 0 , 0 , 1);
        transform.Rotate(new Vector3(0 , 0 , angle) , Space.World);
    }
}