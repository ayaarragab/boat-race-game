using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player1") || other.CompareTag("Player2")) &&
            UIManager.Instance.player1Coins >= 50 &&
            UIManager.Instance.player2Coins >= 50)
        {
            UIManager.Instance.ShowWinPanel("Both Players");
        }
    }
}