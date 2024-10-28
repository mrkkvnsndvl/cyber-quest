using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {
    [Header("Game Objects")]
    [SerializeField] private GameObject _joystickCanvas;
    [SerializeField] private GameObject _objectivesCanvas;
    [SerializeField] private GameObject _livesCanvas;
    [SerializeField] private GameObject _pauseMenuPanel;

    [Header("Scripts")]
    [SerializeField] private Player _player;

    [HideInInspector]
    public float _delayBeforeSceneLoad = 0.5f;

    public static bool _isPaused = false;

    void Start() {
        _pauseMenuPanel.SetActive(false);

        if (SceneManager.GetActiveScene().name == "How To Play") {
            Destroy(_objectivesCanvas);
            Destroy(_livesCanvas);
        }
    }

    public void Pause() {
        _pauseMenuPanel.SetActive(true);
        _joystickCanvas.SetActive(false);

        if (SceneManager.GetActiveScene().name != "How To Play") {
            _objectivesCanvas.SetActive(false);
            _livesCanvas.SetActive(false);
        }

        _player.DisableMovement();
        Time.timeScale = 0f;
        _isPaused = true;
    }

    public void Resume() {
        _pauseMenuPanel.SetActive(false);
        _joystickCanvas.SetActive(true);

        if (SceneManager.GetActiveScene().name != "How To Play") {
            _objectivesCanvas.SetActive(true);
            _livesCanvas.SetActive(true);
        }

        _player.EnableMovement();
        Time.timeScale = 1f;
        _isPaused = false;
    }

    public void Restart() {
        if (_isPaused) {
            Resume();
        }
        StartCoroutine(RestartSceneCoroutine());
    }

    public void MainMenu() {
        if (_isPaused) {
            Resume();
        }
        StartCoroutine(MainMenuCoroutine());
    }

    private IEnumerator RestartSceneCoroutine() {
        yield return new WaitForSeconds(_delayBeforeSceneLoad);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator MainMenuCoroutine() {
        yield return new WaitForSeconds(_delayBeforeSceneLoad);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
