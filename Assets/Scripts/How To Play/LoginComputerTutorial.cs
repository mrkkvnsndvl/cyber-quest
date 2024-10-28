using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginComputerTutorial : MonoBehaviour {
    [Header("Game Objects")]
    [SerializeField] private GameObject _loginComputerCanvas;

    [Header("Input Fields")]
    [SerializeField] private TMP_InputField _passwordInputField;

    [Header("Buttons")]
    [SerializeField] private Button _arrowRightIcon;
    [SerializeField] private Button _OkButton;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI _passwordIncorrectText;

    [Header("Scripts")]
    [SerializeField] private HomeComputerTutorial _homeComputerTutorial;

    private void Start() {
        _passwordIncorrectText.gameObject.SetActive(false);
        _OkButton.gameObject.SetActive(false);
    }

    public void CheckPassword() {
        if (_passwordInputField.text == "") {
            return;
        }
        else if (_passwordInputField.text == "admin123") {
            _loginComputerCanvas.SetActive(false);
            _homeComputerTutorial.ShowHomeComputerCanvas();
            _passwordInputField.text = "";
        }
        else {
            _passwordInputField.gameObject.SetActive(false);
            _arrowRightIcon.gameObject.SetActive(false);
            _passwordIncorrectText.gameObject.SetActive(true);
            _OkButton.gameObject.SetActive(true);
        }
    }

    public void OnclickOkButton() {
        _passwordInputField.text = "";
        _passwordIncorrectText.gameObject.SetActive(false);
        _OkButton.gameObject.SetActive(false);
        _passwordInputField.gameObject.SetActive(true);
        _arrowRightIcon.gameObject.SetActive(true);
    }

    public void OnclickCloseButton() {
        _loginComputerCanvas.SetActive(false);
    }
}
