using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMove : MonoBehaviour
{

    public float fireMoveSpeed = 7.0f;// 移動値
    // Start is called before the first frame update
    public float deleteDistance = 35 * 35;   // 削除距離
    public float downAngle;
    SpriteRenderer isshun;
    GameObject playerObj;
    GameObject boss;
    boss bossHP;
    AudioClip fireSE;
    [SerializeField] public GameObject effect;
    void Start()
    {
        playerObj = GameObject.Find("player1");
        boss = GameObject.Find("boss");
        isshun = gameObject.GetComponent<SpriteRenderer>();
        bossHP = boss.GetComponent<boss>();
        fireSE = bossHP.fireSE;
        isshun.color = new Color(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {

        isshun.color = new Color(255, 255, 255, 255);
        //Debug.Log(transform.position);
        transform.Translate(fireMoveSpeed * Time.deltaTime, 0, 0);
        float distance = (playerObj.transform.position - transform.position).sqrMagnitude;

        if (Input.GetKey("down") || Input.GetKey(KeyCode.JoystickButton7))
        {
            transform.rotation = Quaternion.Euler(0, 0, -downAngle);
        }

        // 一定の距離が離れたら消す
        if (distance > deleteDistance)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D onara)
    {
        if (onara.gameObject.name == "stage1_boss_head" ||
             onara.gameObject.name == "stage1_boss_body" ||
             onara.gameObject.name == "stage1_boss_jaw" ||
             onara.gameObject.name == "Stage1_boss_tale_end")
        {
            bossHP.bossHP --;
            bossHP.bossHit ++;
            bossHP.gotAttacked.PlayOneShot(fireSE);
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }
}
