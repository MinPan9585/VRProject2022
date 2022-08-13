using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muzhuang : MonoBehaviour
{

    public Animator anim;
    public void OntriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "hand")
      {
        anim.SetBool("drum1",true);
      }
    }
}
