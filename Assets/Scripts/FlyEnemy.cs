using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Enemies //INHERITANCE
{
    override protected void OnTriggerEnter2D(Collider2D other) { //POLYMORPHISM
            int posY = Random.Range(0,8);
            gameObject.transform.position= new Vector3(gameObject.transform.position.x, posY, gameObject.transform.position.z);
    }
}
