using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupDevagar : MonoBehaviour
{
    [SerializeField] private GameObject PowerUpDevagar;
    public float Spawna;
    public float TimeOut;
    private GameObject velocidade;


    void Start()
    {
        velocidade = GameObject.FindGameObjectWithTag("MudaVelo");
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawna = TimeOut + Time.time;
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Faca"))
        {
            Devagar();
            Destroy(this.gameObject);
        }
    }
    private void Devagar()
    {
        velocidade.GetComponent<giraFrutas>().varivelo = 1f;
    }

    private void Spawn() {
        if (Spawna < 0)
        {
            Instantiate(PowerUpDevagar, transform.position, Quaternion.identity);
        }
    }
}
