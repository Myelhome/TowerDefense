using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject turret1;
    public int turrent1Prise = 2;

    public void PurchaseTurret1()
    {
        if (BuildManager.buildManager.GetTurrentToBuild() == null)
        {
            if (Player.money - turrent1Prise >= 0)
            {
                BuildManager.buildManager.SetTurrentToBuild(turret1);
                Player.money -= turrent1Prise;
            }
            else Debug.Log("Not Enough $");
        }
        else
        {
            Debug.Log("Turret selected");   
        }
    }
}
