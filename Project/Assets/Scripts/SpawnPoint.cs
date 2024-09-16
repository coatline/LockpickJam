using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject gobject;
    [SerializeField] int chance;

    void Start()
    {
        int r = Random.Range(0, 100);

        if (chance >= r)
        {
            Instantiate(gobject, transform.position + new Vector3(Random.Range(-.1f, .1f), 0), Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
