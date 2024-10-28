using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindVulnerableTutorial : MonoBehaviour {
    [Header("Game Objects")]
    [SerializeField] private GameObject _challengeCanvas;
    [SerializeField] private GameObject _joystickCanvas;
    [SerializeField] private GameObject _pauseMenuCanvas;
    [SerializeField] private GameObject _pauseMenuPanel;

    [Header("Scripts")]
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private MovementTutorial _movementTutorial;

    [HideInInspector]
    public bool _isPlayerClose = false;
    [HideInInspector]
    public bool _findVulnerableTutorialTriggered = false;
    [HideInInspector]
    public bool _findVulnerableTutorialCompleted = false;

    private void Start() {
        _challengeCanvas.SetActive(false);
    }

    private void Update() {
        if (_movementTutorial._movementTutorialCompleted) {
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
                _joystickCanvas.SetActive(false);
                _pauseMenuCanvas.SetActive(false);
                _challengeCanvas.SetActive(true);
            }
        }
    }

    public void OnclickClosePanel() {
        _challengeCanvas.SetActive(false);
        _findVulnerableTutorialCompleted = true;

        if (!_findVulnerableTutorialTriggered) {
            _dialogueManager.FindVulnerableDialogueEnd();
            _findVulnerableTutorialTriggered = true;
        }
    }
}
