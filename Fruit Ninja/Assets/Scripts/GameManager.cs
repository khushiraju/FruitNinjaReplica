using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private List<Fruit> fruits = new List<Fruit>();
    public GameObject fruitPrefab;
    public Transform trail;

    public static int score = 0;
    private float lastSpawn; 
    private float deltaSpawn = 1.0f;
    private const float REQUIRED_SLICEFORCE = 10.0f;
    private Vector3 lastMousePos;
    private Collider2D[] fruitCols;

    private void Start(){
        fruitCols = new Collider2D[0];
    }

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
            
            if((Input.mousePosition - lastMousePos).sqrMagnitude > REQUIRED_SLICEFORCE){ 
                foreach(Collider2D c2 in thisFramesFruit){
                    for(int i = 0; i < fruitCols.Length; i++){
                        if (c2 == fruitCols[i]){
                            c2.GetComponent<Fruit>().Slice();  
                        }
                    }
                }
            }
            lastMousePos = Input.mousePosition;
            fruitCols = thisFramesFruit;
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
