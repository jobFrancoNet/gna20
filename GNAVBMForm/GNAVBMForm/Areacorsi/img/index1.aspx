<%@ Page Language="VB" AutoEventWireup="false" CodeFile="index1.aspx.vb" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" href="css/style.css" type="text/css" />
<script type="text/javascript" src="javascript/jquery.js"></script>
<script type="text/javascript" src="javascript/jquery.OptimalFadeImage.js"></script>

    <title>GUARDIA NAZIONALE AMBIENTALE - OFFICIAL WEBSITE</title>
    <script language="javascript">


    $(document).ready(function(){
					   

        var array_immagini = new Array();

        array_immagini[0]="slideshow/home_0_1.jpg";
        array_immagini[1]="slideshow/home_0_2.jpg";
        array_immagini[2]="slideshow/home_0_3.jpg";
        array_immagini[3]="slideshow/home_0_4.jpg";
        array_immagini[4]="slideshow/home_0_5.jpg";		
		

        $("#fade-uno").OptimalFadeImage({
            array_image		 : array_immagini,
            width 		 	 : 280,
            height			 : 210,
            fade_intervall	 : 'medium',
            fade_step        : 'fast',
            pause_change	 : 'slow'
	
        });
	
        var array_immagini2 = new Array();

        array_immagini2[0]="slideshow/home_1_1.jpg";
        array_immagini2[1]="slideshow/home_1_2.jpg";
        array_immagini2[2]="slideshow/home_1_3.jpg";
        array_immagini2[3]="slideshow/home_1_4.jpg";
        array_immagini2[4]="slideshow/home_1_5.jpg";

        $("#fade-due").OptimalFadeImage({
            array_image		 : array_immagini2,
            width 		 	 : 280,
            height			 : 210,
            fade_intervall	 : 'medium',
            fade_step        : 'fast',
            pause_change	 : 'slow'
	
        });

    });
</script>
</head>
<body>
    <form id="form1" runat="server">
   <div id="wrap">
	<div id="header">
		<a href="http://www.guardianazionaleambientale.eu"><img alt="GUARDIA NAZIONALE AMBIENTALE" src="img/logo.png" /></a>
	</div>
	<div id="menu-box">
			<ul id="menu">
				<li><a href="#">Home</a></li>
				<li><a href="#">Chi siamo</a>
					<ul>
						<li><a href="#">Storia</a></li>
						<li><a href="#">Missione</a></li>
						<li><a href="#">Regolamento<br/>e statuto</a></li>
						<li><a href="#">Organigramma</a></li>
						<li><a href="#">Riconoscimenti</a></li>
					</ul>
				</li>
				<li><a href="#">Dove siamo</a></li>
				<li><a href="#">Rassegna stampa</a></li>
				<li><a href="#">Galleria</a></li>
				<li><a href="#">Per i soci</a>
					<ul>
						<li><a href="#">Il gazzettino</a></li>
						<li><a href="#">Convenzioni</a></li>
						<li><a href="#">Area riservata</a></li>
					</ul>
				</li>
				<li><a href="#">Contatti</a>
					<ul>
						<li><a href="#">Iscriviti</a></li>
						<li><a href="#">Link</a></li>
						<li><a href="#">Partner</a></li>
					</ul>
				</li>
			</ul>
	</div>
	<div id="pagina">
		<div id="colonna-sx">
			<div id="news" class="border-radius">
				<h1></h1>
				<iframe id="fb-plugin" src="http://www.facebook.com/plugins/likebox.php?href=https%3A%2F%2Fwww.facebook.com%2Fpages%2FGuardia-Nazionale-Ambientale%2F247362302048406&amp;width=300&amp;height=450&amp;colorscheme=light&amp;show_faces=false&amp;header=false&amp;stream=true&amp;show_border=false" scrolling="no" frameborder="0" style="border:none; overflow:hidden; width:300px; height:450px;" allowTransparency="true"></iframe>
				<a href="#">Clicca qui</a> per conoscere tutte le ultime news dai nostri distaccamenti!
				</div>
			<div id="iscriviti" class="border-radius">
				<h1></h1>
				<p>Vuoi entrare a far parte della GNA? Lascia il tuo indirizzo email e ti verrà inviato il modulo di iscrizione. Se non siamo presenti nella tua zona puoi riprovare in futuro o <a href="#">contattarci</a>.</p>
				<div id="casella-mail"><input type="text" size="43" value="&nbsp;La tua email qui" style="color: #808080;"/></div>
				<a href="#"><img src="img/pulsante.png" vspace="8" hspace="70"></a>
			</div>
		</div>
		<div id="colonna-dx">
			<div id="in-evidenza" class="border-radius">
				<h1></h1>
				<div id="in-evidenza-testo"><b>Sito in ristrutturazione</b><br/><br/>La nuova versione del sito della GNA è in fase di sviluppo. Nuove funzioni sono già state introdotte nell'area riservata, e stiamo testando la nuova grafica che potete già visualizzare in homepage e che verrà presto completata ed estesa anche alle altre pagine del sito.<br/>
