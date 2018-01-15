using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float MonsterNumber;
    public float CoinNumber;
    private Transform spawnpoint;
    private Transform spawnpoint2;
    public GameObject Monster;
    public GameObject Collectible;
    public float TimeBetweenM;
    public float TimeBetweenC;

    // Use this for initialization
    void Start () {
        MonsterNumber = 1;
        CoinNumber = 1;
        spawnpoint = GameObject.Find("SpawnPoint").transform;
        spawnpoint2 = GameObject.Find("SpawnPoint_Collectible").transform;
    }

    void SpawnMonster()
    {
        //Debug.Log("MNumber1:" + MonsterNumber);
        if (MonsterNumber < 2)
        {
            //Debug.Log("MNumber2:" + MonsterNumber);
            Instantiate(Monster, spawnpoint);
            MonsterNumber++;
        }
    }

    void SpawnCoin()
    {
        //Debug.Log("MNumber1:" + MonsterNumber);
        if (CoinNumber < 2)
        {
            //Debug.Log("MNumber2:" + MonsterNumber);
            Instantiate(Collectible, spawnpoint2);
            CoinNumber++;
        }
    }

    // Update is called once per frame
    void Update () {
        if (MonsterNumber < 2)
        {
            Invoke("SpawnMonster", TimeBetweenM);
        }
        if (CoinNumber < 2)
        {
            Invoke("SpawnCoin", TimeBetweenC);
        }
        }
}
