using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTower : MonoBehaviour
{
    private TowersBalance.IndexTower _index;
    public TowersBalance.IndexTower Index => _index;

    private bool _towerSelected = false;
    public bool TowerSelected => _towerSelected;

    private bool _selectedSale = false;
    public bool SelectedSele => _selectedSale;

    [SerializeField] TowersBalance _towersBalance;

    [SerializeField] BuildModeImage _buildModeImage;

    public void SwithTower(int index)
    {
        _selectedSale = false;

        if (!_towerSelected)
        {
            ChooseTower(index);
        }
        else
        {
            if (index != (int)_index)
                ChooseTower(index);
            else
            {
                _towerSelected = false;
                _buildModeImage.ChangeMode(BuildModeImage.BuildMode.none);
            }
        }
    }

    public void ChooseTower(int index)
    {
        _towerSelected = true;
        _index = (TowersBalance.IndexTower)index;

        _buildModeImage.ChangeMode((BuildModeImage.BuildMode)(_index + 1));
    }

    public void ChooseSale()
    {
        _towerSelected = false;

        _selectedSale = !SelectedSele;

        _buildModeImage.ChangeMode(BuildModeImage.BuildMode.demolition);
    }
}