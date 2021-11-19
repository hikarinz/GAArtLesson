using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public GameObject reward;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Cha-Ching!");
        Instantiate(reward, transform.position, transform.rotation);

        Destroy(gameObject);
    }


}
