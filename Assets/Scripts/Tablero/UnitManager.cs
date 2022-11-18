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

        AllyUnit u2 = Instantiate(allyUnit);
        GridManager.instance.GetTile(1, 1).SetUnit(u2);

        AllyUnit u3 = Instantiate(allyUnit);
        GridManager.instance.GetTile(0, 2).SetUnit(u3);

        AllyUnit u4 = Instantiate(allyUnit);
        GridManager.instance.GetTile(2,0 ).SetUnit(u4);

        AllyUnit u5 = Instantiate(allyUnit);
        GridManager.instance.GetTile(2, 2).SetUnit(u5);

        AllyUnit u6 = Instantiate(allyUnit);
        GridManager.instance.GetTile(3, 1).SetUnit(u6);

        AllyUnit u7 = Instantiate(allyUnit);
        GridManager.instance.GetTile(4, 2).SetUnit(u7);

        AllyUnit u8 = Instantiate(allyUnit);
        GridManager.instance.GetTile(4, 0).SetUnit(u8);

        AllyUnit u9 = Instantiate(allyUnit);
        GridManager.instance.GetTile(5, 1).SetUnit(u9);

        AllyUnit u10 = Instantiate(allyUnit);
        GridManager.instance.GetTile(6, 2).SetUnit(u10);

        AllyUnit u11 = Instantiate(allyUnit);
        GridManager.instance.GetTile(6, 0).SetUnit(u11);

        AllyUnit u12 = Instantiate(allyUnit);
        GridManager.instance.GetTile(7, 1).SetUnit(u12);











        //Enemy
        EnemygUnit e1 = Instantiate(enemyUnit);
        GridManager.instance.GetTile(7, 7).SetUnit(e1);

        EnemygUnit e2 = Instantiate(enemyUnit);
        GridManager.instance.GetTile(6, 6).SetUnit(e2);

        EnemygUnit e3 = Instantiate(enemyUnit);
        GridManager.instance.GetTile(5, 7).SetUnit(e3);

        EnemygUnit e4 = Instantiate(enemyUnit);
        GridManager.instance.GetTile(7, 5).SetUnit(e4);

        EnemygUnit e5 = Instantiate(enemyUnit);
        GridManager.instance.GetTile(5, 5).SetUnit(e5);

        EnemygUnit e6 = Instantiate(enemyUnit);
        GridManager.instance.GetTile(3, 7).SetUnit(e6);

        EnemygUnit e7 = Instantiate(enemyUnit);
        GridManager.instance.GetTile(1, 7).SetUnit(e7);

        EnemygUnit e8 = Instantiate(enemyUnit);
        GridManager.instance.GetTile(4, 6).SetUnit(e8);

        EnemygUnit e9 = Instantiate(enemyUnit);
        GridManager.instance.GetTile(2, 6).SetUnit(e9);

        EnemygUnit e10 = Instantiate(enemyUnit);
        GridManager.instance.GetTile(0, 6).SetUnit(e10);

        EnemygUnit e11 = Instantiate(enemyUnit);
        GridManager.instance.GetTile(3, 5).SetUnit(e11);

        EnemygUnit e12 = Instantiate(enemyUnit);
        GridManager.instance.GetTile(1, 5).SetUnit(e12);
    }

}
