using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public bool isActive{set; get;}
    private const float GRAVITY = 2.0f;
    private float verticalVelocity;
    private float speed;
    public static float sliceNum = 0;
    private bool isSliced{set; get;}
    public Sprite bomb;
    public Sprite sliced_bomb;
    public AudioClip sliceSound;
    
    void Start()
    {
        LaunchBomb(0f, 6, -7);
        isSliced = false;
        GetComponent<AudioSource> ().playOnAwake = false;
        GetComponent<AudioSource> ().clip = sliceSound;
    }

    public void LaunchBomb(float verticalVelocity, float xSpeed, float xStart){
        isActive = true;
        speed = xSpeed; 
        this.verticalVelocity = verticalVelocity; 
        transform.position = new Vector3(xStart, 0, 0);     
    }

    void Update()
    {
        if(!isActive){
            return;
        }

        verticalVelocity -= GRAVITY * Time.deltaTime;
        transform.position += new Vector3(speed, verticalVelocity, 0) * Time.deltaTime;

        if (transform.position.y < -1){
            isActive = false; 
            isSliced = false;
            GetComponent<SpriteRenderer>().sprite = bomb;     
        }
    }

    public void Slice(){
        if(isSliced == false){
            if(verticalVelocity < 0.5f){
                verticalVelocity = 0.5f;
            }
            speed = speed * 0.5f;
            GetComponent<SpriteRenderer>().sprite = sliced_bomb;
            GetComponent<AudioSource> ().Play ();
            sliceNum++;
        }
        isSliced = true;
    }

}
