using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public bool isActive{set; get;}

    private float velocity;
    private float speed;

    public void LaunchFruit(float velocity, float xSpeed, float xStart){
        isActive = true;
        this.velocity = velocity; 
        speed = xSpeed; 

        transform.position = new Vector3(xStart, 0, 0);
    }
}
