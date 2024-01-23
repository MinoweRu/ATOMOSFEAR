using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomize_Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    public float cloudSpeed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-cloudSpeed,0,0);
        if (transform.position.x <= -9.393f)
        {
            Destroy(this.gameObject);
        }
    }
}
