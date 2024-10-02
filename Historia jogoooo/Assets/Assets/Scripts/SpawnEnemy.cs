using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{ //Privacidade tipo nome;
    public int[] teste;
    public Transform spawnPos;
    public Transform[] spawnPoints;//ARRAY
    public List<GameObject> enemies;//Lista
    public GameObject enemyPrefab;
    public float spawnRate;
    float timer;
    // Start is called before the first frame update
    void Start()
    {

        //InvokeRepeating("Spawn", 0, spawnRate);
        //StartCoroutine(CallSpawn());
        StartCoroutine(Teste());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnRate)
        {
            //Spawn(Random.Range(1, 100));
            Spawn(1);
            timer = 0;
        }
    }
    void Spawn(int qtd)
    {
        for(int i = 0; i < qtd; i++)
        {
            int random = Random.Range(0, spawnPoints.Length);
            enemies.Add(Instantiate(enemyPrefab, spawnPoints[random].position, spawnPoints[random].rotation));
            
            if (i == qtd / 2)
            {
                enemies[i].GetComponent<SpriteRenderer>().color = Color.magenta;
            }
            
        } 

    }
    IEnumerator CallSpawn()
    {
        yield return new WaitForSeconds(spawnRate);
        //Spawn();
        StartCoroutine(CallSpawn());
    }
    IEnumerator Teste()
    {
        for (int i = 0; i < 5; i++)
        {
            print("Foi " + i);
            yield return new WaitForSeconds(2);
        }
    }
}
