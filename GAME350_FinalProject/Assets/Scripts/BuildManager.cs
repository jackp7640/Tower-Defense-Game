using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TowerBlueprint towerToBuild;

    public GameObject TurretPrefab;
    public GameObject GlueMissilePrefab;

    // Create an instance of this BuildManager
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene");
            return;
        }
        instance = this;
    }

    // return true if player can build, return false otherwise
    public bool CanBuild { get { return towerToBuild != null; } }

    public void selectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
    }

    public void buildTowerOn(TileBehaviour tile) 
    {
        // if player does not have enough money to buy selected tower, return
        if (PlayerStats.money < towerToBuild.cost)
        {
            Debug.Log("CAN'T BUY! NOT ENOUGH MONEY");
            return;
        }

        PlayerStats.money -= towerToBuild.cost;
        GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, tile.transform);
        tile.tower = tower;

        Debug.Log("TOWER BUILT! MONEY LEFT: " + PlayerStats.money);
    }
}
