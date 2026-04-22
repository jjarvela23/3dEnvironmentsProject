using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int Coins = 0;
    private TextMeshProUGUI coinText;
    void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
    }

    public void AddCoin()
    {
        Coins++;
    }

    public int GetCoins()
    {
        return Coins;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Total coins: " + Coins.ToString() + "/10";
    }
}
