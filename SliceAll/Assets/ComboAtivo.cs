using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAtivo : MonoBehaviour
{
    [SerializeField]private GameObject Fruta;
    [SerializeField]private GameObject[] pontos;
    int b, c;
    bool f;
    private void FixedUpdate(){
        if(f == true){
            int lado = Random.Range(0, 2);
            if(lado == 0 ){
                GameObject fru = Instantiate(Fruta, pontos[0].transform.position, Quaternion.identity);
                c++;
            }else if(lado >0){
                GameObject fru = Instantiate(Fruta, pontos[1].transform.position, Quaternion.identity);
                fru.GetComponent<lancaFruta>().lado = true;
                c++;
            }
        }   
        if(c >= b){
            f = false;
        }
    }
    public void AtivaEvento(int a){
        b = a;
        f = true;
    }
}
