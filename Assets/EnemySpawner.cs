using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawnPoint;

    private void OnTriggerEnter2D(Collider2D collision) {
        if ( collision.gameObject.tag.Contains("Player") ) {
            Debug.Log("Spawn enemy");
            Instantiate(_enemy, _spawnPoint);
            gameObject.SetActive(false);
        }
    }
}
