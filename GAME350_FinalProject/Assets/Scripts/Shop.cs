using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBlueprint turret;
    public TowerBlueprint glueMissile;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTurret()
    {
        buildManager.selectTowerToBuild(turret);
        Debug.Log("Turret Purchased!");
    }
    public void SelectGlueMissile()
    {
        buildManager.selectTowerToBuild(glueMissile);
        Debug.Log("Glue Missile Purchased!");
    }
}
