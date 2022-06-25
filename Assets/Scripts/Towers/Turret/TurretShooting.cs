using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    [SerializeField] private float _rechargeTime;
    private float _remainingRechargeTime;

    [SerializeField] private GameObject[] _cannons;

    private TurretRotation _turretRotation;
    private DetectorEnemys _detectorEnemys;

    private bool _readyShoot => _remainingRechargeTime <= 0;
    private int _cannonFiringOrder = 0;

    private void OnValidate()
    {
        if (_rechargeTime < 0)
            _rechargeTime = 0;
    }

    private void Start()
    {
        _turretRotation = GetComponent<TurretRotation>();
        _detectorEnemys = GetComponent<DetectorEnemys>();

        _remainingRechargeTime = _rechargeTime;
    }

    private void Update()
    {
        if (_readyShoot == false)
            _remainingRechargeTime -= Time.deltaTime;

        if (_turretRotation.TurretIsAimed)
            ShootCannon();
    }

    private void ShootCannon()
    {
        if (_readyShoot && _detectorEnemys.Enemys.Count > 0)
        {
            _cannons[_cannonFiringOrder].transform.GetChild(0).GetComponent<Cannon>().StartShooting(_detectorEnemys.Enemys[0]);
            _remainingRechargeTime = _rechargeTime;

            if (++_cannonFiringOrder == _cannons.Length)
                _cannonFiringOrder = 0;
        }
    }
}