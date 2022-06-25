using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtilleryCannonShooting : CannonShooting
{
    [SerializeField] private float _flyingTime;

    [SerializeField] private GameObject _explosion;

    #region MonoBehaviour

    private void OnValidate()
    {
        if (_flyingTime < 0)
            _flyingTime = 0;

        if (!_explosion.GetComponent<Explosion>())
            _explosion = null;
    }

    #endregion

    public override void Shoot(GameObject target)
    {
        Vector3 positionExplosion = target.transform.position;

        StartCoroutine(BulletFlying(positionExplosion));
    }

    IEnumerator BulletFlying(Vector3 positionExplosion)
    {
        yield return new WaitForSeconds(_flyingTime);

        Instantiate(_explosion , positionExplosion , Quaternion.identity);
    }
}