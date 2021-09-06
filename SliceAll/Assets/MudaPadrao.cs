using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudaPadrao : MonoBehaviour
{
    [SerializeField]private GameObject[] _padroes;
    private int _length, _random;
    private bool _sem;
    [SerializeField] private float SetRespawn;
    private float respawn;
    private GameObject faca;
    void Start()
    {
        _length = _padroes.Length;
        faca = GameObject.FindGameObjectWithTag("Faca");
        padraosemnd();
    }
    private void Update(){
        if(_sem && faca.GetComponent<jogafaca>()._indo == false){
            if(respawn < Time.time){
                _random= Random.Range(0, _length);
                Instantiate(_padroes[_random], transform.position, Quaternion.identity);
                _sem = false;
            }
        }else{
            respawn = SetRespawn + Time.time;
        }
    }
    public void padraosemnd(){
        _sem = true;
    }
}
