using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinglanA : MonoBehaviour
{

    public Animator anim;
    public AudioSource audi;
    public AudioClip LinglanHitSound1;

    public void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "hand")
      {
        //play animation
        anim.SetTrigger("LinglanHit");

        //play SFX
        audi.PlayOneShot(LinglanHitSound1);
      }
    }
}
