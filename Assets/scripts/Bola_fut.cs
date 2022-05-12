using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola_fut : MonoBehaviour
{
    public GameObject spawner;
    private Spawner_fut spawner_script;
    private bool colidiu;
    private HUD_fut HUD_script;
    private GameObject canvas;
    private int gols;
    private int defendidos;

    private Renderer cylinderRenderer;
    private Light cylinderLight;
    
    private Color32 color;

    // Start is called before the first frame update
    void Start()
    {
        
        spawner = GameObject.FindWithTag("spawner");
        spawner_script = spawner.GetComponent<Spawner_fut>();
        canvas = GameObject.FindWithTag("canvas");
        HUD_script = canvas.GetComponent<HUD_fut>();
        colidiu = false;

        cylinderRenderer = GetComponent<Renderer>();
        cylinderLight = GetComponent<Light>();
        Dificuldade(spawner_script.total_bolas);


        gols = HUD_script.gols;
        defendidos = HUD_script.defendidos;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!colidiu){
            if (collision.gameObject.tag == "hand") {
                defendidos += 1;
                HUD_script.defendidos = defendidos;
                colidiu = true;
                spawner_script.tem_bola = false;
                Destroy(this.gameObject,1.0f);
            }
            if (collision.gameObject.tag == "gol") {
                gols -= 1;
                HUD_script.gols = gols;
                print("gols:" + gols);
                print("HUD gols:" + HUD_script.gols);
                colidiu = true;
                spawner_script.tem_bola = false;
                Destroy(this.gameObject,.05f);
            }
        }
    }

    void Dificuldade(int contador)
    {
        if (contador < 11){
            color = new Color32(143,223,253,255);
            cylinderRenderer.material.SetColor("_EmissionColor", color);
            cylinderLight.color = color;
            return;
        }
        if (contador < 21){
            color = new Color32(167,223,244,255);
            cylinderRenderer.material.SetColor("_EmissionColor", color);
            cylinderLight.color = color;
            return;
        }
        if (contador < 31){
            color = new Color32(209,185,255,255);
            cylinderRenderer.material.SetColor("_EmissionColor", color);
            cylinderLight.color = color;
            return;
        }
        if (contador < 41){
            color = new Color32(255,141,227,255);
            cylinderRenderer.material.SetColor("_EmissionColor", color);
            cylinderLight.color = color;
            return;
        }
        color = new Color32(255,84,213,255);
        cylinderRenderer.material.SetColor("_EmissionColor", color);
        cylinderLight.color = color;
        return;
    }
}