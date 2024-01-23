using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_splash : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;

    Animator animator;
    void Start()
    {
        player = GameObject.Find("player1");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x = player.transform.position.x;
        transform.position = position;

        Color color = GetComponent<SpriteRenderer>().color;
        color.a = 0.0f;
        GetComponent<SpriteRenderer>().color = color;

        if (player.transform.position.y > -1.5f)
        {
            color.a = 0.0f;
            GetComponent<SpriteRenderer>().color = color;
        }
        if (-2.0f < player.transform.position.y && player.transform.position.y <= -1.5f)
        {
            animator.SetInteger("distance", 1);
            color.a = 0.5f;
            GetComponent<SpriteRenderer>().color = color;
        }
        if (-2.5f < player.transform.position.y && player.transform.position.y <= -2.0f)
        {
            animator.SetInteger("distance", 2);
            color.a = 0.5f;
            GetComponent<SpriteRenderer>().color = color;
        }
        if (-3.0f < player.transform.position.y && player.transform.position.y <= -2.5f)
        {
            animator.SetInteger("distance", 3);
            color.a = 0.5f;
            GetComponent<SpriteRenderer>().color = color;
        }
    }
}
