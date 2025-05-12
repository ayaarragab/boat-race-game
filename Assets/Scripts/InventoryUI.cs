using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI CoinsText;

    void Start()
    {
        CoinsText = GetComponent<TextMeshProUGUI>();

    }

    public void UpdateCoinsText(PlayerInventory playerInventory)
    {
        CoinsText.text = playerInventory.NumberOfCoins.ToString();
    }

}
