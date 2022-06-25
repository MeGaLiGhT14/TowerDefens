using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowersBalance : MonoBehaviour
{
    public enum IndexTower
    {
        LightTower = 0,
        MediumTower = 1,
        HeavyTower = 2
    }

    [SerializeField] private List<GameObject> _towers;
    public List<GameObject> Towers => _towers;

    private static int _basePrice = 100;

    [SerializeField] private float _coefficientPriceIncrease;

    private int[] _towersPrice = new int[3] { _basePrice , _basePrice , _basePrice };
    public int[] TowersPrice => _towersPrice;

    [SerializeField] private SelectTower _selectTower;

    [SerializeField] private TMP_Text[] _textTowersPrice;

    #region MonoBehaviour 

    private void OnValidate()
    {
        for (int i = 0; i < _towers.Count; i++)
        {
            if (!_towers[i].CompareTag("Tower"))
                _towers.RemoveAt(i);
        }

        if (_coefficientPriceIncrease < 0)
            _coefficientPriceIncrease = 0;
    }

    private void Start()
    {
        for (int i = 0; i < _textTowersPrice.Length; i++)
            _textTowersPrice[i].text = _towersPrice[i].ToString();
    }

    #endregion

    public void IncreasePrice(int index)
    {
        _towersPrice[index] += (int)(_basePrice * _coefficientPriceIncrease);

        _textTowersPrice[index].text = _towersPrice[index].ToString();
    }

    public void ReductionPrice(int index)
    {
        _towersPrice[index] -= (int)(_basePrice * _coefficientPriceIncrease);

        _textTowersPrice[index].text = _towersPrice[index].ToString();
    }
}
