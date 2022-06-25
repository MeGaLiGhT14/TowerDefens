using UnityEngine;

public class ClickMouse : MonoBehaviour
{
    private SelectTower _selectTower;

    private void Start()
    {
        _selectTower = GetComponent<SelectTower>();
    }

    private void Update()
    {
        Vector3 vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(vector , Vector3.back , 2 , 1 << 11);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null)
            {
                ConstructionSite constructionSite;
                if (constructionSite = hit.collider.GetComponent<ConstructionSite>())
                    if (_selectTower.TowerSelected)
                        constructionSite.BuildTower((int)_selectTower.Index);
                    else if (_selectTower.SelectedSele)
                        constructionSite.DreackTower();
            }
        }
    }
}