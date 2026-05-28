using UnityEngine;
using UnityEngine.SceneManagement; // Questo è il passaporto per viaggiare tra le scene!

public class GestoreMenu : MonoBehaviour
{
    public void AvviaGioco()
    {
        // ATTENZIONE: Scrivi qui il nome ESATTO della tua scena della stanza medica (rispettando le maiuscole!)
        SceneManager.LoadScene("Demo");
    }
}