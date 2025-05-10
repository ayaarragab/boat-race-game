using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI player1CoinText;
    public TextMeshProUGUI player2CoinText;
    public GameObject levelCompletePanel;
    public TextMeshProUGUI winText;

    public Button replayButton;
    public Button nextLevelButton;
    public Button mainMenuButton;

    public int player1Coins = 0;
    public int player2Coins = 0;
    private const int maxCoinsPerPlayer = 50;

    [SerializeField] private AudioClip winSound;  // ??? ?????

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (replayButton != null)
            replayButton.onClick.AddListener(RestartLevel);

        if (nextLevelButton != null)
            nextLevelButton.onClick.AddListener(NextLevel);

        if (mainMenuButton != null)
            mainMenuButton.onClick.AddListener(MainMenu);

        UpdateCoinsDisplay();
    }

    public void AddCoins(int playerNumber, int amount)
    {
        if (playerNumber == 1)
        {
            player1Coins = Mathf.Min(player1Coins + amount, maxCoinsPerPlayer);
        }
        else if (playerNumber == 2)
        {
            player2Coins = Mathf.Min(player2Coins + amount, maxCoinsPerPlayer);
        }

        UpdateCoinsDisplay();
        CheckWinCondition();
    }

    private void UpdateCoinsDisplay()
    {
        player1CoinText.text = $"Player 1: {player1Coins}/{maxCoinsPerPlayer}";
        player2CoinText.text = $"Player 2: {player2Coins}/{maxCoinsPerPlayer}";
    }

    private void CheckWinCondition()
    {
        if (player1Coins >= maxCoinsPerPlayer && player2Coins >= maxCoinsPerPlayer)
        {
            ShowWinPanel("Both Players");
        }
    }

    public void ShowWinPanel(string playerTag)
    {
        levelCompletePanel.SetActive(true);
        winText.text = $"{playerTag} Collected All Coins!";

        if (winSound != null)
        {
            AudioManager.Instance.PlayClip(winSound);
        }
    }

    public void RestartLevel()
    {
        player1Coins = 0;
        player2Coins = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        player1Coins = 0;
        player2Coins = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu");
    }
}