<br/>
Questa ristrutturazione si pone come obiettivo un miglioramento non soltanto in termini estetici, nonostante si sia cercato di ottenere un risultato apprezzabile anche in questo senso, ma soprattutto in termini di organizzazione dei contenuti e fruibilità degli stessi sia dagli utenti occasionali sia da quelli autorizzati. Abbiamo puntato anche sulla sicurezza di gestione dei dati e sulla rapidità e correttezza delle procedure, compresa quella relativa alla posizione degli associati.<br/>
<br/>
Il sistema gestionale che stiamo implementando consentirà all'utente di:<br/>
- visualizzare gli automezzi e gli equipaggiamenti individuali (divise, insegne di incarico, mostreggiatura, distintivi, ecc.) disponibili ed effettuare la relativa richiesta direttamente online<br/>
- stampare i propri tesserini, dotati di un sistema anticontraffazione<br/>
- gestire e programmare i servizi, rendendoli direttamente pubblici e specificandone date e luoghi, ed effettuare la redazione della relativa documentazione di servizio<br/>
<br/>
Fintanto che i lavori saranno ancora in corso potrebbero verificarsi dei disservizi e non tutto potrebbe funzionare correttamente. Vi invitiamo a consultare giornalmente il sito per restare aggiornati sull'implementazione delle nuove funzionalità, e a segnalarci eveventuali malfunzionamenti.<br/>
<br/>
Buon lavoro a tutti!<br/>
<br/>
<div align="right"><i>Il presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
</div>
			</div>
			<div id="scopri-gna" class="border-radius">
				<h1></h1>
				<div id="scopri-gna-testo"><div id="fade-uno"></div><div id="fade-due"></div>L'Associazione "Guardia Nazionale Ambientale" nasce nel 2001 a Terni, con lo scopo di dare origine ad un organismo democratico con un duplice obiettivo: l'aggregazione di donne ed uomini che in forma democratica ed attenti ai dettami della Legge 266/1991, si confrontano e si uniscono per la salvaguardia dell'ambiente. Parimenti, un'organizzazione dotata di un organigramma di tipo piramidale, attenta al rispetto dei singoli ruoli, fatta di volontari che, liberamente e senza alcuna differenza, hanno scelto di dedicare una parte del proprio tempo libero agli altri e alla natura in tutte le sue espressioni.<br/><br/>Scopri la <a href="#">storia</a> della GNA, la nostra <a href="#">missione</a> e il <a href="#">regolamento</a> in vigore!</div>
			</div>
		</div>
	</div>
	<div id="footer">
		<div class="footer-colonna">
		<ul>
		<li><a href="#">Home</a></li>
		<li>Chi siamo
			<ul>
			<li><a href="#">Storia</a></li>
			<li><a href="#">Missione</a></li>
			<li><a href="#">Regolamento e statuto</a></li>
			<li><a href="#">Organigramma</a></li>
			<li><a href="#">Riconoscimenti</a></li>
			</ul>
		</li>
		<li><a href="#">Dove siamo</a></li>
		<li><a href="#">Rassegna stampa</a></li>
		<li><a href="#">Galleria</a></li>
		<li>Per i soci
			<ul>
			<li><a href="#">Il gazzettino</a></li>
			<li><a href="#">Convenzioni</a></li>
			<li><a href="#">Area riservata</a></li>
			</ul>
		</li>
		<li>Contatti
			<ul>
			<li><a href="#">Iscriviti</a></li>
			<li><a href="#">Link</a></li>
			<li><a href="#">Partners</a></li>
			</ul>	
		</li>
		</ul>
		</div>
		<div class="footer-colonna">
		<b>Guardia Nazionale Ambientale</b><br/>
		<br/>
		Sede Nazionale:<br/>
		Via Scarpanto 64, 00139 Roma <br/>
		<br/>
		Ufficio di Presidenza:<br/>
		Via Tre Venezie 162/66, 05100 Terni (TR)<br/>
		<br/>
		<br/>
		<table border="0" cellpadding="0" cellspacing="0" style="color: #ffffff; font-size: 13px;">		
		<tr>
			<td style="padding-right: 5px;"><a href="http://www.facebook.com/pages/Guardia-Nazionale-Ambientale/247362302048406" target="_blank"><img src="img/icona-fb.png"></a></td>
			<td style="padding-right: 5px;"><a href="mailto:presidenza@guardianazionaleambientale.eu"><img src="img/icona-mail.png"></a></td>
			<td style="padding-right: 5px;"><a href="#"><img src="img/icona-sitemap.png"></a></td>
		</tr>
		</table>
		</div>
		<div class="footer-colonna">
		<table border="0" cellpadding="0" cellspacing="0" style="color: #ffffff; font-size: 13px;">		
		<tr>
			<td>Cerca nel sito:</td>
		</tr>
		<tr>
			<td valign="center"><div id="casella-ricerca"><input type="text" size="25" value="&nbsp;Cerca..." style="color: #808080;"/></div></td>
			<td style="padding-left: 10px;"><a href="#"><img src="img/icona-cerca.png"></a></td>
		</tr>
		</table>
		<br/>
		<br/>
		<a href="http://www.guardianazionaleambientale.eu"><u>www.guardianazionaleambientale.eu</u></a><br/>
		<br/>
		Webmaster: Aldo Facchini<br/>
		Webdesign: Francesca Conti<br/>
		<br/>		
		Copyright 2014<br/>
		Tutti i diritti riservati
		</div>
	</div>
</div>
    </form>
</body>
</html>
