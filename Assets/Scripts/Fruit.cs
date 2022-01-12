using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public bool isActive{set; get;}
    private const float GRAVITY = 2.0f;
    private float verticalVelocity;
    private float speed;
    private bool isSliced{set; get;}
    public Sprite strawberry;
    public Sprite sliced_strawberry;

    private void Start(){
        LaunchFruit(2.0f, 2,-1);
        isSliced = false;
        
    }
    public void LaunchFruit(float verticalVelocity, float xSpeed, float xStart){
        isActive = true;
        speed = xSpeed; 
        this.verticalVelocity = verticalVelocity; 
        transform.position = new Vector3(xStart, 0, 0);
    }

    private void Update() {
        if(!isActive){
            return;
        }

        verticalVelocity -= GRAVITY * Time.deltaTime;
        transform.position += new Vector3(speed, verticalVelocity, 0) * Time.deltaTime;

        if (transform.position.y < -1){
            isActive = false; 
            isSliced = false;
            GetComponent<SpriteRenderer>().sprite = strawberry;     
        }
    }

    public void Slice(){
        if(isSliced == false){
            if(verticalVelocity < 0.5f){
                verticalVelocity = 0.5f;
            }
            speed = speed * 0.5f;
            GetComponent<SpriteRenderer>().sprite = sliced_strawberry;
            GameManager.score++;
        }
        isSliced = true;
    }
}
