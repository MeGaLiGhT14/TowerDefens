using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleTowerButton : MonoBehaviour
{
    [SerializeField] private SelectTower _selectTower;

    public void OnButtonClick()
    {
        _selectTower.ChooseSale();
    }

}
