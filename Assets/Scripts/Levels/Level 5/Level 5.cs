using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Level5 : MonoBehaviour {
    [Header("Game Objects")]
    [SerializeField] private GameObject _optionsMenuCanvas;
    [SerializeField] private GameObject _homeComputerCanvas;
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _homeComputerPanel;

    [Header("Input Fields")]
    [SerializeField] private TMP_InputField _answerInputField;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI _incorrectText;

    [Header("Lives UI (Images)")]
    [SerializeField] private Image[] _livesImages;

    [Header("Buttons")]
    [SerializeField] private Button _tryAgainButton;
    [SerializeField] private Button _arrowRightButton;

    [Header("Settings")]
    [SerializeField] private int _lives = 3;

    private void Start() {
        _optionsMenuCanvas.SetActive(false);
        _gameOverCanvas.SetActive(false);
        _incorrectText.gameObject.SetActive(false);
        _tryAgainButton.gameObject.SetActive(false);

        UpdateLivesUI();
    }

    private void UpdateLivesUI() {
        for (int i = 0; i < _livesImages.Length; i++) {
            if (i < _lives) {
                _livesImages[i].enabled = true;
            }
            else {
                _livesImages[i].enabled = false;
            }
        }
    }

    public void OnclickArrowRightButton() {
        if (_answerInputField.text == "") {
            return;
        }
        else if (_answerInputField.text == "JUMP THE DOG") {
            _homeComputerCanvas.SetActive(false);
            _optionsMenuCanvas.SetActive(true);
            _answerInputField.text = "";

            UnlockNewLevel();
        }
        else {
            _lives--;

            UpdateLivesUI();

            if (_lives <= 0) {
                GameOver();
            }
            else {
                _answerInputField.text = "";
                _answerInputField.gameObject.SetActive(false);
                _arrowRightButton.gameObject.SetActive(false);
                _incorrectText.gameObject.SetActive(true);
                _tryAgainButton.gameObject.SetActive(true);
            }
        }
    }

    public void OnclickTryAgainButton() {
        _incorrectText.gameObject.SetActive(false);
        _tryAgainButton.gameObject.SetActive(false);
        _answerInputField.gameObject.SetActive(true);
        _arrowRightButton.gameObject.SetActive(true);
        _answerInputField.text = "";
    }

    private void GameOver() {
        _homeComputerCanvas.SetActive(false);
        _gameOverCanvas.SetActive(true);
    }

    void UnlockNewLevel() {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex")) {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
