using UnityEngine;
using TMPro;

public class HtmlBox : MonoBehaviour
{
    public string htmlTag; 
    public static int currentBoxIndex = 0; 
    public int myIndex;

    private Transform textTransform; 
    private Camera mainCamera;

    void Start()
    {
        Debug.Log("Caja creada - Índice: " + myIndex + " - Etiqueta: " + htmlTag);

        mainCamera = Camera.main;


        GameObject textObject = new GameObject("BoxText");
        textObject.transform.SetParent(transform);
        textObject.transform.localPosition = Vector3.up * 2;

        TextMeshPro textMesh = textObject.AddComponent<TextMeshPro>();
        textMesh.text = htmlTag;
        textMesh.fontSize = 5;
        textMesh.color = Color.black;
        textMesh.alignment = TextAlignmentOptions.Center;
        textMesh.outlineColor = Color.black; 
        textMesh.outlineWidth = 0.2f;

        GameObject backgroundObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
        backgroundObject.name = "TextBackground";
        backgroundObject.transform.SetParent(textObject.transform);
        
        backgroundObject.transform.localPosition = new Vector3(0, 0, 0.1f); 

        backgroundObject.transform.localScale = new Vector3(2, 1.5f, 1); 


        textTransform = textObject.transform;
    }

    void Update()
    {
        if (mainCamera != null && textTransform != null)
        {
            textTransform.rotation = Quaternion.LookRotation(textTransform.position - mainCamera.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisión detectada con: " + other.gameObject.name);

        if (other.CompareTag("Projectile"))
        {
            Debug.Log("¡Proyectil impactó en la caja con índice: " + myIndex + "!" + htmlTag);

            if (myIndex == currentBoxIndex)
            {
                currentBoxIndex++;
                Debug.Log("Caja destruida en orden: " + htmlTag);
                Interface.instance.AgregarTexto(htmlTag);

                Destroy(gameObject);
                GameManager.IncrementDestroyedBoxes();
            }
            else
            {
                Debug.Log("Esta caja no es la siguiente en el orden.");
            }

            Destroy(other.gameObject);
        }
    }
}

