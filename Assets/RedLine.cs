using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLine : MonoBehaviour {
    [SerializeField] private PlayerEntity _playerEntity;
    private void Awake() {
        _playerEntity = GameObject.Find("Player").GetComponent<PlayerEntity>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if ( collision.gameObject.tag.Contains("Player") ) {
            _playerEntity.CurrentHealthPoints--;
        }
    }
}
