using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToDestroy;
    [SerializeField] private float delayBetweenDeletions = 2f;

    void Start()
    {
        if (objectsToDestroy.Length > 0)
        {
            StartCoroutine(DestroyObjectsSequentially());
        }
    }

    private IEnumerator DestroyObjectsSequentially()
    {
        foreach (GameObject obj in objectsToDestroy)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
            yield return new WaitForSeconds(delayBetweenDeletions);
        }
    }
}
