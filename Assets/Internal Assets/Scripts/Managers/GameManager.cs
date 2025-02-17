using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : ManagerEntity {
    private bool _isLevel_1Loaded;
    private void Awake() => InitiliziateManager();
    private void Update() {
        if ( Input.GetKeyDown(KeyCode.F6) && !_isLevel_1Loaded ) {
            SceneManager.LoadScene("Level_1");
            _isLevel_1Loaded = true;
        }
        if (Input.GetKeyDown(KeyCode.F8)) {
            SceneManager.LoadScene("MainMenu");
            _isLevel_1Loaded = false;
        }
    }
}
