using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_effect_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 0.20f);
    }

    // Update is called once per frame
    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
