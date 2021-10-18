using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAtivo : MonoBehaviour
{
    [SerializeField]private GameObject Fruta;
    [SerializeField]private GameObject[] pontos;
    [SerializeField]private float SetTimer;
    private float Timer;
    int b, c;
    bool f;
    private void FixedUpdate(){
        if(f == true){
            if(Timer <= Time.time){
                int lado = Random.Range(0, 2);
                if(lado == 0 ){
                    GameObject fru = Instantiate(Fruta, pontos[0].transform.position, Quaternion.identity);
                    c++;
                    Timer = Time.time + SetTimer;
                }else if(lado >0){
                    GameObject fru = Instantiate(Fruta, pontos[1].transform.position, Quaternion.identity);
                    fru.GetComponent<lancaFruta>().lado = true;
                    c++;
                    Timer = Time.time + SetTimer;
                }
            }
        }   
        if(c >= b){
            f = false;
        }
    }
    public void AtivaEvento(int a){
        b = a;
        f = true;
        Timer = Time.time + SetTimer;
    }
}
