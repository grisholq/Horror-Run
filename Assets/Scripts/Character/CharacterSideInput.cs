using UnityEngine;

public class CharacterSideInput : MonoBehaviour
{
    [SerializeField] private float _touchInputSensetivity;

    public float SideInput { get; set; }

    private Vector2 _touchInputStart;

    private void Update()
    {
        if (HasKeyboardInput()) SideInput = GetSideMovementFormKeyboard();
        else if (HasTouchInput())
        {
            TryUpdateStartPosition();
            SideInput = GetSideMovementDirectionFromTouch();
        } 
        else SideInput = 0;
    }

    private bool HasTouchInput()
    {
        return Input.touchCount != 0 && Time.timeScale > 0;
    }

    private bool HasKeyboardInput()
    {
        return Input.GetAxis("Horizontal") != 0;
    }

    private void TryUpdateStartPosition()
    {
        Touch touch = Input.GetTouch(0);

        if(touch.phase == TouchPhase.Began)
        {
            _touchInputStart = touch.position;
        }
    }

    private float GetSideMovementDirectionFromTouch()
    {
        Vector2 input = GetDeltaTouchInput();
        input *= _touchInputSensetivity;
        return Mathf.Clamp(input.x, -1, 1);
    }

    private Vector2 GetDeltaTouchInput()
    {
        Vector2 touchPosition = Input.GetTouch(0).position;
        return (touchPosition - _touchInputStart);
    }

    private float GetSideMovementFormKeyboard()
    {
        return Input.GetAxis("Horizontal");
    }
}