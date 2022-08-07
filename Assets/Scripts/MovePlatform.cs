using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    private float speed = 10.0f;//0.0f;
    private float limitLeft = -30.0f;

    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveAndDestroyPlatform(); //ABSTRACTION
    }

    void MoveAndDestroyPlatform(){
        if(gameManager.isInProgress) transform.Translate(Vector2.left * speed * Time.deltaTime);
        if(transform.position.x < limitLeft){
            Destroy(gameObject);
        }
    }
}
