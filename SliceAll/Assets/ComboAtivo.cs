using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAtivo : MonoBehaviour
{
    [SerializeField]private GameObject Fruta;
    [SerializeField]private GameObject[] PUP;
    [SerializeField]private GameObject[] pontos;
    [SerializeField]private float SetTimer;
    private float Timer;
    int b, c;
    bool f, j;
    public GameObject padrao;
    private void FixedUpdate(){
        if(f == true){
            if(Timer <= Time.time){
                int lado = Random.Range(0, 2);
                if(lado == 0 ){
                    int podePP = Random.Range(0, 101);
                    if(podePP >= 80){
                        int ePP = Random.Range(0, 4);
                        GameObject fru = Instantiate(PUP[ePP], pontos[0].transform.position, Quaternion.identity);
                    }else{
                        GameObject fru = Instantiate(Fruta, pontos[0].transform.position, Quaternion.identity);
                    }
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
            if(f == true){
                Timer = Time.time + 1.25f;
                f = false;
            }
            if(j == true){
                if(Timer <= Time.time){
                    padrao.SetActive(true);
                    j = false;
                    c = 0;
                }
            }
        }
    }
    public void AtivaEvento(int a){
        b = a;
        f = true;
        j= true;
        Timer = Time.time + SetTimer;
    }
    public void ParaEvento(){
        f = false;
        j= false;
        Timer = Time.time + 100f;
    }
}
