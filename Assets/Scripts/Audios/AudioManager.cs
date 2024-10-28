using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {
    [Header("Audio Sources")]
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _sfx;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip _backgroundMusic;
    [SerializeField] private AudioClip _buttonSFX;
    [SerializeField] private AudioClip _bookSFX;
    [SerializeField] private AudioClip _drawerSFX;
    [SerializeField] private AudioClip _whiteBoardSFX;
    [SerializeField] private AudioClip _computerSFX;

    private void Start() {
        PlayBackgroundMusic();
    }

    private void Update() {
        if (SceneManager.GetActiveScene().name == "How To Play" || SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2" || SceneManager.GetActiveScene().name == "Level 3" || SceneManager.GetActiveScene().name == "Level 4" || SceneManager.GetActiveScene().name == "Level 5") {
            StopBackgroundMusic();
        }
    }

    public void PlayButtonSFX() {
        _sfx.clip = _buttonSFX;
        if (_buttonSFX != null) {
            _sfx.PlayOneShot(_buttonSFX);
        }
    }

    public void PlayBookSFX() {
        _sfx.clip = _bookSFX;
        if (_bookSFX != null) {
            _sfx.PlayOneShot(_bookSFX);
        }
    }

    public void PlayDrawerSFX() {
        _sfx.clip = _drawerSFX;
        if (_drawerSFX != null) {
            _sfx.PlayOneShot(_drawerSFX);
        }
    }

    public void PlayWhiteBoardSFX() {
        _sfx.clip = _whiteBoardSFX;
        if (_whiteBoardSFX != null) {
            _sfx.PlayOneShot(_whiteBoardSFX);
        }
    }

    public void PlayComputerSFX() {
        _sfx.clip = _computerSFX;
        if (_computerSFX != null) {
            _sfx.PlayOneShot(_computerSFX);
        }
    }

    public void PlayBackgroundMusic() {
        _music.clip = _backgroundMusic;
        if (_backgroundMusic != null) {
            _music.loop = true;
            _music.Play();
        }
    }

    public void StopBackgroundMusic() {
        _music.clip = _backgroundMusic;
        _music.Stop();
    }
}
