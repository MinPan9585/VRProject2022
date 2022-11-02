using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlant : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        //print("hit something");
        if(other.gameObject.CompareTag("hand")){
            //print("hit hand");
            SceneManager.LoadScene("Scene1021");
        }
    }
}
