using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager insatance;

    [SerializeField] private GameObject selectTile = null;

    public GameObject GetSelecttile()
    {
        return this.selectTile;
    }
    public void setSelectTile(GameObject tile)
    {
        this.selectTile = tile;

    }

    private void Awake()
    {
        if (insatance == null)
        {
            insatance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
