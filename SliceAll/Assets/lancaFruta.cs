using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lancaFruta : MonoBehaviour
{
    public bool lado;
    private int ForcaVertica, ForcaHorizantal;
    private Rigidbody2D rb;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        lanca();
    }
    public void lanca(){
        ForcaVertica = Random.Range(200, 401);
        ForcaHorizantal = Random.Range(300, 401);
        if(lado == true){
            rb.AddForce(new Vector2(-ForcaHorizantal, ForcaVertica));
        }else{
            rb.AddForce(new Vector2(ForcaHorizantal, ForcaVertica));
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag.Equals("Limite")){
            Destroy(this.gameObject);
        }
    }
}
