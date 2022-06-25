using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrice : MonoBehaviour
{
    [SerializeField] private int _price;

    private Money _money;

    private void OnValidate()
    {
        if (_price < 0)
            _price = 0;
    }

    public void GetMoney(Money money)
    {
        _money = money;
    }

    public void Reward()
    {
        _money.AddMoney(_price);
    }
}