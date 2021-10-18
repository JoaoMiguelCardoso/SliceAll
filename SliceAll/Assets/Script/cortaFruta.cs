using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cortaFruta : MonoBehaviour
{
    public AudioClip[] audios;
    public AudioSource CortaFrutaSom;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag.Equals("Faca")){
            if(GetComponentInParent<Contafruta>() != null){
                GetComponentInParent<Contafruta>().frutacortada();
            }
            int o = Random.Range(0, audios.Length);
            CortaFrutaSom.clip = audios[o];
            CortaFrutaSom.enabled = true;
            CortaFrutaSom.Play();
            Destroy(this.gameObject);
        }
    }
}
