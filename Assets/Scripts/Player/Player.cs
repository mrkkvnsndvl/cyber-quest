using UnityEngine;

public class Player : MonoBehaviour {
    [Header("Audios")]
    [SerializeField] private AudioSource _audioSource;

    [Header("Animations")]
    [SerializeField] private Animator _animator;

    [Header("Game Objects")]
    [SerializeField] private Joystick _joystickImage;

    private readonly float _moveSpeed = 5f;
    private readonly float _basePitch = 1.8f;
    private readonly float _pitchMultiplier = 0.2f;
    private Rigidbody2D _rigidbody2D;
    private bool _canMove = true;

    private void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (_canMove) {
            var horizontal = _joystickImage.Horizontal;
            var vertical = _joystickImage.Vertical;

            Movement(horizontal, vertical);
            Animations(horizontal, vertical);
            Footstep(horizontal, vertical);
        }
    }

    private void Movement(float horizontal, float vertical) {
        Vector2 movement = new Vector2(horizontal, vertical) * _moveSpeed;
        _rigidbody2D.velocity = movement;
    }

    private void Animations(float horizontal, float vertical) {
        bool isWalking = horizontal != 0 || vertical != 0;
        _animator.SetBool("IsWalking", isWalking);
        _animator.SetFloat("Horizontal", horizontal);
        _animator.SetFloat("Vertical", vertical);
    }

    private void Footstep(float horizontal, float vertical) {
        bool isMoving = horizontal != 0 || vertical != 0;

        if (isMoving) {
            if (!_audioSource.isPlaying) {
                _audioSource.pitch = _basePitch + (_pitchMultiplier * Mathf.Clamp01(new Vector2(horizontal, vertical).magnitude));
                _audioSource.Play();
            }
        }
        else {
            _audioSource.Stop();
        }
    }

    public void DisableMovement() {
        _canMove = false;
        _rigidbody2D.velocity = Vector2.zero;
        _animator.SetBool("IsWalking", false);
        _audioSource.Stop();
        _joystickImage.ResetHandle();
    }

    public void EnableMovement() {
        _audioSource.Play();
        _canMove = true;
    }
}
