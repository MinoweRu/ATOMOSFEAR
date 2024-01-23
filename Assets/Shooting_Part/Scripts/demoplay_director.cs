using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class demoplay_director : MonoBehaviour
{
    public GameObject video;
    private VideoPlayer demoMov;

    private void Start()
    {
        // コルーチンの起動
        StartCoroutine(DelayCoroutine());
        demoMov = video.GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("title");
        }
    }
    // コルーチン本体
    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(3);
        demoMov.Play();
        yield return new WaitForSeconds(29);
        Destroy(video);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("title");
    }
}
