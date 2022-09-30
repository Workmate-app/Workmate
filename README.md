<p align="center"> 
  <a href="" rel="noopener">
 <img width=200px height=200px src="https://matteopiffari.github.io/assets/img/Workmate.png" alt="Workmate logo"></a>
</p>

<h3 align="center">Workmate</h3>

<div align="center">

[![Status](https://img.shields.io/badge/status-active-success.svg)]()

</div>

---

## 📝 Indice

- [Iniziare](#getting_started)
- [Uso](#usage)
  - [Home](#home)
  - [Magazzino](#magazzino)
  - [Prodotti](#prodotti)
  - [Ordini](#ordini)
  - [Clienti](#clienti)
  - [Acquisti](#acquisti)
  - [Client Server(multiutente)](#client_server)
- [Tecnologie](#tech_stack)
- [Autori](#authors)

## 🏁 Iniziare <a name = "getting_started"></a>

Per scaricare il codice sorgente basta scrivere questo in una Git bash:

```console
matteopiffari@main:~$ git clone https://github.com/Workmate-app/Workmate
```

## 🎈 Uso <a name="usage"></a>

Apri il file Workmate.exe nella directory /Workmate/bin/Release/net6.0-windows/

### Home

Nella schermata home è possibile visualizzare il numero totale degli ordini e il totale fatturato divisibile in varie fasce temporali, i codici scesi sotto la quantità minima (impostata codice per codice dall'utente durante la creazione) e varie informazioni aziendali.

### Magazzino

Nella sezione del magazzino è possibile creare i vari codici che verranno poi utilizzati per creare i prodotti e che verranno automaticamente aggiornati in base agli ordini che verranno inseriti nel seguente modo:
- Si creano i vari codici nel magazzino
- Si creano i prodotti nell'apposita sezione, inserendo la quantità di ogni codice necessaria per il prodotto
- Si crea l'ordine inserendo i vari prodotti

### Prodotti

Nella sezione prodotti è possibile inserire i vari prodotti che verranno utilizzati successivamente nella creazione degli ordini

### Ordini

Nella sezione ordini è possibile creare quest'ultimi per poi se necessario creare il <b>DDT (Documento Di Trasporto)</b> selezionando l'ordine e premendo l'apposito pulsante in alto a destra oppure premendo il tasto destro del mouse per poi selezionare "Genera bolla"

### Clienti

Nella sezione clienti è possibile creare i vari clienti a cui poi intestare i vari ordini e quindi i DDT

### Acquisti

Nella sezione acquisti è possibile aggiungere i vari acquisti relativi al materiale che poi verrà aggiornato automaticamente nel magazzino una volta inserito l'acquisto

### Client Server <a name="client_server"></a>

Per utilizzare workmate in modalità multiutente, e quindi su più postazioni, è necessario che il database dei file sia in una share accessibile ai vari utenti (per cambiare la directory del database basta andare in impostazione e selezionare l'apposito pulsante), successivamente sarà necessario installare la versione per [windows](https://github.com/Workmate-app/Workmate-Server-Windows) o per [linux](https://github.com/Workmate-app/Workmate-Server-Linux) del server tramite l'apposita repository. Una volta fatto questo bisognerà andare nelle impostazioni di workmate e abilitare l'opzione "Utilizza tipologia client/server" e immettere l'ip del server (in caso di firewall abilitare la porta 16460).


## ⛏️ Fatto con <a name = "tech_stack"></a>

- [Visual Studio](https://visualstudio.com/) - IDE
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) - Linguaggio di programmazione
- [Windows Form](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/?view=netdesktop-6.0) - UI

## ✍️ Autori <a name = "authors"></a>

- [@matteopiffari](https://github.com/matteopiffari) - Idea & Work
