using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contafruta : MonoBehaviour
{
    [SerializeField]private float Quantidade;
    private GameObject _muda;
    private float frutascorta;
    private void Start(){
        _muda = GameObject.FindGameObjectWithTag("Muda");
    }
    void Update()
    {
        if(frutascorta == Quantidade){
            _muda.GetComponent<MudaPadrao>().padraosemnd();
            Destroy(this.gameObject);
        }
    }

    public void frutacortada(){
        frutascorta += 1;
    }
}
