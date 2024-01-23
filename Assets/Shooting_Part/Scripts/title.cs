using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class title : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject titleMusic;
    public GameObject titleText;
    private AudioSource audioSource;
    private int flash;
    public int flashSpeed;
    void Start()
    {

        audioSource = titleMusic.GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
        Color textColor = titleText.GetComponent<Text>().color;
        
        flash++;
        if (flashSpeed < flash && flash < flashSpeed * 2)
        {
            textColor.a = 0.0f;
            titleText.GetComponent<Text>().color = textColor;
        }
        else if (flash > flashSpeed * 2)
        {
            textColor.a = 255.0f;
            titleText.GetComponent<Text>().color = textColor;
            flash = 0;
        }


        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.JoystickButton14))
        {
            SceneManager.LoadScene("Shooting_Part");
        }
        if (audioSource.isPlaying == false)
        {
            SceneManager.LoadScene("DemoPlay");
        }
    }
}
