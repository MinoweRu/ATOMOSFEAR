using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class director : MonoBehaviour
{

    public int bossHP = 100;
    public int playerHP = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bossHP <= 0)
        {
            SceneManager.LoadScene("ending");
        }
    }
}
