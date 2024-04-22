using UnityEngine.SceneManagement;

public class SceneLoader : ManagerEntity {
    private void Awake() => InitiliziateManager();

    public void LoadSpecificScene(string sceneName) => SceneManager.LoadScene(sceneName);

    public void LoadNextScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    public void LoadPreviousScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    public void ReloadCurrentScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

