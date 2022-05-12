using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_fut : MonoBehaviour
{
    public bool tem_bola;
    public GameObject Bola;
    public int total_bolas;
    private HUD_fut HUD_script;
    private GameObject canvas;
    public float speed; 
    // Start is called before the first frame update
    void Start()
    {
        total_bolas = 0;
        canvas = GameObject.FindWithTag("canvas");
        HUD_script = canvas.GetComponent<HUD_fut>();
        HUD_script.bolas = total_bolas;
    }
    void Update()
    {
        while (!tem_bola) {

            total_bolas += 1;
            HUD_script.bolas = total_bolas;
            tem_bola = true;


            float spawnPointX = Random.Range(-1.5f, 1.5f);

            float spawnPointY = Random.Range(0.5f, 1.5f);

            float spawnPointZ = -9.5f;

            Vector3 spawnPos = new Vector3(spawnPointX, spawnPointY, spawnPointZ);

            GameObject objeto = Instantiate(Bola, spawnPos, Quaternion.identity);

            objeto.transform.parent = gameObject.transform;

            float endPointX = Random.Range(-1.5f, 1.5f);
            float spawnDirX = 0.0f;
            if (spawnPointX < endPointX){ //vel positiva
                float distX = endPointX - spawnPointX;
                spawnDirX = distX / 2;
                if (spawnDirX > 1){
                    spawnDirX = spawnDirX * 0.8f;
                }
            }
            if (spawnPointX > endPointX){ //vel negativa
                float distX =  spawnPointX - endPointX;
                spawnDirX = - distX / 2;
                if (spawnDirX < -1){
                    spawnDirX = spawnDirX * 0.8f;
                }
            }
            if (spawnPointX == endPointX){ // vel nula
                spawnDirX = 0.0f;
            }

            float endPointY = Random.Range(0.5f, 1.5f);
            float spawnDirY = 0.0f;
            if (spawnPointY < endPointY){ //vel positiva
                float distY = endPointY - spawnPointY;
                spawnDirY = distY / 1.6f;

            }
            if (spawnPointY > endPointY){ //vel negativa
                float distY =  spawnPointY - endPointY;
                spawnDirY = - distY / 2;

            }
            if (spawnPointY == endPointY){ // vel nula
                spawnDirY = 0.0f;
            }
            float spawnDirZ = 10.0f;
            Dificuldade(total_bolas);
            Vector3 spawnDirection = new Vector3 (spawnDirX, spawnDirY, spawnDirZ);

            objeto.GetComponent<Rigidbody>().velocity = speed * spawnDirection;
        }
    }

    void Dificuldade(int contador)
    {
        if (contador < 11){
            speed = 1.0f;
            return;
        }
        if (contador < 21){
            speed = 2.0f;
            return;
        }
        if (contador < 31){
            speed = 4.5f;
            return;
        }
        if (contador < 41){
            speed = 5.5f;
            return;
        }
        speed = 7.0f;
        return;
    }

}