using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float MonsterNumber;
    public float CoinNumber;
    public float PlatformNumber;
    private Transform spawnpoint;
    private Transform spawnpoint2;
    private Transform spawnpoint3;
    public GameObject Monster;
    public GameObject Collectible;
    public GameObject Platform;
    public float TimeBetweenM;
    public float TimeBetweenC;
    public float TimeBetweenP;

    // Use this for initialization
    void Start () {
        MonsterNumber = 1;
        CoinNumber = 1;
        PlatformNumber = 0;
        spawnpoint = GameObject.Find("SpawnPoint").transform;
        spawnpoint2 = GameObject.Find("SpawnPoint_Collectible").transform;
        spawnpoint3 = GameObject.Find("SpawnPoint_Platform").transform;

    }

    void SpawnMonster()
    {
        //Debug.Log("MNumber1:" + MonsterNumber);
        if (MonsterNumber < 2)
        {
            MonsterNumber++;
            //Debug.Log("MNumber2:" + MonsterNumber);
            Instantiate(Monster, spawnpoint);
            
        }
    }

    void SpawnPlatform()
    {
        //Debug.Log("MNumber1:" + MonsterNumber);
        if (PlatformNumber < 1)
        {
            PlatformNumber++;
            //Debug.Log("MNumber2:" + MonsterNumber);
            Instantiate(Platform, spawnpoint3);
            
        }
    }

    void SpawnCoin()
    {
        //Debug.Log("MNumber1:" + MonsterNumber);
        if (CoinNumber < 2)
        {
            CoinNumber++;
            //Debug.Log("MNumber2:" + MonsterNumber);
            Instantiate(Collectible, spawnpoint2);
          
        }
    }

    // Update is called once per frame
    void Update () {
        TimeBetweenC = Random.Range(5,10);
        TimeBetweenP = Random.Range(1, 8);
        TimeBetweenM = Random.Range(2, 7);
        if (MonsterNumber < 2)
        {
            Invoke("SpawnMonster", TimeBetweenM);
        }
        if (CoinNumber < 2)
        {
            Invoke("SpawnCoin", TimeBetweenC);
        }
        if (PlatformNumber < 1)
        {
            Invoke("SpawnPlatform", TimeBetweenP);
        }
    }
}
