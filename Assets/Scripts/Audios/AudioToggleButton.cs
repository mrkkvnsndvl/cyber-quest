using UnityEngine;
using UnityEngine.UI;

public class AudioToggleButton : MonoBehaviour {
    [SerializeField] private Sprite _muteIcon;
    [SerializeField] private Sprite _unmuteIcon;
    [SerializeField] private Button _button;
    private bool _isMuted = false;

    private void Start() {
        _isMuted = PlayerPrefs.GetInt("IsMuted", 0) == 1;
        UpdateAudio();
        UpdateIcon();

        _button.onClick.AddListener(ToggleMute);
    }

    private void ToggleMute() {
        _isMuted = !_isMuted;
        UpdateAudio();
        UpdateIcon();
        PlayerPrefs.SetInt("IsMuted", _isMuted ? 1 : 0);
    }

    private void UpdateAudio() {
        AudioListener.volume = _isMuted ? 0 : 1;
    }

    private void UpdateIcon() {
        _button.image.sprite = _isMuted ? _muteIcon : _unmuteIcon;
    }
}
