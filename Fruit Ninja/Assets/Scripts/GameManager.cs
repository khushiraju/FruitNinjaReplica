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
    private Collider2D[] fruitCols;

    private void Update(){
        if (Time.time - lastSpawn > deltaSpawn){
            Fruit f = GetFruit();
            float randomX = Random.Range(-1.65f, 1.65f);
            f.LaunchFruit(Random.Range(1.85f,2.75f), randomX,  -randomX);

            lastSpawn = Time.time;
        }

        if(Input.GetMouseButton(0)){
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = -1;
            trail.position = pos;
            Collider2D[] thisFramesFruit = Physics2D.OverlapPointAll(new Vector2(pos.x, pos.y), LayerMask.GetMask("Fruit"));
            Debug.Log(thisFramesFruit.Length);
            foreach(Collider2D coll in thisFramesFruit){
                Debug.Log(coll.name);
                for(int i = 0; i < fruitCols.Length; i++){
                    if (coll == fruitCols[i]){
                        Debug.Log("its a match");
                    }
                }
            }
            fruitCols = thisFramesFruit;

            //work on figuring out why fruits arent being put into the array
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

}
