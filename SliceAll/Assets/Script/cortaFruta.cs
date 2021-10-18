using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cortaFruta : MonoBehaviour
{
    public AudioSource CortaFrutaSom;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag.Equals("Faca")){
            GetComponentInParent<Contafruta>().frutacortada();
            Destroy(this.gameObject);
            CortaFrutaSom.Play();
        }
    }
}
