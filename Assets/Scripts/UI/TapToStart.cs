using System.Collections;
using UnityEngine;
using TMPro;

public class TapToStart : MonoBehaviour {
    [Header("Game Objects")]
    [SerializeField] private GameObject _mainMenuCanvas;
    [SerializeField] private GameObject _levelMenuCanvas;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI _tapToStartText;

    [Header("Settings")]
    [SerializeField] private float _blinkSpeed = 2f;

    private Coroutine _blinkCoroutine;

    private void Start() {
        if (PlayerPrefs.GetInt("AlreadyStarted", 0) == 1) {
            _mainMenuCanvas.SetActive(true);
            _levelMenuCanvas.SetActive(false);
            gameObject.SetActive(false);
        }
        else {
            _mainMenuCanvas.SetActive(false);
            _levelMenuCanvas.SetActive(false);
            gameObject.SetActive(true);
            StartBlinking();
        }
    }

    public void BlinkEffectText() {
        if (_blinkCoroutine != null) {
            StopCoroutine(_blinkCoroutine);
        }

        _blinkCoroutine = StartCoroutine(BlinkText());
    }

    private IEnumerator BlinkText() {
        while (true) {
            yield return StartCoroutine(FadeTextToAlpha(1.0f));
            yield return StartCoroutine(FadeTextToAlpha(0.0f));
        }
    }

    private IEnumerator FadeTextToAlpha(float targetAlpha) {
        Color currentColor = _tapToStartText.color;
        float startAlpha = currentColor.a;
        float elapsedTime = 0f;

        while (elapsedTime < _blinkSpeed / 2f) {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / (_blinkSpeed / 2f));
            _tapToStartText.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
            yield return null;
        }

        _tapToStartText.color = new Color(currentColor.r, currentColor.g, currentColor.b, targetAlpha);
    }

    public void StartBlinking() {
        BlinkEffectText();
    }

    public void OnclickStart() {
        PlayerPrefs.SetInt("AlreadyStarted", 1);
        PlayerPrefs.Save();

        gameObject.SetActive(false);
        _mainMenuCanvas.SetActive(true);
    }
}
