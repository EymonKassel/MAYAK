using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyEntity : MonoBehaviour {
    public Transform Player;

    [SerializeField] private int _maxHealth = 1;
    public int CurrentHealth;

    private void Awake() {
        CurrentHealth = _maxHealth;
    }
    private void Update() {
        if ( CurrentHealth <= 0 ) Kill();
    }

    public void Kill() {
        Destroy(gameObject);
    }
    public void Hit() {
        CurrentHealth--;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if ( collision.gameObject.tag.Contains("Trace") ) {
            Debug.Log("Hit");
            Hit();
        }
    }
}
