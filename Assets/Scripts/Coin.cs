using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1;
    [SerializeField] private ParticleSystem collectEffect;
    [SerializeField] private AudioClip collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1") && UIManager.Instance.player1Coins < 50)
        {
            CollectCoin(1);
        }
        else if (other.CompareTag("Player2") && UIManager.Instance.player2Coins < 50)
        {
            CollectCoin(2);
        }
    }

    private void CollectCoin(int playerNumber)
    {
        UIManager.Instance.AddCoins(playerNumber, coinValue);

        if (collectEffect != null)
        {
            ParticleSystem effect = Instantiate(collectEffect, transform.position, Quaternion.identity);
            Destroy(effect.gameObject, effect.main.duration);
        }

        if (collectSound != null)
        {
            AudioManager.Instance.PlayClip(collectSound);
        }

        Destroy(gameObject);
    }
}
