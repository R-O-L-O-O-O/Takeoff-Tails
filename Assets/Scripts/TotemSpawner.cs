using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemSpawner : MonoBehaviour
{
    public float maxTime = 1;
    private float timer = 0;
    public GameObject[] totem;
    public float height;

    int randomSpawn;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newtotem = Instantiate(totem[Random.Range(0, totem.Length)]);
        newtotem.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
    }

    // Update is called once per frame
    void Update()
    {
        randomSpawn = Random.Range(0, randomSpawn);
        if(timer > maxTime)
        {
            GameObject newtotem = Instantiate(totem[Random.Range(0, totem.Length)]);
            newtotem.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newtotem, 15);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
