using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;   
    public AudioSource LOOSEAudio;


    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
    //    {
    //        ShowGameOver();
    //    }
    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))  
        {
            ShowGameOver();
        }
    }

    void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        LOOSEAudio.Play();
        Time.timeScale = 0f; 
    }
}
