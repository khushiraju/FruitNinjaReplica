using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<Fruit> fruits = new List<Fruit>();
    public GameObject fruitPrefab;
    private Fruit GetFruit(){
        Fruit f = fruits.Find(x => !x.isActive);

        if (f == null){
            f = Instantiate(fruitPrefab).GetComponent<Fruit>();
            fruits.Add(f);
        }
        return f;
    }
}
