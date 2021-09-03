using UnityEngine;

public class CharacterSideInput : MonoBehaviour
{
    public float SideInput { get; set; }

    private void Update()
    {
        if (HasKeyboardInput()) SideInput = GetSideMovementFormKeyboard();
        else if (HasTouchInput()) SideInput = GetSideMovementDirectionFromTouch();
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

    private float GetSideMovementDirectionFromTouch()
    {
        Vector2 input = GetNormalizedTouchInput();

        if (input.x <= 1) return -(1 - input.x);
        if (input.x > 1) return (input.x - 1);

        return 0;
    }

    private Vector2 GetNormalizedTouchInput()
    {
        Vector2 touchPosition = Input.GetTouch(0).position;
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 normalizedInput = new Vector2();

        normalizedInput.x = (touchPosition.x / screenSize.x);
        normalizedInput.y = (touchPosition.y / screenSize.y);

        return normalizedInput * 2;
    }

    private float GetSideMovementFormKeyboard()
    {
        return Input.GetAxis("Horizontal");
    }
}