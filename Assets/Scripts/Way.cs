using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Way : MonoBehaviour
{
    private Vector3[] _wayPoints;
    public Vector3[] WayPoints => _wayPoints;

    #region MonoBehaviour

    private void Start()
    {
        _wayPoints = new Vector3[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            _wayPoints[i] = transform.GetChild(i).transform.position;
    }

    #endregion
}