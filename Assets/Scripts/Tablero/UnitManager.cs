using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager insatance;

    [SerializeField] private AllyUnit allyUnit;
    [SerializeField] private EnemygUnit enemyUnit;

    [SerializeField] private BaseUnit selectedUnit = null;



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
    private void Start()
    {
        SpawnUnits();
    }
    public BaseUnit GetSelectedUnit()
    {
        return this.selectedUnit;
    }

    public void SetSelectedUnit(BaseUnit unit)
    {
        this.selectedUnit = unit;
    }
    public void SpawnUnits()
    {
        AllyUnit u1 = Instantiate(allyUnit);
        GridManager.instance.GetTile(0, 0).SetUnit(u1);


       EnemygUnit e1 = Instantiate(enemyUnit);
        GridManager.instance.GetTile(7, 7).SetUnit(e1);
    }

}
