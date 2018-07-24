# DropboxClient
Accedere al sito relativo a dropbox developer all'indirizzo https://www.dropbox.com/developers/apps
Creare una nuova app con un nome qualsiasi (nel mio caso ho usato RW_MyDP) Ecco l'immagine della creazione della App:
![dp2](https://user-images.githubusercontent.com/8326495/43132362-d33254d2-8f3b-11e8-909c-cfbabb36f458.png)

Annotate l'ID della App e il Secret. Inoltre componete correttamente la url di ritorno come di seguito
http://localhost:port-number/Home/Auth sostituendo la vostra porta come evidente dalle proprietà del progetto VS2017
![dp3](https://user-images.githubusercontent.com/8326495/43132518-5dccc6ea-8f3c-11e8-93e7-917192fb364f.png)

Dalla stessa schermata di creazione Generate un Access Token e annotatelo anch'esso.
Create la app e visualizzate la conferma dalla lista delle app del vostro account 
![dp1](https://user-images.githubusercontent.com/8326495/43132019-ccb71bb6-8f3a-11e8-80cf-cfaffeeb7bdc.png)

###Uso del client
Aggiornare il Web Config con l'ID della App e il suo Secret. Aggiornare inoltre la riga di codice nel DBManagerController dove si imposta l'accesstoken.
A questo punto avviare l'applicazione, registrarsi come utente dell'applicazione e connettersi al Dropbox. 
Scegleire una cartella ( o crearne una) e fare l'upload dei files.
