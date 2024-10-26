using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    // Piscar o inimigo


    // no Git Package de VFX e um de Numeros
    [Header("Script References")]
    public CharacterStatusManager statusScript;
    public MeshRenderer myRenderer;

    private void Start()
    {
        if(gameObject.tag != "Enemy")
        {
            Init();
        }
    }
    public void Init()
    {
        statusScript = GetComponent<CharacterStatusManager>();
        myRenderer = GetComponentInChildren<MeshRenderer>();

        SubscribeToEvent();
    }

    private void SubscribeToEvent() // se inscreve em eventos
    {
        Debug.Log("Se inscrevendo aos eventos");

        statusScript.OnTakeDamage += BlinkMaterial;
    }

    private void OnDisable() // se desinscreve em eventos
    {
        Debug.Log("Se desinscrevendo aos eventos");

        statusScript.OnTakeDamage -= BlinkMaterial;
    }

    public void BlinkMaterial()
    {
        if (statusScript == null)
        {
            Debug.LogError("Missing status script");
            return; 
        }

        if (myRenderer == null)
        {
            Debug.LogError("Missing renderer script");
            return;
        }

            StartCoroutine(BlinkMaterialRoutine());
    }

    IEnumerator BlinkMaterialRoutine()
    {
        var myMaterial = myRenderer.materials[0];
        var myMaterialColor = myMaterial.color;

        myMaterial.color = Color.white;

        yield return new WaitForSeconds(0.2f);

        myMaterial.color = myMaterialColor;
    }
}
