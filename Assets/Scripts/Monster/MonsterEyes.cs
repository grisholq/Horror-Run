using UnityEngine;

public class MonsterEyes : MonoBehaviour
{
    [SerializeField] private Transform[] _eyes;

    private void Awake()
    {
        Disable();
    }

    public void Activate()
    {
        foreach (var eye in _eyes)
        {
            eye.gameObject.SetActive(true);
        }
    }

    public void Disable()
    {
        foreach (var eye in _eyes)
        {
            eye.gameObject.SetActive(false);
        }
    }
}