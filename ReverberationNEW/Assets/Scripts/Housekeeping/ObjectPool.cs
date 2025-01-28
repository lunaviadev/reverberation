using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject clonePrefab;
    public int poolSize = 10;
    private List<GameObject> clonePool = new List<GameObject>();

    private void Awake()
    {
        // Create a pool of clones
        for (int i = 0; i < poolSize; i++)
        {
            GameObject clone = Instantiate(clonePrefab);
            clone.SetActive(false); // Start inactive
            clonePool.Add(clone);
        }
    }

    public GameObject GetCloneFromPool(Vector3 position)
    {
        foreach (var clone in clonePool)
        {
            if (!clone.activeInHierarchy)
            {
                clone.transform.position = position; // Set position when reused
                clone.SetActive(true);
                return clone;
            }
        }
        return null; // Pool exhausted, you can add more clones if needed
    }

    public void ReturnCloneToPool(GameObject clone)
    {
        clone.SetActive(false); // Deactivate clone and return to pool
    }
}
