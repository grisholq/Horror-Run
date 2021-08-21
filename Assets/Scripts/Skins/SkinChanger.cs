using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    [SerializeField] private Transform _prefab;

    private void Awake()
    {
        _prefab.gameObject.AddComponent<BoxCollider>();
    }
}
