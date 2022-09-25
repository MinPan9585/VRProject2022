using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muzhuang : MonoBehaviour
{

    public Animator anim;

    public void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "hand")
      {
        //play animation
        anim.SetTrigger("drum3");

        //play SFX

        
      }
    }
}
