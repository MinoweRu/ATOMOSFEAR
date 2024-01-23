using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudManager : MonoBehaviour
{

    public GameObject[] CloudEx;
    Vector3 cloudSpawnPoint;
    int spawnTime;
    public int spawnPace;
    public float cloudpace;
    // Start is called before the first frame update
    void Start()
    {
        cloudSpawnPoint = transform.Find("cloudSpawnPoint").localPosition;
        for(float i = 0; i > -20; i = i - cloudpace){
        Instantiate(CloudEx[Random.Range(6, 9)], cloudSpawnPoint + new Vector3(i, -1.0f, 0), Quaternion.identity);
        Instantiate(CloudEx[Random.Range(3, 6)], cloudSpawnPoint + new Vector3(i, -0.5f, 0), Quaternion.identity);
        Instantiate(CloudEx[Random.Range(0, 3)], cloudSpawnPoint + new Vector3(i, 0, 0), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        spawnTime++;
        if (spawnPace < spawnTime)
        {
            Instantiate(CloudEx[Random.Range(6, 9)], cloudSpawnPoint + new Vector3(0, -1.0f, 0), Quaternion.identity);
            Instantiate(CloudEx[Random.Range(3, 6)], cloudSpawnPoint + new Vector3(0, -0.5f, 0), Quaternion.identity);
            Instantiate(CloudEx[Random.Range(0, 3)], cloudSpawnPoint, Quaternion.identity);
            spawnTime = 0;
        }
    }
}
