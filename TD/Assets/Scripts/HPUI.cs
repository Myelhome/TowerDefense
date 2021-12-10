using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    public Text HPText;
    
    void Update()
    {
        HPText.text = "HP: " + Player.lives;
    }
}
