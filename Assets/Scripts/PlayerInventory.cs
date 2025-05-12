using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfCoins {  get; private set; }
    public UnityEvent<PlayerInventory> OnCoinsCollected;
    public void CoinsCollected()
    {
        NumberOfCoins++;
        Debug.Log("OnTriggerEnter called with: " + NumberOfCoins);
        OnCoinsCollected.Invoke(this);
    }
}
