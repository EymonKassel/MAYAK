using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private int _currentHealth;
    private void Awake() {
        _currentHealth = _maxHealth;
    }
}
