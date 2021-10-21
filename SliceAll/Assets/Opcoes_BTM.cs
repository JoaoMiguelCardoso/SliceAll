using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Opcoes_BTM : MonoBehaviour
{
    [SerializeField]private GameObject opcoes, creditos, botoes, fundo, BTM_Som;
    [SerializeField]private Sprite[] som;
    bool ativo = true;
    public void AbreOpcoes(){
        Time.timeScale = 0f;
        opcoes.SetActive(true);
        creditos.SetActive(false);
        botoes.SetActive(true);
        fundo.SetActive(true);
    }
    public void FechaOpcoes(){
        Time.timeScale = 1f;
        opcoes.SetActive(false);
        creditos.SetActive(false);
        botoes.SetActive(false);
        fundo.SetActive(false);
    }
    public void Creditos(){
        creditos.SetActive(true);
        botoes.SetActive(false);
    }
    public void Volta(){
        creditos.SetActive(false);
        botoes.SetActive(true);
    }

    public void BotaoSom(){
        if(ativo){
            DesativaSom();
            BTM_Som.GetComponent<Image>().sprite = som[1];
            ativo = false;
        }else{
            AtivaSom();
            BTM_Som.GetComponent<Image>().sprite = som[0];
            ativo = true;
        }
    }
    private void AtivaSom(){
        AudioListener.volume = 1;
    }
    private void DesativaSom(){
        AudioListener.volume = 0;
    }
}
