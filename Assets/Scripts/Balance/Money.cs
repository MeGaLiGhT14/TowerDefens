using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    [SerializeField] private int _money = 300;

    #region MonoBehaviour 

    private void OnValidate()
    {
        if (_money < 100)
            _money = 100;
    }

    private void Start()
    {
        _text.text = _money.ToString();
    }

    #endregion

    public void AddMoney(int amount)
    {
        _money += amount;
        _text.text = _money.ToString();
    }

    public bool SpendMoney(int amount)
    {
        if (amount <= _money)
        {
            _money -= amount;
            _text.text = _money.ToString();
            return true;
        }
        else
            return false;
    }
}