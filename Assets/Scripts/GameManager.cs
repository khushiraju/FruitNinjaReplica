using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private List<Fruit> fruits = new List<Fruit>();
    private List<Bomb> bombs = new List<Bomb>();
    public GameObject fruitPrefab;
    public GameObject bombPrefab;
    public Transform trail;
    public static int score = 0;
    private float lastSpawn;
    private float lastSpawnBomb;
    private float deltaSpawn = 1.0f;
    private const float REQUIRED_SLICEFORCE = 10.0f;
    private Vector3 lastMousePos;
    private Collider2D[] fruitCols;
    private Collider2D[] bombCols;

    private void Start(){
        fruitCols = new Collider2D[0];
        bombCols = new Collider2D[0];
    }

    private void Update(){
            if ((Time.time - lastSpawn > deltaSpawn) && (Timer.timerIsRunning == true) && (Bomb.sliceNum < 3)){
                Fruit f = GetFruit();
                Bomb b = GetBomb();
                float randomX = Random.Range(-1.65f, 1.65f);
                float randomX2 = Random.Range(-1.70f, 1.70f);
                f.LaunchFruit(Random.Range(1.85f,2.75f), randomX,  -randomX);
                if(Timer.timeRemaining % 10 > 0 && Timer.timeRemaining % 10 < 1){
                    b.LaunchBomb(Random.Range(1.85f,2.75f), randomX2,  -randomX2);  
                }
                lastSpawn = Time.time;
            }

            if(Input.GetMouseButton(0)){
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pos.z = -1;
                trail.position = pos;

                Collider2D[] thisFramesFruit = Physics2D.OverlapPointAll(new Vector2(pos.x, pos.y), LayerMask.GetMask("Fruit"));
                Collider2D[] thisFramesBomb = Physics2D.OverlapPointAll(new Vector2(pos.x, pos.y), LayerMask.GetMask("Bomb"));

                if((Input.mousePosition - lastMousePos).sqrMagnitude > REQUIRED_SLICEFORCE){ 
                    foreach(Collider2D c2 in thisFramesFruit){
                        for(int i = 0; i < fruitCols.Length; i++){
                            if (c2 == fruitCols[i]){
                                c2.GetComponent<Fruit>().Slice();  
                            }
                        }
                    }
                    foreach(Collider2D b2 in thisFramesBomb){
                        for(int i = 0; i < bombCols.Length; i++){
                            if (b2 == bombCols[i]){
                                b2.GetComponent<Bomb>().Slice();  
                            }
                        }
                    }
                }

                lastMousePos = Input.mousePosition;
                fruitCols = thisFramesFruit;
                bombCols = thisFramesBomb;
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

    private Bomb GetBomb(){
        Bomb b = bombs.Find(x => !x.isActive);

        if (b == null){
            b = Instantiate(bombPrefab).GetComponent<Bomb>();
            bombs.Add(b);
        }
        return b;
    }

}
