using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public bool isActive{set; get;}
    private const float GRAVITY = 2.0f;
    private float verticalVelocity;
    private float speed;
    private bool isSliced{set; get;}
    public Sprite bomb;
    public Sprite sliced_bomb;
    
    void Start()
    {
        LaunchBomb(3.0f, 1, -1);
        isSliced = false;
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
            if (GameManager.score > 0){
                GameManager.score--;
            }
        }
        isSliced = true;
    }

}
