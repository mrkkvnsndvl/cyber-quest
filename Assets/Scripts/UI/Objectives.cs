using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour {
    [Header("Game Objects")]
    [SerializeField] private GameObject _objectivesPanel;
    [SerializeField] private GameObject _challengePanel;
    [SerializeField] private GameObject _homeComputerPanel;
    [SerializeField] private GameObject _pauseMenuPanel;
    [SerializeField] private GameObject _joystickCanvas;
    [SerializeField] private GameObject _pauseMenuCanvas;

    [Header("Scripts")]
    [SerializeField] private Player _player;

    private void Start() {
        _objectivesPanel.SetActive(false);
    }

    public void OnclickObjectivesIcon() {
        if (_challengePanel.activeSelf == false && _homeComputerPanel.activeSelf == false && _pauseMenuPanel.activeSelf == false) {
            _objectivesPanel.SetActive(true);
            _joystickCanvas.SetActive(false);
            _pauseMenuCanvas.SetActive(false);
            _player.DisableMovement();
        }
    }

    public void OnclickCloseButton() {
        _objectivesPanel.SetActive(false);
        _joystickCanvas.SetActive(true);
        _pauseMenuCanvas.SetActive(true);
        _player.EnableMovement();
    }
}
