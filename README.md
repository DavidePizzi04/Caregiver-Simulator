# Empathic VR Simulator for Caregivers (MVP) 
*Read this in other languages: [English](#english) | [Italiano](#italiano)*

---

## <a name="english"></a> 🇬🇧 English

A Minimum Viable Product (MVP) of a Virtual Reality simulator designed to develop caregiver empathy. The system immerses the user in realistic scenarios, collecting and analyzing interaction data in real-time.

### 🏗 System Architecture

The project is based on a decoupled client-server architecture to ensure scalability and flexibility:

*   **Client (Unity 3D):** Manages the VR simulation and the user interface. It implements local data aggregation logic before sending it to the server, optimizing bandwidth usage.
*   **Backend (Python/Flask):** Receives and processes data from the client via HTTP POST requests.
*   **Deployment:** The server is fully containerized using **Docker**, ensuring environmental isolation and maximum portability.

### 🛠 Technologies Used

*   **Frontend/VR:** Unity 3D, C#
*   **Backend:** Python, Flask
*   **Infrastructure:** Docker
*   **Software Engineering:** UML, FURPS+ Analysis, Software validation strategies

### 📂 Project Structure

- `/Client` - Unity project source code and assets.
- `/Server` - Flask server scripts, `requirements.txt`, and `Dockerfile`.
- `/Docs` - Project documentation (UML, FURPS+ Requirements, Validation).

### 🚀 Setup and Installation

#### Prerequisites
- [Docker](https://www.docker.com/) installed on the host machine.
- [Unity Hub](https://unity.com/) with the appropriate editor version.

#### Running the Server (Docker)
1. Navigate to the server directory: `cd Server`
2. Build the Docker image: `docker build -t vr-caregiver-backend .`
3. Run the container: `docker run -p 5000:5000 vr-caregiver-backend`
The server will now be listening on `http://localhost:5000`.

#### Running the Client
1. Open Unity Hub and add the project by selecting the `/Client` folder.
2. Open the project in the Editor.
3. Ensure the endpoint URL in the Unity network manager points to the local server (e.g., `http://localhost:5000/api/data`).
4. Press Play in the Editor to start the simulation.

### 📊 Project Documentation
In the `Docs/` folder, you can consult the artifacts produced during the software development life cycle, specifically:
- **FURPS+ Analysis:** Functional and non-functional requirements.
- **UML:** Use case, class, and sequence diagrams.
- **Validation:** Strategies for data persistence and encoding management.

---

## <a name="italiano"></a> 🇮🇹 Italiano

Un Minimum Viable Product (MVP) di un simulatore in Realtà Virtuale progettato per sviluppare l'empatia dei caregiver. Il sistema immerge l'utente in scenari realistici, raccogliendo e analizzando i dati di interazione in tempo reale.

### 🏗 Architettura del Sistema

Il progetto è basato su un'architettura client-server disaccoppiata per garantire scalabilità e flessibilità:

*   **Client (Unity 3D):** Gestisce la simulazione VR e l'interfaccia utente. Implementa una logica di aggregazione dei dati locali prima dell'invio al server, ottimizzando così l'uso della larghezza di banda.
*   **Backend (Python/Flask):** Riceve e processa i dati dal client tramite richieste HTTP POST.
*   **Deployment:** Il server è completamente containerizzato tramite **Docker**, garantendo isolamento ambientale e massima portabilità.

### 🛠 Tecnologie Utilizzate

*   **Frontend/VR:** Unity 3D, C#
*   **Backend:** Python, Flask
*   **Infrastruttura:** Docker
*   **Ingegneria del Software:** UML, Analisi FURPS+, Strategie di validazione del software.

### 📂 Struttura del Progetto

- `/Client` - Codice sorgente e asset del progetto Unity.
- `/Server` - Script del server Flask, `requirements.txt` e `Dockerfile`.
- `/Docs` - Documentazione di progetto (UML, Requisiti FURPS+, Validazione).

### 🚀 Setup e Installazione

#### Prerequisiti
- [Docker](https://www.docker.com/) installato sulla macchina host.
- [Unity Hub](https://unity.com/) con la versione dell'editor appropriata.

#### Avviare il Server (Docker)
1. Naviga nella directory del server: `cd Server`
2. Costruisci l'immagine Docker: `docker build -t vr-caregiver-backend .`
3. Esegui il container: `docker run -p 5000:5000 vr-caregiver-backend`
Il server sarà ora in ascolto su `http://localhost:5000`.

#### Avviare il Client
1. Apri Unity Hub e aggiungi il progetto selezionando la cartella `/Client`.
2. Apri il progetto nell'Editor.
3. Assicurati che l'URL dell'endpoint nel manager di rete di Unity punti al server locale (es. `http://localhost:5000/api/data`).
4. Premi Play nell'Editor per avviare la simulazione.

### 📊 Documentazione di Progetto
Nella cartella `Docs/` è possibile consultare gli artefatti prodotti durante il ciclo di vita dello sviluppo del software, in particolare:
- **Analisi FURPS+:** Requisiti funzionali e non funzionali.
- **UML:** Diagrammi dei casi d'uso, di classe e di sequenza.
- **Validazione:** Strategie per la persistenza dei dati e la gestione delle codifiche.
