using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInteractable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hand"))
        {
            this.GetComponent<Animator>().SetTrigger("GetHit");
            this.GetComponent<AudioSource>().Play();
        }
    }
}
