using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager buildManager;

    private GameObject turrentToBuild;

    void Awake()
    {
        buildManager = this;
    }

    public GameObject GetTurrentToBuild()
    {
        return turrentToBuild;
    }

    public void SetTurrentToBuild(GameObject turret)
    {
        turrentToBuild = turret;
    }
}
