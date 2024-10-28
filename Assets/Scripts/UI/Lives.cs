using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {
    [Header("Game Objects")]
    [SerializeField] private GameObject _homeComputerPanel;
    [SerializeField] private GameObject _objectivesPanel;
    [SerializeField] private GameObject _challengePanel;

    [Header("Images")]
    [SerializeField] private Image[] _livesImages;

    void Update() {
        UpdateLivesColor();
    }

    public void UpdateLivesColor() {
        if (_homeComputerPanel.activeSelf == true || _objectivesPanel.activeSelf == true || _challengePanel.activeSelf == true) {
            _livesImages[0].color = Color.black;
            _livesImages[1].color = Color.black;
            _livesImages[2].color = Color.black;
        }
        else {
            _livesImages[0].color = Color.white;
            _livesImages[1].color = Color.white;
            _livesImages[2].color = Color.white;
        }
    }
}
