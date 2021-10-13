using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cortaFruta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag.Equals("Faca")){
            GetComponentInParent<Contafruta>().frutacortada();
            Destroy(this.gameObject);
        }
    }
}
