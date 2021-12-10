using UnityEngine;

public class Player : MonoBehaviour
{ 
    public int StartLives = 10;
    public int startMoney = 5;

    public static int money;
    public static int lives;

    void Start()
    {
        money = startMoney;
        lives = StartLives;
    }
}
