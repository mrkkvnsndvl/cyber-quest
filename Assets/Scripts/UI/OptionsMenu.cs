using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {
    [Header("Game Objects")]
    [SerializeField] private GameObject _livesCanvas;
    [SerializeField] private GameObject _ObjectivesCanvas;
    [SerializeField] private GameObject _ChallengeCanvas;

    [Header("Buttons")]
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _proceedButton;

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

        // if last level proceed button will disable. Use interactalbe property
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1) {
            _proceedButton.interactable = false;
        }
    }


    public void OnclickMainMenuButton() {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnclickRestartButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnclickProceedButton() {
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(nextLevelIndex);
        }
    }
}
