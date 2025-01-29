using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject clonePrefab;
    public int poolSize = 10;
    private List<GameObject> clonePool = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject clone = Instantiate(clonePrefab);
            clone.SetActive(false);
            clonePool.Add(clone);
        }
    }

    public GameObject GetCloneFromPool(Vector3 position)
    {
        foreach (var clone in clonePool)
        {
            if (!clone.activeInHierarchy)
            {
                clone.transform.position = position;
                clone.SetActive(true);
                return clone;
            }
        }
        return null;
    }

    public void ReturnCloneToPool(GameObject clone)
    {
        clone.SetActive(false);
    }
}
