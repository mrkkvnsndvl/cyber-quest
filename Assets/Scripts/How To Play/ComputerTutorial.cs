using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTutorial : MonoBehaviour {
    [Header("Game Objects")]
    [SerializeField] GameObject _loginComputerCanvas;
    [SerializeField] GameObject _joystickCanvas;
    [SerializeField] GameObject _pauseMenuCanvas;
    [SerializeField] private GameObject _pauseMenuPanel;

    [Header("Scripts")]
    [SerializeField] private FindVulnerableTutorial _findVulnerableTutorial;

    [HideInInspector]
    public bool _isPlayerClose = false;
    private AudioManager _audioManager;

    private void Start() {
        _loginComputerCanvas.SetActive(false);

        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void Update() {
        if (_findVulnerableTutorial._findVulnerableTutorialCompleted) {
            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began && _pauseMenuPanel.activeSelf == false) {
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    CheckTouchOnObject(touchPosition);
                }
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
                if (_loginComputerCanvas.activeSelf == false) {
                    _audioManager.PlayComputerSFX();
                }

                _joystickCanvas.SetActive(false);
                _pauseMenuCanvas.SetActive(false);
                _loginComputerCanvas.SetActive(true);
            }
        }
    }

    public void OnclickCloseButton() {
        _loginComputerCanvas.SetActive(false);
        _joystickCanvas.SetActive(true);
        _pauseMenuCanvas.SetActive(true);
    }
}
