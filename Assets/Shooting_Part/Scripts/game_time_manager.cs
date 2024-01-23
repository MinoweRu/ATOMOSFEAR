using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class game_time_manager : MonoBehaviour
{
    //カウントダウン
    public float countdown;
 
    //時間を表示するText型の変数
    public Text timeText;
    private float second;
    private int minute = 2;
    
    [SerializeField] private GameObject TEXTBOX;
 
    // Update is called once per frame
    void Update()
    {
        if(!TEXTBOX){
        //時間をカウントダウンする
        second -= Time.deltaTime;
 
        //時間を表示する
        timeText.text = minute.ToString("00") + ":" + second.ToString("00");

        if(second < 0.0f)
        {
            minute -= 1;
            second = 59;
        }
 
        //countdownが0以下になったとき
        if (minute < 0)
        {
            timeText.text = "0";
            SceneManager.LoadScene("gameover");
        }
    }
    }
}
