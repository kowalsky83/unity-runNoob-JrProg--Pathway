using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* public class Enemies : MonoBehaviour
{

} */



public class Enemies : MonoBehaviour
{
[SerializeField] protected float speed = 12.0f;
private SpriteRenderer _renderer;
private int dir = 1;

protected virtual void Start() {
    _renderer = GetComponent<SpriteRenderer>();
}

protected virtual void Update() {
    Move(dir);
}

private void Move(int dir){
    transform.Translate(Vector2.left * speed * Time.deltaTime * dir);
}

private void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.CompareTag("LimitPlatform")){
        dir *= -1;
        _renderer.flipX = !_renderer.flipX;
    }
}

}