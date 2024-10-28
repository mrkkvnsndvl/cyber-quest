using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler {
    [Header("Images")]
    [SerializeField] private Image _joystickImage;
    [SerializeField] private Image _joystickHandleImage;

    private Vector2 _inputVector;
    private Vector2 _pointerDownPosition;

    void Start() {
        ResetHandle();
    }

    public void OnPointerDown(PointerEventData eventData) {
        _pointerDownPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData) {
        var position = eventData.position;
        var size = _joystickImage.rectTransform.sizeDelta;
        var delta = (position - _pointerDownPosition) / size * 2;
        _inputVector = delta.magnitude > 1f ? delta.normalized : delta;
        _joystickHandleImage.rectTransform.anchoredPosition = _inputVector * (size / 2);
    }

    public void OnPointerUp(PointerEventData eventData) {
        ResetHandle();
    }

    public float Horizontal {
        get { return _inputVector.x; }
    }

    public float Vertical {
        get { return _inputVector.y; }
    }

    public void ResetHandle() {
        _inputVector = Vector2.zero;
        _joystickHandleImage.rectTransform.anchoredPosition = Vector2.zero;
    }
}

