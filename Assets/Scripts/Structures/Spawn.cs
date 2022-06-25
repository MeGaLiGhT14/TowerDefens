using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemys = new List<GameObject>();
    public List<GameObject> Enemys => _enemys;

    [SerializeField] private Way _way;
    [SerializeField] private Money _money;

    #region MonoBehaviour

    private void OnValidate()
    {
        for (int i = 0; i < _enemys.Count; i++)
        {
            if (_enemys[i].tag != "Enemy")
                _enemys.RemoveAt(i);
        }
    }

    #endregion

    public void CreateEnemy(float multiplyHealth)
    {
        GameObject enemy = _enemys[Random.Range(0 , _enemys.Count)];

        enemy = Instantiate(enemy , transform.position , Quaternion.identity);

        enemy.GetComponent<MovementEnemy>().GetWay(_way.WayPoints);
        enemy.GetComponent<EnemyPrice>().GetMoney(_money);
        enemy.GetComponent<EnemyHealth>().MultiplyHealth(multiplyHealth);
    }
}