using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giraFrutas : MonoBehaviour
{
    private Transform tr;
    [SerializeField]private Vector3 rodando;
    [SerializeField]private float setRodaTempo1, setRodaTempo2, setRodaTempo3;
    private float rodaTempo;
    void Start()
    {
        tr = this.transform;
        rodando = new Vector3(0f, 0f, 0f);
        mudaRotacao();
    }
    void FixedUpdate()
    {
        tr.Rotate(rodando, Space.World);
        if(rodaTempo <= Time.time){
            mudaRotacao();
        }
    }

    private void mudaRotacao(){
        rodando.z = Random.Range(-6f, 6f);
        if(rodando.z == 6 || rodando.z == -6){
            rodaTempo = setRodaTempo1 + Time.time;
        }else if(rodando.z > -6 && rodando.z < -4  || rodando.z < 6 && rodando.z > 4 ){
            rodaTempo = setRodaTempo2 + Time.time;
        }else if(rodando.z >= -4 && rodando.z < -3  || rodando.z <= 4 && rodando.z > 3 ){
            rodaTempo = setRodaTempo3 + Time.time;
        }else if(rodando.z >= -3 && rodando.z <= -1  || rodando.z <= 3 && rodando.z >= 1 ){
            rodaTempo = setRodaTempo2 + Time.time;
        }else if(rodando.z > -1 && rodando.z < 1 ){
            mudaRotacao();
        }
    }
}
