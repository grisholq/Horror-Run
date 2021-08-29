using UnityEngine;

public class CharacterSideInput : MonoBehaviour
{
    public float NormalizedValue { get; set; }

    private void Update()
    {
        if (HasKeyboardInput()) NormalizedValue = GetSideMovement();
        else if (HasTouchInput()) NormalizedValue = GetSideMovementDirectionFromTouch();
        else NormalizedValue = 0;
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
        Vector2 touchPosition = Input.GetTouch(0).position;
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        float x;

        x = (touchPosition.x / screenSize.x) * 2;

        if (x <= 1) return -(1 - x);
        if (x > 1) return (x - 1);

        return 0;
    }

    private float GetSideMovement()
    {
        return Input.GetAxis("Horizontal");
    }
}