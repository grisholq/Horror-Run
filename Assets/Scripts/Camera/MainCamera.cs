using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Camera _camera;
    public Camera Camera => _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }
}