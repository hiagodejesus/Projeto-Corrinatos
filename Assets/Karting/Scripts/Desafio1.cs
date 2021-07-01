using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Desafio1 : MonoBehaviour
{
    public GameObject canvas, canvasTraducao;
    public TextMeshProUGUI texto, textoIngles, textoPortugues, textoTipo;
    private static int index;
    private List<string> palavras = new List<string> {"Pretend", "Economy", "Prejudice", "Emotion", "College", "Example", "Library", "Future", "Support", "Garage"}; 
    private List<string> traducao = new List<string> {"Fingir", "Economia", "Preconceito", "Emoção", "Faculdade", "Exemplo", "Biblioteca", "Futuro", "Apoio", "Garagem"};

    void Start(){
        canvas.gameObject.SetActive(false);
        canvasTraducao.gameObject.SetActive(false);
        index = 0;
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Challenge"){
           PauseMenuActivation(true);
           index = Random.Range(0,10);
           texto.text = textoIngles.text = palavras[index];
           textoPortugues.text = traducao[index];
           canvas.gameObject.SetActive(true);

            if (index % 2 == 1){
                textoTipo.text = "Cognato";
            }else{
                textoTipo.text = "Falso Cognato";
            }
        }
    }   

    public void Answer(){
        canvasTraducao.gameObject.SetActive(false);
        PauseMenuActivation(false);
    }

    
    public void Cognate(){
        canvas.gameObject.SetActive(false);    
        canvasTraducao.gameObject.SetActive(true);
    }

    public void FalseCognate(){
        canvas.gameObject.SetActive(false);
        canvasTraducao.gameObject.SetActive(true);
    }

    void PauseMenuActivation(bool active)
    {
        canvas.SetActive(active);

        if (canvas.activeSelf)
        {
       //     Cursor.lockState = CursorLockMode.None;
          //  Cursor.visible = true;
            Time.timeScale = 0f;
            AudioUtility.SetMasterVolume(0);
            
        }
        else
        {
         //   Cursor.lockState = CursorLockMode.Locked;
         //   Cursor.visible = false;
            Time.timeScale = 1f;
            AudioUtility.SetMasterVolume(1);
        }

    }
}
