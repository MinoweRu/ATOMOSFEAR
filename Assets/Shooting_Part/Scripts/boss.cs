using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class boss : MonoBehaviour
{
  // Start is called before the first frame update
  public int bossHP = 100;
  public int bossHit;
  public int AnimeMaxNum;
  GameObject bgm;
  GameObject transition;
  GameObject body1;
  GameObject body2;
  GameObject body3;

  public GameObject effect;
  public float tranSpeed;
  [SerializeField] public AudioSource gotAttacked;
  [SerializeField] public AudioClip fireSE;
  [SerializeField] public AudioClip bombSE;
  [SerializeField] private AudioClip deadSE;
  [SerializeField] public GameObject TEXTBOX;
  Animator animator;
  bool isCalledOnce = false;
  void Start()
  {
    animator = GetComponent<Animator>();
    bgm = GameObject.Find("maintheme_re");
    transition = GameObject.Find("transition");
    body1 = GameObject.Find("head_pivot");
    body2 = GameObject.Find("jaw_pivot");
    body3 = GameObject.Find("body_pivot");
  }

  private void OnTriggerEnter2D(Collider2D onara)
  {

    if (onara.gameObject.name == "asteroid(Clone)")
    {
      gotAttacked.PlayOneShot(bombSE);
      Debug.Log("ヴぉえ！");
      bossHP -= 30;
      bossHit++;
    }
    if (onara.gameObject.name == "shoot1(Clone)")
    {
      gotAttacked.PlayOneShot(fireSE);
      Debug.Log("痛すぎワロリンヌwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww");
      bossHP -= 1;
      bossHit++;
    }
  }

  void Update()
  {
    Transform sakana = gameObject.GetComponent<Transform>();
    animator.SetBool("attacked", false);
    if (bossHit >= 1)
    {
      animator.SetBool("attacked", true);
      bossHit = 0;
    }
    if (bossHP < 0)
    {
      Destroy(bgm);
      Color color = transition.GetComponent<RawImage>().color;
      color.a += tranSpeed;
      transition.GetComponent<RawImage>().color = color;
      body1.SetActive(false);
      body2.SetActive(false);
      body3.SetActive(false);
      if (!isCalledOnce)
      {
        Instantiate(effect, transform.position, Quaternion.identity);
        isCalledOnce = true;
        gotAttacked.PlayOneShot(deadSE);
      }
      if (color.a > 1.0f)
      {
        SceneManager.LoadScene("ending");
      }
    }
    if (bossHP >= 0)
    {
      if (TEXTBOX)
      {
        animator.SetInteger("ATKPattern", 99);
      }
      else
      {
        if (sakana.position.x < Random.Range(0.0f, 1.0f))
        {
          animator.SetInteger("ATKPattern", 0);
        }
        else
        {
          animator.SetInteger("ATKPattern", Random.Range(1, AnimeMaxNum));
        }
      }
    }
  }
}