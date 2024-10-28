using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour {
    [Header("Game Objects")]
    [SerializeField] private GameObject _joystickCanvas;
    [SerializeField] private GameObject _pauseMenuCanvas;
    [SerializeField] private GameObject _objectivesCanvas;
    [SerializeField] private GameObject _pauseMenuPanel;
    [SerializeField] private GameObject _homeComputerPanel;
    [SerializeField] private GameObject _objectivesPanel;

    [Header("Settings")]
    private bool _isPlayerClose = false;
    private AudioManager _audioManager;

    private void Start() {
        _homeComputerPanel.SetActive(false);

        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void Update() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && _pauseMenuPanel.activeSelf == false && _objectivesPanel.activeSelf == false) {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                CheckTouchOnObject(touchPosition);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            _isPlayerClose = true;
        }
    }

    public void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            _isPlayerClose = false;
        }
    }

    public void CheckTouchOnObject(Vector2 inputPosition) {
        if (_isPlayerClose) {
            RaycastHit2D hit = Physics2D.Raycast(inputPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject) {
                if (_homeComputerPanel.activeSelf == false) {
                    _audioManager.PlayComputerSFX();
                }

                _joystickCanvas.SetActive(false);
                _pauseMenuCanvas.SetActive(false);
                _objectivesCanvas.SetActive(false);
                _homeComputerPanel.SetActive(true);
            }
        }
    }

    public void OnclickCloseButton() {
        _homeComputerPanel.SetActive(false);
        _joystickCanvas.SetActive(true);
        _pauseMenuCanvas.SetActive(true);
        _objectivesCanvas.SetActive(true);
    }
}