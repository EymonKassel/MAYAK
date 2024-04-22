//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyEntity : MonoBehaviour {
//    public Transform Player;
//    public GameObject EnemyBullet;

//    [SerializeField] private int _maxHealth = 3;
//    [SerializeField] private int _currentHealth;

//    private void Awake() {
//        _currentHealth = _maxHealth;
//    }
//    private void Update() {
//        if ( _currentHealth <= 0 ) Kill();
//    }
//    public void Kill() {
//        Destroy(gameObject);
//    }
//    public void Hit() {
//        _currentHealth--;
//    }
//    private void OnTriggerEnter2D(Collider2D collision) {
//        if ( collision.gameObject.tag == "Trace" ) {
//            Debug.Log("Hit");
//            Hit();
//        }
//    }
//}
