using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ConstructionSite : MonoBehaviour
{
    [SerializeField] private float _demolitionRefund = 0.5f;

    private TowersBalance _towersBalance;
    private Money _money;

    private TowersBalance.IndexTower _indexTower;
    private GameObject _tower = null;

    private bool _free = true;
    public bool Free => _free;

    private Animator _animator;

    #region MonoBehaviour

    private void OnValidate()
    {
        if (_demolitionRefund < 0)
            _demolitionRefund = 0;
        else if (_demolitionRefund > 1)
            _demolitionRefund = 1;
    }

    private void Start()
    {
        _animator = transform.GetChild(0).GetComponent<Animator>();

        GameObject balanceManager = GameObject.Find("BalanceManager");
        _towersBalance = balanceManager.GetComponent<TowersBalance>();
        _money = balanceManager.GetComponent<Money>();
    }

    #endregion

    public void BuildTower(int index)
    {
        if (_free)            
            ConstructionTower(index);
    }

    public void DreackTower()
    {
        if (!_free)
        {
            _towersBalance.ReductionPrice((int)_indexTower);

            int moneyFronSale = (int)((_towersBalance.TowersPrice[(int)_indexTower]) * _demolitionRefund);
            _money.AddMoney(moneyFronSale);

            DestroyTower();
        }
    }

    private void ConstructionTower(int index)
    {
        int towerPrice = _towersBalance.TowersPrice[index];

        if (_money.SpendMoney(towerPrice))
            {
            _free = false;
            _animator.SetBool("Free" , _free);

            GameObject tower = _towersBalance.Towers[index];
            _tower = Instantiate(tower , transform.position , Quaternion.identity);

            _indexTower = (TowersBalance.IndexTower)index;
            _towersBalance.IncreasePrice((int)_indexTower);
        }
    }

    private void DestroyTower()
    {
        _free = true;
        _animator.SetBool("Free" , _free);

        Destroy(_tower.gameObject);
    }
}