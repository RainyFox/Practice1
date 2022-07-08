using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] MonsterList;

    private GameObject spawnedMonster;
    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.RandomRange(1, 5));
            randomIndex = Random.Range(0, MonsterList.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(MonsterList[randomIndex]);
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                Debug.Log("spawnedMonster.transform.position: " + spawnedMonster.transform.position);
                spawnedMonster.GetComponent<Monsters>().speed = Random.Range(6, 8);
            }
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                Debug.Log("spawnedMonster.transform.position: " + spawnedMonster.transform.position);
                spawnedMonster.GetComponent<Monsters>().speed = -Random.Range(6, 8);
                spawnedMonster.transform.localScale = new Vector3(-1, 1, 1);
            }
        }//while
    }
}
