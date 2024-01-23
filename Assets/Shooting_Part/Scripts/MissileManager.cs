using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileManager : MonoBehaviour
{
    public GameObject[] MissileNum = new GameObject[2];
    private int flash;
    public int flashSpeed;

    [SerializeField] private GameObject TEXTBOX;

    private int Misslie = 4;

    void Update()
    {



        if (0 < Misslie && !TEXTBOX)
        {
            Color color = MissileNum[Misslie - 1].GetComponent<Image>().color;
            color.a = 255.0f;
            MissileNum[Misslie - 1].GetComponent<Image>().color = color;
            if (Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.JoystickButton15))
            {
                flash++;
                Debug.Log(flash);
                if (flashSpeed < flash && flash < flashSpeed * 2)
                {
                    color.a = 0.0f;
                    MissileNum[Misslie - 1].GetComponent<Image>().color = color;
                }
                else if (flash > flashSpeed * 2)
                {
                    flash = 0;
                }
            }

            if (Input.GetKeyUp(KeyCode.X) || Input.GetKeyUp(KeyCode.JoystickButton15))
            {
                MissileNum[Misslie - 1].SetActive(false);
                Misslie--;
            }
        }
    }
}
