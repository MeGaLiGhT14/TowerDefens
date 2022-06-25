using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooting : MonoBehaviour
{

    [SerializeField] private int _damage;

    #region MonoBehaviour

    private void OnValidate()
    {
        if (_damage < 0)
            _damage = 0;
    }

    #endregion

    public virtual void Shoot(GameObject target)
    {
        target.GetComponent<EnemyHealth>().ReceivingDamage(_damage);
    }

}
