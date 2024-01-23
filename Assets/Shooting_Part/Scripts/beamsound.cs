using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beamsound : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource sosu;
    [SerializeField] private AudioClip beamSound;
    GameObject lazer;
    void Start()
    {
        lazer = GameObject.Find("lazerCollider");
        sosu = GetComponent<AudioSource>();
        sosu.PlayOneShot(beamSound);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
