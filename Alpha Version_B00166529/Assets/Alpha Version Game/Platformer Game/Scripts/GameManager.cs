using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;       // Reference to TextMeshProUGUI component for coin count
    public TextMeshProUGUI starText;       // Reference to TextMeshProUGUI component for star count
    public TextMeshProUGUI gemText;        // Reference to TextMeshProUGUI component for diamond count
    public TextMeshProUGUI treasureText;   // Reference to TextMeshProUGUI component for treasure count

    private int coin = 0;                  // Store the coin count
    private int star = 0;                  // Store the star count
    private int gem = 0;                   // Store the gem count
    private int treasure = 0;              // Store the treasure count

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();  // Initial update of all UI elements
    }

    // Method to increase the coin count
    public void IncreaseCoinCount()
    {
        coin++;
        UpdateUI();  // Update all UI text
    }

    // Method to increase the star count
    public void IncreaseStarCount()
    {
        star++;
        UpdateUI();  // Update all UI text
    }

    // Method to increase the diamond count
    public void IncreaseDiamondCount()
    {
        gem++;
        UpdateUI();  // Update all UI text
    }

    // Method to increase the treasure count
    public void IncreaseTreasureCount()
    {
        treasure++;
        UpdateUI();  // Update all UI text
    }

    // Method to update all UI text
    private void UpdateUI()
    {
        coinText.text = "Coin: " + coin;
        starText.text = "Star: " + star;
        gemText.text = "Gem: " + gem;
        treasureText.text = "Treasure: " + treasure;
    }
}
