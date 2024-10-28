using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {
    [Header("Game Objects")]
    [SerializeField] private GameObject _livesCanvas;
    [SerializeField] private GameObject _ObjectivesCanvas;
    [SerializeField] private GameObject _ChallengeCanvas;

    [Header("Buttons")]
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _restartButton;

    private void Update() {
        if (gameObject.activeSelf == true) {
            _livesCanvas.SetActive(false);
            _ObjectivesCanvas.SetActive(false);
            _ChallengeCanvas.SetActive(false);
        }
        else {
            _livesCanvas.SetActive(true);
            _ObjectivesCanvas.SetActive(true);
            _ChallengeCanvas.SetActive(true);
        }
    }

    public void OnclickMainMenuButton() {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnclickRestartButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
