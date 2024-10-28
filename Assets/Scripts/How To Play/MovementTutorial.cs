using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTutorial : MonoBehaviour {
    [Header("Particle System")]
    [SerializeField] private ParticleSystem _movementTutorialParticleSystem;

    [Header("Game Objects")]
    [SerializeField] private Player _player;

    [Header("Scripts")]
    [SerializeField] private DialogueManager _dialogueManager;

    [HideInInspector]
    public bool _movementTutorialCompleted = false;

    private void Start() {
        _movementTutorialParticleSystem.Play();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            _movementTutorialParticleSystem.Stop();
            _player.DisableMovement();
            StartCoroutine(ComplemteMovementTutorial());
            _dialogueManager.MovementTutorialDialogueEnd();
        }
    }

    private IEnumerator ComplemteMovementTutorial() {
        yield return new WaitForSeconds(2f);
        _movementTutorialCompleted = true;
        gameObject.SetActive(false);
    }
}

