using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeComputerTutorial : MonoBehaviour {
    [Header("Game Objects")]
    [SerializeField] private GameObject _joystickCanvas;
    [SerializeField] private GameObject _pauseMenuCanvas;

    [Header("Scripts")]
    [SerializeField] private DialogueManager _dialogueManager;

    private bool _isdialogueEnd = false;

    private void Start() {
        gameObject.SetActive(false);
    }

    private void Update() {
        if (gameObject.activeSelf == true) {
            _joystickCanvas.SetActive(false);
            _pauseMenuCanvas.SetActive(false);
        }
    }

    public void OnclickCloseButton() {
        gameObject.SetActive(false);
        _joystickCanvas.SetActive(true);
        _pauseMenuCanvas.SetActive(true);
    }

    public void ShowHomeComputerCanvas() {
        _joystickCanvas.SetActive(false);
        _pauseMenuCanvas.SetActive(false);

        gameObject.SetActive(true);

        if (!_isdialogueEnd) {
            _isdialogueEnd = true;
            _dialogueManager.ComputerDialogueEnd();
        }
    }
}
