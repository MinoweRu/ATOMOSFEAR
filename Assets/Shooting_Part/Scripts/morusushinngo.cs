using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class morusushinngo : MonoBehaviour
{
    public string[] musen;//テキスト内容の箱を作る
    int musenNum;//テキスト内容の箱に番号を振る
    string displayText;//表示する内容
    int textAmount;//テキスト内容の文字の順番何番目かを表示する
    int displayTextSpeed;//追加
    public int textHayasa;
    bool click;
    [SerializeField] private AudioSource MorusuShingo;
    [SerializeField] private AudioClip[] mo;
    public GameObject TEXTBOX;

    void Start()
    {

    }
    void Update()
    {
        displayTextSpeed++;
        if (displayTextSpeed % textHayasa == 0)// % は剰余割り算で割り算を行ったときの余りを得る演算子である
        {
            if (textAmount != musen[musenNum].Length) //最初は0番目が表示されてるから一致していない
            {
                if (textAmount == 0)
                {
                    MorusuShingo.Stop();    
                    MorusuShingo.PlayOneShot(mo[musenNum]);
                }
                displayText = displayText + musen[musenNum][textAmount];//0番目から表示開始
                textAmount = textAmount + 1;//次へ移行
            }
            else
            {

                if (musenNum != musen.Length - 1)//musen.lengthはテキストボックスの種類の数のことで、それがそれが最大数と一致したらって話
                {
                    if (click == true)//移動
                    {//移動
                        displayText = "";//テキスト内容をリセット
                        textAmount = 0;//テキスト内容をリセット
                        musenNum = musenNum + 1;//次のテキストボックスに移行
                    }//移動
                }
                else
                {
                    if (click == true)
                    {
                        
                        Destroy(TEXTBOX);
                    }
                }
            }

            this.GetComponent<Text>().text = displayText;
            click = false;//追加
        }//追加
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.JoystickButton14))//追加
        {//追加
            click = true;//追加
        }//追加
    }
}

