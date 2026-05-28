from flask import Flask, request, jsonify
from datetime import datetime

app = Flask(__name__)

@app.route('/salva_risultati', methods=['POST'])
def salva_risultati():
    dati = request.get_json()
    
    punteggio = dati.get('punteggio', 0)
    errori = dati.get('errori', 0)
    data_ora = datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    
    riga_registro = f"[{data_ora}] Simulazione completata | Punteggio Finale: {punteggio} | Errori commessi: {errori}\n"
    
    with open('registro.txt', 'a') as file:
        file.write(riga_registro)
        
    print(f"Dati salvati: {riga_registro}")
    return jsonify({"messaggio": "Dati ricevuti"}), 200

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)