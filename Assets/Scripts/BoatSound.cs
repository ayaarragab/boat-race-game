using UnityEngine;

public class BoatSound : MonoBehaviour
{
    public AudioSource boaySound;
    
    
   void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            boaySound.enabled = true;
        }
        else
        {
            boaySound.enabled = false;
        }
    }

}
