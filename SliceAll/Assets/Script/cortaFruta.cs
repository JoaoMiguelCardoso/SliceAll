using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cortaFruta : MonoBehaviour
{
    public AudioSource[] CortaFrutaSom;
    bool t =false;
    float r;
    private void Update(){
        if(t == true){
            if(r<= Time.time){
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag.Equals("Faca")){
            if(GetComponentInParent<Contafruta>() != null){
                GetComponentInParent<Contafruta>().frutacortada();
            }
            int o = Random.Range(0, CortaFrutaSom.Length);
            CortaFrutaSom[o].Play();
            GetComponent<SpriteRenderer>().enabled = false;
            r = Time.time + 1f;
            t = true;
        }
    }
}
