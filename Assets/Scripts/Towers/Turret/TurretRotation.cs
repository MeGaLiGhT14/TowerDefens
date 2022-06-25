using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    //[SerializeField] private float _speedRotation;

    private DetectorEnemys _detectorEnemys;

    private bool _turretIsAimed = false;
    public bool TurretIsAimed => _turretIsAimed;

    private GameObject _axis;

    private void OnValidate()
    {
        //if (_speedRotation < 0)
        //    _speedRotation = 0;
    }

    private void Start()
    {
        _detectorEnemys = GetComponent<DetectorEnemys>();
        _axis = transform.parent.gameObject;
    }

    private void FixedUpdate()
    {
        if (_detectorEnemys.Enemys.Count != 0)
        {

            GameObject target = _detectorEnemys.Enemys[0];
            float angle = Vector2.SignedAngle(Vector2.up, target.transform.position - transform.position);
            DirectionRotate(angle, _axis);

            _turretIsAimed = true;
        }
        else
        {
            _turretIsAimed = false;
        }
    }

    private void DirectionRotate(float angle , GameObject gameObject)
    {
        gameObject.transform.rotation = new Quaternion(0 , 0 , 0 , 1);
        gameObject.transform.Rotate(new Vector3(0 , 0 , angle) , Space.World);


        //float speed = 1;
        //Vector3 vec = new Vector3(0, 0, angle);
        //Vector3.MoveTowards(transform.rotation, vec, speed);

        //gameObject.transform.Rotate(new Vector3(0, 0, angle), Space.World);
    }
}