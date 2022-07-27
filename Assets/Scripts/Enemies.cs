using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemies : MonoBehaviour
{
[SerializeField] private int _speed;
Enemy enemy = new Enemy(); // ENCAPSULATION

private SpriteRenderer _renderer;
private int dir = 1;

protected virtual void Start() {
    _renderer = GetComponent<SpriteRenderer>();
    enemy.RunSpeed = _speed;
}

protected virtual void Update() {
    Move(dir);
}

private void Move(int dir){
    transform.Translate(Vector2.left * enemy.RunSpeed * Time.deltaTime * dir);
}

protected virtual void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.CompareTag("LimitPlatform")){
        dir *= -1;
        _renderer.flipX = !_renderer.flipX;
    }
}

}

// ENCAPSULATION
public class Enemy { 
    private int _runSpeed;
    public int RunSpeed{
    get{ return _runSpeed; }
    set{ 
        _runSpeed = value;
        if(_runSpeed < 1){
            _runSpeed = Random.Range(0,8);;
        }
        }
    }
}