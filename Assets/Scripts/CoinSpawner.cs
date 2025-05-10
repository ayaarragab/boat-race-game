using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private int coinsPerPlayer = 50;
    [SerializeField] private float spacing = 2f;
    [SerializeField] private int coinsPerRow = 10;

    void Start()
    {
        SpawnCoinsForPlayer(1, new Vector3(0f, 0f, 0f));
        SpawnCoinsForPlayer(2, new Vector3(30f, 0f, 0f));
        StartCoroutine(SpawnCoinCoroutine());
    }

    void SpawnCoinsForPlayer(int playerId, Vector3 startPosition)
    {
        for (int i = 0; i < coinsPerPlayer; i++)
        {
            int row = i / coinsPerRow;
            int column = i % coinsPerRow;

            Vector3 position = new Vector3(
                startPosition.x + column * spacing,
                startPosition.y,
                startPosition.z + row * spacing
            );

            Instantiate(coinPrefab, position, Quaternion.identity);
        }
    }

    IEnumerator SpawnCoinCoroutine()
    {
        while (true)
        {
            if (UIManager.Instance.player1Coins < 50 || UIManager.Instance.player2Coins < 50)
            {
                int randomIndex = Random.Range(0, 3);
                float xValue = 0f;

                if (randomIndex == 0)
                    xValue = -30f;
                else if (randomIndex == 1)
                    xValue = 0f;
                else if (randomIndex == 2)
                    xValue = 30f;

                float delay = Random.Range(1f, 5f);
                yield return new WaitForSeconds(delay);

                Instantiate(coinPrefab, new Vector3(xValue, -0.13f, 30f), Quaternion.identity);
            }
            else
            {
                yield return null; // ?? ????? ??? ??? ???? ??????
            }
        }
    }
}
