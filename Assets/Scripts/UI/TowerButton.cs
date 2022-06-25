using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerButton : MonoBehaviour
{
    [SerializeField] private TowersBalance.IndexTower _index;

    [SerializeField] private SelectTower _selectTower;

    public void OnButtonClick()
    {
        _selectTower.SwithTower((int)_index);
    }
}
