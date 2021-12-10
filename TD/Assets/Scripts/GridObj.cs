using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObj : MonoBehaviour
{
    private GameObject turret;

    void Start()
    {
        
    }

    void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Cant build!");
            return;
        }

        GameObject turrentToBuild = BuildManager.buildManager.GetTurrentToBuild();
        if (turrentToBuild != null)
        {
            turret = (GameObject)Instantiate(turrentToBuild, transform.position, transform.rotation);
            BuildManager.buildManager.SetTurrentToBuild(null);
        }
    }
}
