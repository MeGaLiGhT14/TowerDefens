using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildModeImage : MonoBehaviour
{
    public enum BuildMode
    {
        none = 0,
        lightTower = 1,
        mediumTower = 2,
        heavyTower = 3,
        demolition = 4
    }

    [SerializeField] private Sprite[] _sprites;

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void ChangeMode(BuildMode buildMode)
    {
        int index = (int)buildMode - 1;

        if (index != -1)
            _image.sprite = _sprites[index];
        else
            _image.sprite = null;
    }


}
