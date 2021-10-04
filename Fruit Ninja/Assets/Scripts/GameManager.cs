using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<Fruit> fruits = new List<Fruit>();
    public GameObject fruitPrefab;

    private float lastSpawn; 
    private float deltaSpawn = 2.0f;

    private void Update(){
        if (Time.time - lastSpawn > deltaSpawn){
            Fruit f = GetFruit();
            float randomX = Random.Range(-1.5f, 1.5f);
            f.LaunchFruit(Random.Range(1.5f,3.0f), randomX,  -randomX);

            lastSpawn = Time.time;
        }
    }

    private Fruit GetFruit(){
        Fruit f = fruits.Find(x => !x.isActive);

        if (f == null){
            f = Instantiate(fruitPrefab).GetComponent<Fruit>();
            fruits.Add(f);
        }
        return f;
    }

    // 22:31 
}
