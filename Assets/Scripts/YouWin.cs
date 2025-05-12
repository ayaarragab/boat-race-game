using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class YouWin : MonoBehaviour
{
    public GameObject YouWinPanelOne;
    public GameObject YouWinPanelTwo;
    public AudioSource winAudio;


    private void OnTriggerEnter(Collider other)
    {
        winAudio.Play();
        Time.timeScale = 0f;

        if (other.CompareTag("Player1"))
        {
            YouWinPanelOne.SetActive(true);
            
        }
        else if (other.CompareTag("Player2"))
        {
            YouWinPanelTwo.SetActive(true);
        }
    }

}