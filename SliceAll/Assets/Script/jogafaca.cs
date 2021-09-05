using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jogafaca : MonoBehaviour
{
    private bool _indo;
    [SerializeField] private float velo;
    public float FrutasCortas;
    
    public void Click(){
        if(_indo == false){
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * velo, ForceMode2D.Force);
            _indo = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag.Equals("Limite")){
            if(FrutasCortas != 0){
                GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                transform.position= new Vector3(0f, -3.5f, 0f);
                _indo = false;
                FrutasCortas = 0;
            }else{
                Debug.Log("errou");
            }
        }
        if(other.tag.Equals("Fruta")){
            FrutasCortas +=1;
        }
    }
}
