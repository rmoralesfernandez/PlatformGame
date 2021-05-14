using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalItems : MonoBehaviour
{
    public static int totalCoins;
    public static int totalStars;
    public Text totalCoinsText;
    public Text totalStarsText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("totalCoins", totalCoins);
        PlayerPrefs.GetInt("totalStars", totalStars);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("totalCoins", totalCoins);
        PlayerPrefs.SetInt("totalStars", totalStars);
        totalCoinsText.text = totalCoins.ToString();
        totalStarsText.text = totalStars.ToString();
    }
}
