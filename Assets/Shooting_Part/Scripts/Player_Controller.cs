using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.05f;
    public GameObject Fire;// 弾のゲームオブジェクト
    public GameObject Bomb;
    public GameObject effect;
    GameObject bgm;
    GameObject transition;
    public int bombNum = 2;
    public float shootDelay = 10;
    private float zHoldTime;
    public float xLimit = 8.5f;
    public float DownYLimit;
    public float UpYLimit;
    public float downAngle;
    Vector3 FirePoint;
    Vector3 MissilePoint;
    public int playerHP;
    public float tranSpeed;
    [SerializeField] private AudioSource shoot;
    [SerializeField] private AudioClip fireSE;
    [SerializeField] private AudioClip bombSE;
    [SerializeField] private AudioClip deadSE;
    [SerializeField] private GameObject TEXTBOX;
    Animator animator;
    bool isCalledOnce = false;

    void Start()
    {
        FirePoint = transform.Find("FirePoint").localPosition;
        MissilePoint = transform.Find("MissliePoint").localPosition;
        bgm = GameObject.Find("maintheme_re");
        transition = GameObject.Find("transition");
        shoot = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!TEXTBOX)
        {
            if (playerHP > 0)
            {
                Vector2 position = transform.position;
                if (Input.GetKey("left") || Input.GetKey(KeyCode.JoystickButton5))
                {
                    position.x -= speed * Time.deltaTime;
                }
                if (Input.GetKey("right") || Input.GetKey(KeyCode.JoystickButton6))
                {
                    position.x += speed * Time.deltaTime;
                }


                if (Input.GetKey("up") || Input.GetKey(KeyCode.JoystickButton8))
                {
                    position.y += speed * Time.deltaTime;
                }

                if (Input.GetKey("down") || Input.GetKey(KeyCode.JoystickButton7))
                {
                    position.y -= speed * Time.deltaTime;
                    transform.rotation = Quaternion.Euler(0, 0, -downAngle);
                }
                if (Input.GetKeyUp("down") || Input.GetKeyUp(KeyCode.JoystickButton7))
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                position.x = Mathf.Clamp(position.x, -xLimit, xLimit);
                position.y = Mathf.Clamp(position.y, DownYLimit, UpYLimit);

                transform.position = position;

                // ボタンを押したとき
                if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.JoystickButton14))
                {
                    zHoldTime += 1;
                    //  Debug.Log(zHoldTime);
                    if (zHoldTime >= shootDelay)
                    {
                        zHoldTime = 0;
                        shoot.PlayOneShot(fireSE);// 弾の生成
                        Instantiate(Fire, transform.position + FirePoint, Quaternion.identity);
                        //このQuaternionは回転を表す、ベクトルであらわされるものだからね！)
                    }

                    if (bombNum <= 0)
                    {
                        animator.SetInteger("state", 2);
                    }
                    else
                    {
                        animator.SetInteger("state", 1);
                    }

                }
                else
                {
                    if (bombNum > 0)
                    {
                        animator.SetInteger("state", 3);
                    }
                    else
                    {
                        animator.SetInteger("state", 4);
                    }
                }

                if (bombNum > 0)
                {
                    if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.JoystickButton15))
                    {
                        bombNum -= 1;
                        shoot.PlayOneShot(bombSE);
                        Instantiate(Bomb, transform.position + MissilePoint, Quaternion.identity);
                    }
                }


            }

            if (playerHP < 0)
            {
                Destroy(bgm);
                Color color = transition.GetComponent<RawImage>().color;
                Color pColor = gameObject.GetComponent<SpriteRenderer>().color;
                pColor.a = 0.0f;
                color.a += tranSpeed;
                transition.GetComponent<RawImage>().color = color;
                gameObject.GetComponent<SpriteRenderer>().color = pColor;
                if (!isCalledOnce)
                {
                    Instantiate(effect, transform.position, Quaternion.identity);
                    isCalledOnce = true;
                    shoot.PlayOneShot(deadSE);
                }
                if (color.a > 1.0f)
                {
                    SceneManager.LoadScene("gameover");
                }
            }

            //Debug.Log(position);
            //Debug.Log(rotation);
        }


    }
    private void OnTriggerEnter2D(Collider2D onara)
    {
        if (!TEXTBOX)
        {
            if (onara.gameObject.name == "stage1_boss_head" ||
             onara.gameObject.name == "stage1_boss_body" ||
             onara.gameObject.name == "stage1_boss_jaw" ||
             onara.gameObject.name == "Stage1_boss_tale" ||
             onara.gameObject.name == "Stage1_boss_tale (1)" ||
             onara.gameObject.name == "Stage1_boss_tale (2)" ||
             onara.gameObject.name == "Stage1_boss_tale (3)" ||
             onara.gameObject.name == "Stage1_boss_tale (4)" ||
             onara.gameObject.name == "Stage1_boss_tale (5)" ||
             onara.gameObject.name == "Stage1_boss_tale (6)" ||
             onara.gameObject.name == "Stage1_boss_tale (7)" ||
             onara.gameObject.name == "Stage1_boss_tale (8)" ||
             onara.gameObject.name == "Stage1_boss_tale (9)" ||
             onara.gameObject.name == "Stage1_boss_tale_end" ||
             onara.gameObject.name == "lazerCollider" ||
             onara.gameObject.name == "oceanbox")
            {
                Debug.Log("でかすぎんだろ...");
                playerHP -= 2;
            }

        }
    }
}
