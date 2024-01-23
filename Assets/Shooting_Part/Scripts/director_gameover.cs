using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class director_gameover : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject bgm;
    GameObject back;
    GameObject transition;
    public float tranSpeed;
    void Start()
    {
        bgm = GameObject.Find("gameover");
        back = GameObject.Find("1 (1)");
        transition = GameObject.Find("transition");
        StartCoroutine(AllActive());
        bgm.SetActive(false);
        back.SetActive(false);
        
    }

     private IEnumerator AllActive()
    {
        yield return new WaitForSeconds(2);
        bgm.SetActive(true);
        back.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        Color color = transition.GetComponent<RawImage>().color;
        color.a -= tranSpeed;
        transition.GetComponent<RawImage>().color = color;

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.JoystickButton14))
        {
            if (bgm.activeSelf || back.activeSelf)
            {
                SceneManager.LoadScene("Title");
            }
        }
    }

   
}
