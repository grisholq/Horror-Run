using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    [SerializeField] private Bar _progressBar;

    private Transform _character;
    private Transform _levelStart;
    private Transform _levelEnd;

    private float _levelDistance;

    private void Awake()
    {
        Inizialize();
    }

    private void Inizialize()
    {      
        _character = FindObjectOfType<Character>().transform;
        _levelStart = FindObjectOfType<LevelStart>().transform;
        _levelEnd = FindObjectOfType<LevelEnd>().transform;
        _levelDistance = Vector3.Distance(_levelStart.position, _levelEnd.position);
    }

    private void Update()
    {
        UpdateUI(GetLevelProgress());
    }

    public void UpdateUI(float progress)
    {
        if (_progressBar.isActiveAndEnabled == false) return;
        _progressBar.SetBarValueNormalized(progress);
    }

    private float GetLevelProgress()
    {
        return 1 - (GetDistanceToEnd() / _levelDistance);
    }

    private float GetDistanceToEnd()
    {
        return Vector3.Distance(_character.position, _levelEnd.position);
    }
}