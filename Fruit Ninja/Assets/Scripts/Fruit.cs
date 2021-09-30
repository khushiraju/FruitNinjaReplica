using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public bool isActive{set; get;}
    private const float GRAVITY = 2.0f;
    private float verticalVelocity;
    private float speed;

    public void LaunchFruit(float verticalVelocity, float xSpeed, float xStart){
        isActive = true;
        this.velocity = velocity; 
        speed = xSpeed; 

        transform.position = new Vector3(xStart, 0, 0);
    }

    private void Update() {
        velocity -= GRAVITY * Time.deltaTime;
    }
}
