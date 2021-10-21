using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class jogafaca : MonoBehaviour
{
    public bool _indo;
    private bool _inicio = true;
    [SerializeField] private float velo;
    [SerializeField] private GameObject telainicio, telaover, funto, opcoes, combo, evento, particula, Text2X;
    [SerializeField] private Text Pontos;
    [SerializeField]private TMP_Text best, atual, facasTXT;
    public float FrutasCortas;
    private int FrutasEmSequencia;
    private int Pontuacao, BestPontu;
    private int PontuacaooDafruta;
    private float facadas;
    private bool Combando;
    private GameObject _muda, _botao;
    public AudioSource JogouFacaSom;
    private GameObject temp;

    private int _2X;
    [SerializeField]private float SetTime2X, SetTimeGrande;
    private float Time2x, TimeGrande;
    private int facas;
    public void Start(){
        _muda = GameObject.FindGameObjectWithTag("Muda");
        _botao = GameObject.FindGameObjectWithTag("botaoPricipal");
        telainicio.SetActive(true);
        funto.SetActive(true);
        telaover.SetActive(false);
        combo.SetActive(false);
        BestPontu = PlayerPrefs.GetInt("Best");
        Text2X.SetActive(false);
    }
    private void Update(){
        Pontos.text = ""+ Pontuacao;
        facasTXT.text = "X"+facas;
        combo.transform.GetChild(2).transform.localScale = new Vector3(facadas, 1f, 1f) ;
        if(Time2x <= Time.time){
            _2X = 1;
            Text2X.SetActive(false);
        }
        if(TimeGrande <= Time.time){
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
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
                    temp = GameObject.FindGameObjectWithTag("padrao");
                    GameObject.FindGameObjectWithTag("padrao").SetActive(false);
                    evento.GetComponent<ComboAtivo>().AtivaEvento(y);
                    facadas = 0;
                }
            }else{  
                if(facas <= 0){
                    GameOve();
                }else{
                    facas--;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                    transform.position= new Vector3(0f, -3.5f, 0f);
                    _inicio = true;
                    _indo = false;
                    FrutasEmSequencia = 0;
                }
            }
        }
        if(other.tag.Equals("Fruta")){
            if(other.GetComponent<cortaFruta>().t == false){
                Debug.Log("ta loko?");
                FrutasEmSequencia ++;
                FrutasCortas +=1;
                PontuacaooDafruta = 1 * FrutasEmSequencia;
                Pontuacao = Pontuacao + (PontuacaooDafruta* _2X);
                other.GetComponent<cortaFruta>().t = true;
                Parti(other.transform);
            }
        }
        if(other.tag.Equals("PUP_2X")){
            Time2x = SetTime2X + Time.time;
            _2X = 2;
            Text2X.SetActive(true);
            if(other.GetComponent<cortaFruta>().t == false){
                Debug.Log("ta loko?");
                FrutasEmSequencia ++;
                FrutasCortas +=1;
                PontuacaooDafruta = 1 * FrutasEmSequencia;
                Pontuacao = Pontuacao + (PontuacaooDafruta* _2X);
                other.GetComponent<cortaFruta>().t = true;
                Parti(other.transform);
            }
        }
        if(other.tag.Equals("PUP_faca")){
            facas ++;
            if(other.GetComponent<cortaFruta>().t == false){
                Debug.Log("ta loko?");
                FrutasEmSequencia ++;
                FrutasCortas +=1;
                PontuacaooDafruta = 1 * FrutasEmSequencia;
                Pontuacao = Pontuacao + (PontuacaooDafruta* _2X);
                other.GetComponent<cortaFruta>().t = true;
                Parti(other.transform);
            }
        }
        if(other.tag.Equals("PUP_Devagar")){
            temp.GetComponent<giraFrutas>().MultiVelo();
            if(other.GetComponent<cortaFruta>().t == false){
                Debug.Log("ta loko?");
                FrutasEmSequencia ++;
                FrutasCortas +=1;
                PontuacaooDafruta = 1 * FrutasEmSequencia;
                Pontuacao = Pontuacao + (PontuacaooDafruta* _2X);
                other.GetComponent<cortaFruta>().t = true;
                Parti(other.transform);
            }
        }
        if(other.tag.Equals("PUP_Grande")){
            transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            TimeGrande = SetTimeGrande + Time.time;
            if(other.GetComponent<cortaFruta>().t == false){
                Debug.Log("ta loko?");
                FrutasEmSequencia ++;
                FrutasCortas +=1;
                PontuacaooDafruta = 1 * FrutasEmSequencia;
                Pontuacao = Pontuacao + (PontuacaooDafruta* _2X);
                other.GetComponent<cortaFruta>().t = true;
                Parti(other.transform);
            }
        }
    }
    public void GameOve(){
        telaover.SetActive(true);
        atual.text = "SCORE: "+ Pontuacao;
        if(Pontuacao >= BestPontu){
            BestPontu = Pontuacao;
            best.text = "BEST: "+ BestPontu;
            PlayerPrefs.SetInt("Best", BestPontu);
        }else{
            best.text = "BEST: "+ BestPontu;;
        }
        Time2x = 0;
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
    private void Parti(Transform v){
        GameObject p = Instantiate(particula, v.position, Quaternion.identity);
        Destroy(p, 2f);
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
