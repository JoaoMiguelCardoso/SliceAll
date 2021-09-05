using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudaPadrao : MonoBehaviour
{
    [SerializeField]private GameObject[] _padroes;
    private int _length, _random;
    void Start()
    {
        _length = _padroes.Length;
        padraosemnd();
    }
    public void padraosemnd(){
        _random= Random.Range(0, _length);
        Instantiate(_padroes[_random], transform.position, Quaternion.identity);
    }
}
