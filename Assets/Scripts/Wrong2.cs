using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wrong2 : MonoBehaviour
{
    public static Image wrong1;
    public static Image wrong2;
    public static Image wrong3;
    public Sprite sliced_bomb;

    void Start()
    {
        //wrong1 = GetComponent<Image>();
        // wrong2 = GetComponent<Image>();
        // wrong3 = GetComponent<Image>();
        GetComponent<Image>();
        
    }


    void Update()
    {
        if(Bomb.sliceNum == 2){
            GetComponent<Image>().sprite = sliced_bomb;
            //wrong1.sprite = sliced_bomb;
        }
        // else if(Bomb.sliceNum == 2){
        //     wrong2.GetComponent<Image>().sprite = sliced_bomb;
        // }
        // else if(Bomb.sliceNum == 3){
        //     wrong3.GetComponent<Image>().sprite = sliced_bomb;
        // }
        
        
    }
}
