using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jogafaca : MonoBehaviour
{
    public bool _indo;
    private bool _inicio = true;
    [SerializeField] private float velo;
    [SerializeField] private GameObject telainicio, telaover;
    public float FrutasCortas;
    private GameObject _muda, _botao;

    public void Start(){
        _muda = GameObject.FindGameObjectWithTag("Muda");
        _botao = GameObject.FindGameObjectWithTag("botaoPrincipal");
        telainicio.SetActive(true);
        telaover.SetActive(false);
    }
    public void Click(){
        if(_inicio == false){
            if(_indo == false){
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * velo, ForceMode2D.Force);
                _indo = true;
            }
        }else{
            _muda.GetComponent<MudaPadrao>().play();
            telaover.SetActive(false);
            telainicio.SetActive(false);
            _inicio = false;
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
                telaover.SetActive(true);
                _botao.SetActive(false);
                GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                transform.position= new Vector3(0f, -3.5f, 0f);
                _inicio = true;
                _indo = false;
                Debug.Log("errou");
            }
        }
        if(other.tag.Equals("Fruta")){
            FrutasCortas +=1;
        }
    }
}
