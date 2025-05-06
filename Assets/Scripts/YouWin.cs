using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class YouWin : MonoBehaviour
{
    public GameObject YouWinPanel;
    public AudioSource winAudio;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {

            YouWinPanel.SetActive(true);
            winAudio.Play();
            Time.timeScale = 0f;
        }
    }

}