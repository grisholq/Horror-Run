using UnityEngine;

public class SanityItemSkin : MonoBehaviour
{
    public void SetView(Transform viewPrefab)
    {
        RemoveAllChildren();
        Transform view = InstantiateView(viewPrefab);
        view.SetParent(transform);
        view.localPosition = Vector3.zero;
    }

    private void RemoveAllChildren()
    {
        if (transform.childCount == 0) return;

        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    private Transform InstantiateView(Transform skin)
    {
        return Instantiate(skin);
    }
}