using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour {
    public GameObject[] Enemies;
    public GameObject Player;

    private void Update() {
        if ( Player.transform.position.y > gameObject.transform.position.y ) {
            for ( int i = 0; i < Enemies.Length; i++ ) {
                Enemies[i].SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }
}
