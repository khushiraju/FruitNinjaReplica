using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<Fruit> fruits = new List<Fruit>();
    public GameObject fruitPrefab;
    public Transform trail;

    private float lastSpawn; 
    private float deltaSpawn = 1.0f;
    private Collider[] fruitsCols;

    private void Update(){
        if (Time.time - lastSpawn > deltaSpawn){
            Fruit f = GetFruit();
            float randomX = Random.Range(-1.65f, 1.65f);
            f.LaunchFruit(Random.Range(1.85f,2.75f), randomX,  -randomX);

            lastSpawn = Time.time;
        }

        if(Input.GetMouseButton(0)){
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Physics2D.RaycastAll(new Vector2(pos.x, pos.y), , )
            pos.z = -1;
            trail.position = pos;

            // work on overlap for the fruit components 
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

    // 33:40
}
