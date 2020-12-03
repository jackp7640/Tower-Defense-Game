using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TileBehaviour : MonoBehaviour
{
    public Color hoverColor;

    public GameObject tower;

    SpriteRenderer sr;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        startColor = sr.color;

        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (tower != null)
        {
            Debug.Log("CANT BUILD HERE!");
            return;
        }

        // Build a tower
        buildManager.buildTowerOn(this);

        //GameObject towerToBuild = buildManager.GetTowerToBuild();
        //tower = (GameObject)Instantiate(towerToBuild, transform);


    }

    private void OnMouseEnter()
    {
        // If there is no tower to build, don't change the color of the button.
        if (!buildManager.CanBuild)
        {
            return;
        }

        //sr.material.color = Color.red;
        sr.color = hoverColor;
        //Debug.Log("MOUSE ENTERED");
    }

    private void OnMouseExit()
    {
        //sr.material.color = startColor;
        sr.color = startColor;
        //Debug.Log("MOUSE EXITED");
    }


}
