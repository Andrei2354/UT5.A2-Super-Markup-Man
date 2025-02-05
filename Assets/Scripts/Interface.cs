using UnityEngine;
using TMPro;

public class Interface : MonoBehaviour
{
    public static Interface instance;
    public TextMeshProUGUI textUI; 
    private string historialEtiquetas = ""; 

    void Awake()
    {
        // Configurar el Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AgregarTexto(string nuevoTexto)
    {
        if (textUI != null)
        {
            historialEtiquetas += nuevoTexto + "\n";
            textUI.text = "Progreso:\n" + historialEtiquetas;
        }
    }
    public void ReiniciarTexto(){
        historialEtiquetas = ""; 
        textUI.text = "Etiquetas destruidas:\n"; 
    }
}
