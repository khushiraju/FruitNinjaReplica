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
    public Sprite pomegranate;
    public Sprite sliced_pomegranate;
    public Sprite dragonfruit;
    public Sprite sliced_dragonfruit;
    public Sprite kiwi;
    public Sprite sliced_kiwi;
    public AudioClip sliceSound;
    public string fruitName;

    private void Start(){
        LaunchFruit(2.0f, 2, -1);
        isSliced = false;
        GetComponent<AudioSource> ().playOnAwake = false;
        GetComponent<AudioSource> ().clip = sliceSound;
        
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
        float randomNumber = Random.Range(1, 5);

        if ((transform.position.y < -1)){
            isActive = false; 
            isSliced = false;
            GetComponent<SpriteRenderer>().sprite = strawberry;
            fruitName = "strawberry";
            if (randomNumber == 1){
                GetComponent<SpriteRenderer>().sprite = strawberry; 
                fruitName = "strawberry";
            }
            else if (randomNumber == 2){
                GetComponent<SpriteRenderer>().sprite = pomegranate; 
                fruitName = "pomegranate";
            }
            else if (randomNumber == 3){
                GetComponent<SpriteRenderer>().sprite = dragonfruit; 
                fruitName = "dragonfruit";
            }  
            else if (randomNumber == 4){
                GetComponent<SpriteRenderer>().sprite = kiwi; 
                fruitName = "kiwi";
            }   
        }
    }

    public void Slice(){
        if(isSliced == false){
            if(verticalVelocity < 0.5f){
                verticalVelocity = 0.5f;
            }
            speed = speed * 0.5f;
            GetComponent<SpriteRenderer>().sprite = sliced_strawberry;
            if (fruitName.Equals("strawberry")){
                GetComponent<SpriteRenderer>().sprite = sliced_strawberry;
            }
            else if (fruitName.Equals("pomegranate")){
                GetComponent<SpriteRenderer>().sprite = sliced_pomegranate;
            }
            else if (fruitName.Equals("dragonfruit")){
                GetComponent<SpriteRenderer>().sprite = sliced_dragonfruit;
            }
            else if (fruitName.Equals("kiwi")){
                GetComponent<SpriteRenderer>().sprite = sliced_kiwi;
            }
            GameManager.score++;
            GetComponent<AudioSource> ().Play ();
        }
        isSliced = true;
    }
}
