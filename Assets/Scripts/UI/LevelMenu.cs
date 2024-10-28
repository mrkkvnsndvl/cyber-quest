using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour {
    [Header("Buttons")]
    [SerializeField] private Button[] _levelButtons;

    private void Awake() {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for (int i = 0; i < _levelButtons.Length; i++) {
            _levelButtons[i].interactable = false;
        }

        for (int i = 0; i < unlockedLevel; i++) {
            _levelButtons[i].interactable = true;
        }
    }

    public void OpenLevel(int levelId) {
        string levelName = "Level " + levelId;
        SceneManager.LoadScene(levelName);
    }
}
