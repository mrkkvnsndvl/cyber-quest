using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    [Header("Game Objects")]
    [SerializeField] private GameObject _levelMenuCanvas;

    [Header("Buttons")]
    [SerializeField] private Button[] _mainMenuButtons;

    private void Start() {
        _levelMenuCanvas.SetActive(false);

    }

    public void StartGame() {
        gameObject.SetActive(false);
        _levelMenuCanvas.SetActive(true);
    }

    public void HowToPlay() {
        StartCoroutine(LoadSceneCoroutine("How To Play"));
    }

    public void QuitGame() {
        Application.Quit();
    }

    private IEnumerator LoadSceneCoroutine(string sceneName) {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
