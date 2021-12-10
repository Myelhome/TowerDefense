using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public static void GameWon()
    {
        SceneManager.LoadScene("Winner");
    }

    public static void GameLost()
    {
        SceneManager.LoadScene("Defeated");
    }
}
