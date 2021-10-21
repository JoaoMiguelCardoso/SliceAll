using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cortaFruta : MonoBehaviour
{
    public AudioSource[] CortaFrutaSom;
    Animator animato;
    public bool t =false;
    float r;
    public void Start(){
        animato = GetComponent<Animator>();
    }
    private void Update(){
        if(t == true){
            if(r<= Time.time){
                if(GetComponentInParent<Contafruta>() != null){
                    GetComponentInParent<Contafruta>().frutacortada();
                }
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag.Equals("Faca")){
            animato.SetTrigger("");
            Debug.Log("ue");
            int o = Random.Range(0, CortaFrutaSom.Length);
            CortaFrutaSom[o].Play();
            GetComponent<SpriteRenderer>().enabled = false;
            r = Time.time + 1f;
        }
    }
}
