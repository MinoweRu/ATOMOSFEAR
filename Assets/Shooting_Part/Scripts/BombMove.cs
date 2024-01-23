using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BombMove : MonoBehaviour
{

    public float deleteDistance = 35 * 35;   // 削除距離
    int bombCount = 1;
    private float downforce = 1;
    public float xLimit = 8.5f;
    public float yLimit = 4.5f;
    public float downAngle;
    GameObject playerObj;
    GameObject boss;
    boss bossHP;
    AudioClip bombSE;
    Animator animator;
    [SerializeField] public GameObject effect;
    [SerializeField] private AudioSource shoot;
    [SerializeField] private AudioClip bombShoot;
    void Start()
    {
        playerObj = GameObject.Find("player1");
        animator = GetComponent<Animator>();
        boss = GameObject.Find("boss");
        bossHP = boss.GetComponent<boss>();
        bombSE = bossHP.bombSE;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);
        Vector2 position = transform.position;
        float distance = (playerObj.transform.position - transform.position).sqrMagnitude;
        Rigidbody2D missile = GetComponent<Rigidbody2D>();
        if (Input.GetKey("down") || Input.GetKey(KeyCode.JoystickButton7))
        {
            transform.rotation = Quaternion.Euler(0, 0, -downAngle);
            downforce = 0.3f;
        }

        float misDropSpeed = Mathf.Abs(missile.velocity.y);
        if (bombCount == 1)
        {
            if (Input.GetKeyUp(KeyCode.X) || Input.GetKeyUp(KeyCode.JoystickButton15))
            {
                missile.gravityScale = 0;
                missile.AddForce(Vector2.right * 0.1f);
                missile.AddForce(Vector2.up * misDropSpeed * 0.005f * downforce);
                animator.SetBool("released", true);
                shoot.PlayOneShot(bombShoot);
                bombCount--;
            }
        }
        // 一定の距離が離れたら消す
        if (position.x > xLimit || position.x < -xLimit ||
        position.y > yLimit || position.y < -4.0f)
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D onara)
    {
        if (onara.gameObject.name == "stage1_boss_head" ||
             onara.gameObject.name == "stage1_boss_body" ||
             onara.gameObject.name == "stage1_boss_jaw" ||
             onara.gameObject.name == "Stage1_boss_tale_end")
        {
            bossHP.bossHP -= 30;
            bossHP.bossHit++;
            bossHP.gotAttacked.PlayOneShot(bombSE);
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }
}
