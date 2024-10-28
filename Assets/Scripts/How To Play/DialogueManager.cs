using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    [Header("Game Objects")]
    [SerializeField] private GameObject _joystickCanvas;
    [SerializeField] private GameObject _dialogueCanvas;
    [SerializeField] private GameObject _pauseMenuCanvas;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI _dialogueText;

    [Header("Buttons")]
    [SerializeField] private Button[] _choiceButtons;

    [Header("Scriptable Objects")]
    [SerializeField] private DialogueSO _dialogueSO;

    [Header("Scripts")]
    [SerializeField] private Player _player;

    private float _typeEffectSpeed = 0.05f;
    private Coroutine _typingCoroutine;
    private bool _isTyping = false;
    private int _currentDialogueIndex = 0;

    private void Start() {
        _pauseMenuCanvas.SetActive(false);
        _joystickCanvas.SetActive(false);
        _dialogueCanvas.SetActive(true);

        StartDialogue(_currentDialogueIndex);

        _choiceButtons[0].onClick.AddListener(OnChoiceButton0Clicked);
        _choiceButtons[1].onClick.AddListener(OnChoiceButton1Clicked);
    }

    private void Update() {
        DetectDoubleTap();
        DetectSingleTap();
    }

    public void StartDialogue(int dialogueIndex) {
        if (_typingCoroutine != null) {
            StopCoroutine(_typingCoroutine);
        }

        HideChoiceButtons();

        _currentDialogueIndex = dialogueIndex;
        _typingCoroutine = StartCoroutine(TypeEffect(_dialogueSO._dialogues[_currentDialogueIndex]));
    }

    public IEnumerator TypeEffect(string dialogue) {
        _dialogueText.text = "";
        _isTyping = true;

        foreach (char letter in dialogue.ToCharArray()) {
            _dialogueText.text += letter;
            yield return new WaitForSeconds(_typeEffectSpeed);
        }

        _isTyping = false;
        OnTypingComplete();
    }

    public void OnTypingComplete() {
        ShowChoiceButtons();
    }

    public void DetectDoubleTap() {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) {
            if (Input.GetTouch(0).tapCount == 2) {
                SkipTypeEffect();
            }
        }
    }

    public void SkipTypeEffect() {
        if (_isTyping) {
            if (_typingCoroutine != null) {
                StopCoroutine(_typingCoroutine);
            }
            _dialogueText.text = _dialogueSO._dialogues[_currentDialogueIndex];
            _isTyping = false;
            OnTypingComplete();
        }
    }

    public void HideChoiceButtons() {
        for (int i = 0; i < _choiceButtons.Length; i++) {
            _choiceButtons[i].gameObject.SetActive(false);
        }
    }

    public void ShowChoiceButtons() {
        if (_currentDialogueIndex == 0) {
            for (int i = 0; i < _choiceButtons.Length; i++) {
                _choiceButtons[i].gameObject.SetActive(true);
            }
        }
        else {
            HideChoiceButtons();
        }
    }

    public void OnChoiceButton0Clicked() {
        StartDialogue(1);
    }

    public void OnChoiceButton1Clicked() {
        StartDialogue(2);
    }

    public void DetectSingleTap() {
        if (!_isTyping && Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended) {
            if (Input.GetTouch(0).tapCount == 1) {
                if (_currentDialogueIndex == 1) {
                    StartDialogue(3);
                }
                else if (_currentDialogueIndex < _dialogueSO._dialogues.Count - 1) {
                    if (_choiceButtons[0].gameObject.activeSelf || _choiceButtons[1].gameObject.activeSelf) {
                        return;
                    }
                    StartDialogue(_currentDialogueIndex + 1);
                }

                ConditionDialogue();
            }
        }
    }

    public void ConditionDialogue() {
        if (_currentDialogueIndex == 4) {
            MovementTutorialDialogueStart();
        }
        else if (_currentDialogueIndex == 7) {
            FindVulnerableDialogueStart();
        }
        else if (_currentDialogueIndex == 8) {
            ComputerDialogueStart();
        }
    }

    public void MovementTutorialDialogueStart() {
        _pauseMenuCanvas.SetActive(true);
        _joystickCanvas.SetActive(true);
        _dialogueCanvas.SetActive(false);
    }

    public void MovementTutorialDialogueEnd() {
        _pauseMenuCanvas.SetActive(false);
        _joystickCanvas.SetActive(false);
        _dialogueCanvas.SetActive(true);
        StartDialogue(4);
    }

    public void FindVulnerableDialogueStart() {
        _pauseMenuCanvas.SetActive(true);
        _joystickCanvas.SetActive(true);
        _dialogueCanvas.SetActive(false);
        _player.EnableMovement();
    }

    public void FindVulnerableDialogueEnd() {
        _pauseMenuCanvas.SetActive(false);
        _joystickCanvas.SetActive(false);
        _dialogueCanvas.SetActive(true);
        StartDialogue(7);
    }

    public void ComputerDialogueStart() {
        _pauseMenuCanvas.SetActive(true);
        _joystickCanvas.SetActive(true);
        _dialogueCanvas.SetActive(false);
    }

    public void ComputerDialogueEnd() {
        _pauseMenuCanvas.SetActive(false);
        _joystickCanvas.SetActive(false);
        _dialogueCanvas.SetActive(true);
        StartDialogue(8);
    }
}
