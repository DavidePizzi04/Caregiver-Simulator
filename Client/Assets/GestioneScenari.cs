using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI; // FONDAMENTALE PER FAR PULSARE IL COLORE

public class GestioneScenari : MonoBehaviour
{
    [Header("Collegamenti Interfaccia Tablet")]
    public TextMeshProUGUI testoDatiPaziente;
    public TextMeshProUGUI testoSintomo;
    public TextMeshProUGUI testoDirettiva;
    public TextMeshProUGUI testoPunteggio;

    [Header("Filtro Empatico (Requisito Prof)")]
    public GameObject filtroCrisi;

    private string tagCorretto;
    private int punteggio = 0;
    private int errori = 0;
    private int ultimoScenario = -1;
    private string[] nomiPazienti = { "Anonimo", "Marco B.", "Luca F.", "Sara V.", "Elena R.", "Matteo C.", "Giulia S." };

    void Start()
    {
        GeneraCasoMedico();
    }

    public void GeneraCasoMedico()
    {
        string nome = nomiPazienti[Random.Range(0, nomiPazienti.Length)];
        int eta = Random.Range(20, 55);
        int battito = Random.Range(85, 135);

        testoDatiPaziente.text = $"<color=#FFE000>Paziente:</color> {nome}\n" +
                                 $"<color=#FFE000>Età:</color> {eta} anni\n" +
                                 $"<color=#FFE000>Battito:</color> {battito} bpm\n" +
                                 $"<color=#FFE000>Reparto:</color> Neurologia";

        int scenario;
        do { scenario = Random.Range(0, 6); } while (scenario == ultimoScenario);
        ultimoScenario = scenario;

        if (scenario == 0)
        {
            testoSintomo.text = "<color=#FF4545>STATO CLINICO:</color>\nIl paziente presenta isolamento, dondolamento ritmico (stimming) e chiusura agli stimoli esterni. Nessuna aggressività.";
            testoDirettiva.text = "<color=#00FFFB>OBIETTIVO TERAPEUTICO:</color>\nEvitare farmaci. Favorire l'ancoraggio alla realtà tramite stimolazione tattile o visiva.";
            tagCorretto = "GiocoSensoriale";
            filtroCrisi.SetActive(false);
        }
        else if (scenario == 1)
        {
            testoSintomo.text = "<color=#FF4545>STATO CLINICO:</color>\nStato di ansia crescente, respiro affannoso e pianto. Rifiuto del dialogo, ma nessun rischio di danno fisico.";
            testoDirettiva.text = "<color=#00FFFB>OBIETTIVO TERAPEUTICO:</color>\nRidurre lo stato d'ansia. Somministrare sedazione farmacologica lieve (es. Ansiolitico/Calmante).";
            tagCorretto = "Calmante";
            filtroCrisi.SetActive(false);
        }
        else if (scenario == 2)
        {
            testoSintomo.text = "<color=#FF4545>STATO CLINICO:</color>\nCrisi di agitazione psicomotoria acuta, deliri, urla e lancio di oggetti. Alto rischio di autolesionismo.";
            testoDirettiva.text = "<color=#00FFFB>OBIETTIVO TERAPEUTICO:</color>\nBlocco immediato della crisi. Somministrare sedazione farmacologica maggiore (es. Antipsicotico).";
            tagCorretto = "Antipsicotico";
            filtroCrisi.SetActive(false);
        }
        else if (scenario == 3)
        {
            testoSintomo.text = "<color=#FF4545>STATO CLINICO:</color>\nSovraccarico sensoriale acuto. Il paziente si copre le orecchie, tiene gli occhi chiusi saldamente e si rannicchia a terra.";
            testoDirettiva.text = "<color=#00FFFB>OBIETTIVO TERAPEUTICO:</color>\nNon forzare il contatto. Fornire un oggetto di regolazione per abbassare il livello di stress senza usare farmaci.";
            tagCorretto = "GiocoSensoriale";
            filtroCrisi.SetActive(true);
        }
        else if (scenario == 4)
        {
            testoSintomo.text = "<color=#FF4545>STATO CLINICO:</color>\nInsonnia prolungata, nervosismo e lamenti continui. Il paziente cammina avanti e indietro per la stanza nervosamente.";
            testoDirettiva.text = "<color=#00FFFB>OBIETTIVO TERAPEUTICO:</color>\nFavorire il rilassamento e ridurre l'iperattività lieve. Richiesta somministrazione PRN di un calmante leggero.";
            tagCorretto = "Calmante";
            filtroCrisi.SetActive(false);
        }
        else if (scenario == 5)
        {
            testoSintomo.text = "<color=#FF4545>STATO CLINICO:</color>\nComportamento eteroaggressivo improvviso, forte disorientamento spazio-temporale. Minaccia il personale avvicinandosi.";
            testoDirettiva.text = "<color=#00FFFB>OBIETTIVO TERAPEUTICO:</color>\nGarantire la sicurezza del paziente e dell'operatore. Necessario intervento farmacologico forte di emergenza.";
            tagCorretto = "Antipsicotico";
            filtroCrisi.SetActive(true);
        }

        testoPunteggio.text = "Punteggio: " + punteggio;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) SparaLaser();

        // EFFETTO BATTITO CARDIACO (PULSAZIONE DEL FILTRO)
        if (filtroCrisi != null && filtroCrisi.activeSelf)
        {
            Image immagineFiltro = filtroCrisi.GetComponent<Image>();
            if (immagineFiltro != null)
            {
                Color colore = immagineFiltro.color;
                // Fa pulsare l'Alpha (Trasparenza) su e giù simulando il respiro/battito
                colore.a = Mathf.PingPong(Time.time * 1.5f, 0.4f) + 0.1f;
                immagineFiltro.color = colore;
            }
        }
    }

    void SparaLaser()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 25f))
        {
            string colpito = hit.collider.tag;
            if (colpito == "Untagged") return;

            if (colpito == tagCorretto)
            {
                punteggio += 10;

                // IL TRACCIANTE:
                Debug.Log("🎯 BERSAGLIO COLPITO! Sto per contattare Docker...");

                // MANDA I DATI A DOCKER
                StartCoroutine(InviaDatiAlServer(punteggio, errori));

                errori = 0; // Resetta gli errori per il nuovo paziente
                GeneraCasoMedico();
            }
            else if (colpito == "Calmante" || colpito == "Antipsicotico" || colpito == "GiocoSensoriale")
            {
                punteggio -= 5;
                errori += 1; // Aggiunge un errore
                testoPunteggio.text = "Punteggio: " + punteggio;
            }
        }
    }

    IEnumerator InviaDatiAlServer(int punteggioFinale, int totaleErrori)
    {
        string url = "http://127.0.0.1:5000/salva_risultati";
        string json = $"{{\"punteggio\": {punteggioFinale}, \"errori\": {totaleErrori}}}";

        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("✅ Dati inviati a Docker con successo!");
            }
            else
            {
                Debug.LogError("❌ Errore di connessione a Docker: " + request.error);
            }
        }
    }
}