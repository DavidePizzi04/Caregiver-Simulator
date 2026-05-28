# Usa una versione leggera di Python
FROM python:3.9-slim

# Crea una cartella di lavoro dentro il container
WORKDIR /app

# Installa Flask (la libreria che fa funzionare il server)
RUN pip install flask

# Copia il nostro file app.py dentro il container
COPY app.py .

# Apri la porta 5000 per far entrare i dati da Unity
EXPOSE 5000

# Comando per far partire il server
CMD ["python", "app.py"]