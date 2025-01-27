using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject clonePrefab;
    public int poolSize = 10;
    private List<GameObject> clonePool;

    private void Awake()
    {
        clonePool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject clone = Instantiate(clonePrefab);
            clone.SetActive(false);
            clonePool.Add(clone);
        }
    }

    public GameObject GetClone()
    {
        foreach (var clone in clonePool)
        {
            if (!clone.activeInHierarchy)
            {
                clone.SetActive(true);
                return clone;
            }
        }
        return null; // Pool exhausted
    }

    public void ReturnClone(GameObject clone)
    {
        clone.SetActive(false);
    }
}
