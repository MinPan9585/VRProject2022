using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInteractableParent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hand"))
        {
            this.transform.parent.GetComponent<Animator>().SetTrigger("GetHit");
            this.transform.parent.GetComponent<AudioSource>().Play();
        }
    }
}
