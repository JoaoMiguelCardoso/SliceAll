using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class jogafaca : MonoBehaviour
{
    public bool _indo;
    private bool _inicio = true;
    [SerializeField] private float velo;
    [SerializeField] private GameObject telainicio, telaover, funto, opcoes, combo, evento;
    [SerializeField] private Text Pontos;
    public float FrutasCortas;
    private int FrutasEmSequencia;
    private int Pontuacao;
    private int PontuacaooDafruta;
    private float facadas;
    private bool Combando;
    private GameObject _muda, _botao;
    public AudioSource JogouFacaSom;

    public void Start(){
        _muda = GameObject.FindGameObjectWithTag("Muda");
        _botao = GameObject.FindGameObjectWithTag("botaoPricipal");
        telainicio.SetActive(true);
        funto.SetActive(true);
        telaover.SetActive(false);
        combo.SetActive(false);
    }
    private void Update(){
        Pontos.text = ""+ Pontuacao;
        combo.transform.GetChild(2).transform.localScale = new Vector3(facadas, 1f, 1f) ;
    }
    public void Click(){
        if(_inicio == false){
            if(_indo == false){
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * velo, ForceMode2D.Force);
                _indo = true;
                JogouFacaSom.Play();
            }
        }else{
            _muda.GetComponent<MudaPadrao>().play();
            telaover.SetActive(false);
            funto.SetActive(false);
            telainicio.SetActive(false);
            combo.SetActive(true);
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
                FrutasEmSequencia = 0;
                facadas = facadas + 0.1f;
                if(facadas >= 1){
                    Combando = true;
                    int y = Random.Range(20, 40);
                    evento.GetComponent<ComboAtivo>().padrao = GameObject.FindGameObjectWithTag("padrao");
                    GameObject.FindGameObjectWithTag("padrao").SetActive(false);
                    evento.GetComponent<ComboAtivo>().AtivaEvento(y);
                    facadas = 0;
                }
            }else{
                GameOve();
            }
        }
        if(other.tag.Equals("Fruta")){
            if(other.GetComponent<cortaFruta>().t == false){
                Debug.Log("ta loko?");
                FrutasEmSequencia ++;
                FrutasCortas +=1;
                PontuacaooDafruta = 1 * FrutasEmSequencia;
                Pontuacao = Pontuacao + PontuacaooDafruta;
                other.GetComponent<cortaFruta>().t = true;
            }
        }
    }
    public void GameOve(){
        telaover.SetActive(true);
        funto.SetActive(true);
        _botao.SetActive(false);
        combo.SetActive(false);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        transform.position= new Vector3(0f, -3.5f, 0f);
        _inicio = true;
        _indo = false;
        FrutasEmSequencia = 0;
        _muda.SetActive(false);
        evento.GetComponent<ComboAtivo>().ParaEvento();
        Destroy( GameObject.FindGameObjectWithTag("padrao"));
    }
    public void Restart(){
        Pontuacao = 0;
        facadas = 0;
        funto.SetActive(false);
        _botao.SetActive(true);
        telaover.SetActive(false);
        combo.SetActive(true);
        _muda.SetActive(true);
        _muda.GetComponent<MudaPadrao>().play();
    }
}
