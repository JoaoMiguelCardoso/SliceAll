using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giraFrutas : MonoBehaviour
{
    private Transform tr;
    [SerializeField]private Vector3 rodando;
    [SerializeField]private float setTimerMulti;
    private float TimerMulti;
    private bool MultiAtivo;
    private float velo;
    public float varivelo, Multiplaer;
    [SerializeField]private float setRodaTempo1, setRodaTempo2, setRodaTempo3;
    private float rodaTempo;
    void Start()
    {
        tr = this.transform;
        rodando = new Vector3(0f, 0f, 0f);
        mudaRotacao();
        Multiplaer = 1f;
    }
    void FixedUpdate()
    {
        rodando.z = (velo +varivelo)*Multiplaer;
        tr.Rotate(rodando, Space.World);
        if(rodaTempo <= Time.time){
            mudaRotacao();
        }
        if(MultiAtivo){
            if(TimerMulti<= Time.time){
                Multiplaer = 1f;
                MultiAtivo = false;
            }
        }
    }
    public void MultiVelo(){
        MultiAtivo = true;
        Multiplaer = 0.5f;
        TimerMulti = Time.time + setTimerMulti;
    }

    private void mudaRotacao(){
        velo = Random.Range(-6f, 6f);
        if(velo == 6 || velo  == -6){
            rodaTempo = setRodaTempo1 + Time.time;
        }else if(velo  > -6 && velo  < -4  || velo  < 6 && velo  > 4 ){
            rodaTempo = setRodaTempo2 + Time.time;
        }else if(velo  >= -4 && velo  < -3  || velo  <= 4 && velo  > 3 ){
            rodaTempo = setRodaTempo3 + Time.time;
        }else if(velo  >= -3 && velo  <= -1  || velo  <= 3 && velo  >= 1 ){
            rodaTempo = setRodaTempo2 + Time.time;
        }else if(velo > -1 && velo  < 1 ){
            mudaRotacao();
        }
    }
}
