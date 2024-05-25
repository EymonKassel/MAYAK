using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpener : MonoBehaviour {
    [SerializeField] private GameObject _gate;

    private void OnTriggerEnter2D(Collider2D collision) {
        if ( collision.gameObject.tag.Contains("Trace") ) {
            Debug.Log("Hit");
            Destroy(_gate);
            Destroy(gameObject);
        }
    }
}
