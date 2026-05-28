using UnityEngine;

public class InterazioneCaregiver : MonoBehaviour
{
    public float raggioAzione = 5f;
    public GestioneScenari cervelloDelGioco;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
        {
            Ray raggio = new Ray(transform.position, transform.forward);
            RaycastHit colpo;

            if (Physics.Raycast(raggio, out colpo, raggioAzione))
            {
                // Salviamo il tag dell'oggetto colpito (questa era la riga sparita!)
                string tagColpito = colpo.transform.tag;

                // I NOSTRI RAGGI X: Ci dice in Console cosa stiamo guardando!
                Debug.Log("🎯 Il laser ha colpito: " + colpo.transform.name + " | Il suo Tag è: [" + tagColpito + "]");

                // Se tocco un oggetto medico, passo la palla al Cervello per valutarlo!
                if (tagColpito == "Calmante" || tagColpito == "Antipsicotico" || tagColpito == "GiocoSensoriale")
                {
                    //cervelloDelGioco.ValutaScelta(tagColpito);
                }
            }
        }
    }
}