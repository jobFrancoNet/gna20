<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="Default.aspx.vb" Inherits="GNAVBMForm._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">  
        <script type="text/javascript" src="javascript/jquery.js"></script>

 <script type="text/javascript">
     var array_immagini = new Array();

            array_immagini[0] = "slideshow/home_0_1.jpg";
            array_immagini[1] = "slideshow/home_0_2.jpg";
            array_immagini[2] = "slideshow/home_0_3.jpg";
            array_immagini[3] = "slideshow/home_0_4.jpg";
            array_immagini[4] = "slideshow/home_0_5.jpg";


            

            var cnt = array_immagini.length;

                 var array_immagini2 = new Array();

            array_immagini2[0] = "slideshow/home_1_1.jpg";
            array_immagini2[1] = "slideshow/home_1_2.jpg";
            array_immagini2[2] = "slideshow/home_1_3.jpg";
            array_immagini2[3] = "slideshow/home_1_4.jpg";
            array_immagini2[4] = "slideshow/home_1_5.jpg";

           

            var cnt1 = array_immagini2.length;

     //      var conta = 0;

     //var array_immagini_corso = new Array();
     //array_immagini_corso[0] = "slideshow/locandina1.jpg";
     //array_immagini_corso[1] = "slideshow/Locandina2.jpg";
     //array_immagini_corso[2] = "slideshow/Locandina3.jpg";
     //array_immagini_corso[3] = "slideshow/Locandina4.jpg";
     //array_immagini_corso[4] = "slideshow/Locandina5.jpg";
     //array_immagini_corso[5] = "slideshow/Locandina6.jpg";

     //var cnt2 = array_immagini_corso.length;


        $(document).ready(function () {


            
             $(function() {
                 setInterval(Slider, 5000);
                 //setInterval(SlideCorso, 5000);
            });

                
     });

    // function SlideCorso()
    // {
    //      $("#imgslidecorsi").show("slow", function() {
    //    $(this).attr("src", array_immagini_corso[(array_immagini_corso.length++) % cnt2]).show();

    //    conta = conta + 1;
    //    if (conta == 1) {
           
    //        $("#link2").attr("href", "DetailsPageCorso.aspx");
    //    }
    //    else {
    //        $("#link2").attr("href", "#");
             
    //    }

    //    if (conta ==6)
    //    {
    //        conta = 0
           
    //    }

    //});
        
    //   }

        function Slider() {
    $("#imageSlide").show("slow", function() {
        $(this).attr("src", array_immagini[(array_immagini.length++) % cnt]).show();

       
    });
         $("#imageSlide1").show("slow", function() {
       $(this).attr("src", array_immagini2[(array_immagini2.length++) % cnt1]).show();
    });
        }

      
     </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="pagina">
        <asp:Panel ID="InfoCookiePanel" runat="server">
            <div id="info-cookie" class="border-radius">
            <asp:ImageButton ID="ImageButton2" runat="server" ImageAlign="Right" ImageUrl="~/images/chiudi_btn.png"  OnClick="ImageButton2_Click" /><br />
            <b>Info Cookie</b><br />
            Questo sito utilizza solo cookie tecnici e cookie di terze parti per il contatore delle visite, utilizzando questo sito si accetta l&#39;uso degli stessi. Non vengono usati cookie di profilazione dal titolare del sito. Per ulteriori dettagli clicca su
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/privacy-policy.aspx">Privacy Policy</asp:HyperLink>
            .<br /></div>
        </asp:Panel>
	<div id="colonna-sx">
				<div class="box-evidenza box-colonna-sx border-radius" style="text-align:center">
				<h1>SOSTIENI LA GNA</h1>
				<b>Vuoi aiutarci</b> a portare avanti i nostri progetti? Puoi farlo una sola volta oppure periodicamente anche ogni mese, <b>donando l'importo che preferisci</b> tramite Paypal.<br/>
		<br/>
               
               <a href="https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=5Z4GAUVQWCDZU"><img src="https://www.paypalobjects.com/it_IT/IT/i/btn/btn_donateCC_LG.gif" border="0" name="s  ubmit" alt="PayPal è il metodo rapido e sicuro per pagare e farsi pagare online." /></a>
                <img alt="" border="0" src="https://www.paypalobjects.com/it_IT/i/scr/pixel.gif" width="1" height="1">
              
              
                    
            		</div>
			<div id="news" class="border-radius">
				<h1>NEWS</h1>
				<iframe id="fb-plugin" src="http://www.facebook.com/plugins/likebox.php?href=https%3A%2F%2Fwww.facebook.com%2Fpages%2FGuardia-Nazionale-Ambientale%2F247362302048406&amp;width=300&amp;height=450&amp;colorscheme=light&amp;show_faces=false&amp;header=false&amp;stream=true&amp;show_border=false" scrolling="no" frameborder="0" style="border:none; overflow:hidden; width:300px; height:450px;" allowTransparency="true"></iframe>
				<a href="social.aspx">Guarda le pagine dei distaccamenti</a>
				</div>
			<div id="iscriviti" class="border-radius">
				<h1>ISCRIVITI</h1>
				<p><b>Vuoi entrare a far parte della GNA?</b> Lascia il tuo indirizzo email e ti verrà inviato il modulo di iscrizione. Se non siamo presenti nella tua zona puoi riprovare in futuro o <a href="mailto:segreteria@guardianazionaleambientale.eu">contattarci</a>.</p>
				
                <div id="casella-mail"><asp:TextBox ID="txt_email" Width="280px" runat="server" ForeColor="Gray" AutoCompleteType="Email" onclick="this.value='';" Height="23px">&nbsp;La tua email qui</asp:TextBox></div>
		<div id="pulsante"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/pulsante.png" BorderColor="#000066" BorderStyle="None" ValidationGroup="1" /></div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_email" ErrorMessage="Email non valida" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="1"></asp:RegularExpressionValidator>
			</div>
			<!-- <div id="controllo-tessere-prova" class="border-radius">
			<h1>CONTROLLO TESSERINI</h1>
			In quest'area è possibile controllare l'autenticità dei tesserini dei funzionari GNA tramite l'inserimento del codice anticontraffazione univoco presente esclusivamente sui tesserini regolamentari. <br/>
<br/>
L'uso del sistema di controllo è riservato alle Forze dell'Ordine e ai dirigenti GNA. Qualsiasi uso non autorizzato sarà segnalato alle Autorità competenti.<br/>
<br/>
<a href="in_costruzione.aspx">Accedi all'area controllo tesserini</a>
			</div> -->
			<!-- <div id="link" class="border-radius">
			<h1>LINK UTILI</h1>
<a href="http://www.palazzochigi.it/" target="_blank">Governo Italiano</a><br/>
<a href="http://www.senato.it/" target="_blank">Senato della Repubblica</a><br/>
<a href="http://www.camera.it/" target="_blank">Camera dei Deputati</a><br/>
<a href="http://www.interno.it/" target="_blank">Ministero dell'Interno</a><br/>
<a href="http://www.difesa.it/" target="_blank">Ministero della Difesa</a><br/>
<a href="http://www.minambiente.it/" target="_blank">Ministero dell'Ambiente</a><br/>
<a href="http://www.esteri.it/" target="_blank">Ministero degli Esteri</a><br/>
<a href="http://www.protezionecivile.it/" target="_blank">Protezione Civile</a><br/>
<a href="http://www.vigilfuoco.it/" target="_blank">Vigili del Fuoco</a><br/>
<a href="http://www.guardiacostiera.it/" target="_blank">Guardia Costiera</a><br/>
			</div> -->
			<div id="contatore" class="border-radius">
                <!-- Histats.com  START  (standard)-->
<script type="text/javascript">document.write(unescape("%3Cscript src=%27http://s10.histats.com/js15.js%27 type=%27text/javascript%27%3E%3C/script%3E"));</script>
<a href="http://www.histats.com" target="_blank" title="histats.com" ><script  type="text/javascript" >
                                                                          try {
                                                                              Histats.start(1, 2629252, 4, 4007, 112, 61, "00011111");
                                                                              Histats.track_hits();
                                                                          } catch (err) { };
</script></a>
<noscript><a href="http://www.histats.com" target="_blank"><img  src="http://sstatic1.histats.com/0.gif?2629252&101" alt="histats.com" border="0"></a></noscript>
<!-- Histats.com  END  --> 
			</div>
		</div>
		<div id="colonna-dx">
			<div id="in-evidenza" class="border-radius">
				<h1>IN EVIDENZA</h1>
				<div id="in-evidenza-testo">


<b>Decreto di Iscrizione al Registo Regionale del Volontariato della Regione Lombardia</b>
<br/>

Cari Colleghi, con vivo piacere sono ad annunciarvi un altro importante traguardo raggiunto dalla nostra amata Guardia Nazionale Ambientale, ovvero il Decreto di Iscrizione al Registro del Volontariato della Regione Lombardia.
Segno che, se si opera, uniti, in sinergia e nel rispetto delle regole, si arriva al traguardo presto e bene.
<br/>
<b>Un caro saluto a tutti</b>
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<hr>
<br/>
<br/>

<b>Nuova circolare</b>
<br/>
<br/>
E' stata diramata la circolare n. 004/2016, disponibile a <a href="http://guardianazionaleambientale.eu/stor_circol.aspx">questo indirizzo</a> (occorre accedere all'area riservata), relativa agli equipaggiamenti individuali.
<br/>
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<hr>
<br/>
<br/>

<b>Nuova circolare</b>
<br/>
<br/>
E' stata diramata la circolare n. 003/2016, disponibile a <a href="http://guardianazionaleambientale.eu/stor_circol.aspx">questo indirizzo</a> (occorre accedere all'area riservata), relativa al rinnovo delle quote associative.
<br/>
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<hr>
<br/>
<br/>






<a href="in_costruzione.aspx">Visualizza tutte le news</a>
<!--
<b>Nuova circolare</b>
<br/>
<br/>
E' stata diramata la circolare n. 002/2016, disponibile a <a href="http://guardianazionaleambientale.eu/stor_circol.aspx">questo indirizzo</a> (occorre accedere all'area riservata), relativa alla procedura automezzi di servizio.
<br/>
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<hr>
<br/>
<br/>


<b>Nuova circolare</b>
<br/>
<br/>
E' stata diramata la circolare n. 001/2016, disponibile a <a href="http://guardianazionaleambientale.eu/stor_circol.aspx">questo indirizzo</a> (occorre accedere all'area riservata), relativa all'ultimo avviso per la regolarità della quota associativa.
<br/>
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<hr>
<br/>
<br/>
b>Decreto del Ministero dell'Ambiente</b>
<br/>
<br/>
Cari Colleghi,<br>
è con grandissima emozione che mi appresto, finalmente, a farvi questa comunicazione. In data odierna, ho ricevuto a mezzo posta elettronica certificata, la comunicazione del Segretario Generale del Ministero dell’Ambiente Consigliere Antonio Agostini, con la quale mi ha comunicato ufficialmente il riconoscimento da parte del predetto Dicastero ai sensi dell’art. 13 della Legge 349/1986 della nostra amata Associazione, quindi è con il massimo orgoglio che vi comunico ufficialmente che:
<br/><br>LA GUARDIA NAZIONALE AMBIENTALE E’ UFFICIALMENTE RICONOSCIUTA DAL MINISTERO DELL’AMBIENTE<br/><br/>
ai sensi dell’art. 13 della Legge 349/1986 come si evince dal Decreto dal Sig. Ministro dell’Ambiente n 0000110 del 29/04/2016, allegato alla presente e pubblicato nell’area riservata del sito istituzionale.<br>
Ancora una volta abbiamo dimostrato di essere una grande squadra ed  è stato svolto un lavoro, senza precedenti, che ha consentito alla nostra Organizzazione di incidere sensibilmente sui processi autorizzativi del predetto Dicastero. <br>
Nonostante alcuni si siano impegnati non poco per remarci contro, abbiamo dimostrato, con i fatti chi siamo, e con la massima determinazione siamo giunti ad un prestigiosissimo traguardo che, secondo alcuni, non avremmo mai raggiunto. <br>
Siamo una grande squadra ed ora, più che mai, ci aspetta un grande lavoro con l’intento di strutturare un’azione più qualificata ed incisiva che ci consenta di dimostrare, a cominciare da noi stessi e per finire a tutti coloro che ci osservano dall’esterno, di che pasta sono fatti i VOLONTARI DELLA GUARDIA NAZIONALE AMBIENTALE! <br/><br/>
Nei prossimi giorni ci saranno importanti comunicazioni relative alle diverse convocazioni dei Sig.ri Dirigenti e funzionari prima per poi ritrovarci tutti insieme a festeggiare il prestigiosissimo traguardo raggiunto che oggi ho il piacere e l’onore di comunicare con la presente, pertanto invito tutti a prestare massima attenzione agli strumenti di comunicazione istituzionali, cogliendo con tempestività le informazioni che andremo a trasmettere.<br/><br/>

Mai come oggi ho avvertito l’onore ed il piacere di essere il vostro Collega, Presidente e Dirigente Generale Superiore, con l’occasione vi invio un caro e cordiale saluto.
<br/>
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<hr>
<br/>
<br/>
<b>Nuova circolare</b>
<br/>
<br/>
E' stata diramata la circolare n. 007/2015, disponibile a <a href="http://guardianazionaleambientale.eu/stor_circol.aspx">questo indirizzo</a> (occorre accedere all'area riservata), relativa al rinnovo della quota assciativa per l'anno 2016.
<br/>
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<hr>
<br/>
<br/>
<b>Decreto di Iscrizione al Registo Regionale del Volontariato della Regione Abruzzo</b>
<br/>
<br/>
Carissimi Colleghi,<br>
mi scuso per il ritardo nella comunicazione ma, come tutti ben saprete, alcuni problemi di salute mi hanno impedito di poter condividere con voi un altro grande traguardo per la Guardia Nazionale Ambientale. <br>
In data 5 agosto 2015 abbiamo ottenuto il Decreto di Iscrizione al Registro Regionale del Volontariato della Regione Abruzzo.<br>
Si tratta del 4° riconoscimento ottenuto nel giro di un paio di mesi, segno che, se si lavora con passione e nel rispetto delle regole, si possono raggiungere obiettivi importanti.<br>
A tale proposito mi complimento con il Dirigente Regionale dell'Abruzzo, Luigi Di Benedetto, e con tutta la sua squadra che, unita e rispettosa dei ruoli, è determinata ad affermare con orgoglio l'inestimabile azione che ogni volontario della Guardia Nazionale Ambientale svolge quotidianamente.
<br/>
Un caro saluto a tutti
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<br/>
<br/>
</br><b>Decreto di Iscrizione al Registo Regionale del Volontariato della Regione Abruzzo</b>
<br/>
<br/>
Carissimi Colleghi,<br>
mi scuso per il ritardo nella comunicazione ma, come tutti ben saprete, alcuni problemi di salute mi hanno impedito di poter condividere con voi un altro grande traguardo per la Guardia Nazionale Ambientale. <br>
In data 5 agosto 2015 abbiamo ottenuto il Decreto di Iscrizione al Registro Regionale del Volontariato della Regione Abruzzo.<br>
Si tratta del 4° riconoscimento ottenuto nel giro di un paio di mesi, segno che, se si lavora con passione e nel rispetto delle regole, si possono raggiungere obiettivi importanti.<br>
A tale proposito mi complimento con il Dirigente Regionale dell'Abruzzo, Luigi Di Benedetto, e con tutta la sua squadra che, unita e rispettosa dei ruoli, è determinata ad affermare con orgoglio l'inestimabile azione che ogni volontario della Guardia Nazionale Ambientale svolge quotidianamente.
<br/>
Un caro saluto a tutti
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<br/>
<b>Decreto di Iscrizione al Registo Regionale del Volontariato della Regione Toscana</b>
<br/>
<br/>
Cari Colleghi, con vivo piacere sono ad annunciarvi un altro importante traguardo raggiunto dalla nostra amata Guardia Nazionale Ambientale, ovvero il Decreto di Iscrizione al Registro del Volontariato della Regione Toscana.
Nonostante gli ostacoli incontrati lungo il cammino, il Responsabile Regionale della Toscana nella persona del Dr. Andrea Aquino ha operato sapientemente per il raggiungimento di questo eccellente risultato. A lui e a tutta la sua squadra, composta da ragazze e ragazzi capaci, determinati, uniti e rispettosi delle regole, rivolgo le mie più sincere congratulazioni.
<br/>
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<br/>
<b>Nuova circolare</b>
<br/>
<br/>
E' stata diramata la circolare n. 006/2015, disponibile a <a href="http://guardianazionaleambientale.eu/stor_circol.aspx">questo indirizzo</a> (occorre accedere all'area riservata), relativa all'integrazione della disposizione di servizio 008 - 2014 per le nuove quote associative
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<hr>
<br/>
<br/>
<hr>
<b>Decreto del Dirigente del Servizio Ambiente e Agricoltura Regione Marche</b>
<br/>
<br/>
Cari Colleghi, è con immenso piacere che Vi comunico l'iscrizione delle Guardia Nazionale Ambientale nel Registro regionale del Volontariato - sezione "Tutela e valorizzazione ambientale" della Regione Marche.<br/>
Un altro importante traguardo per la nostra Organizzazione, segno che, se si opera, uniti, in sinergia e nel rispetto delle regole, si arriva al traguardo presto e bene.<br/>
Complimenti alla Dirigenza Nazionale e alla Dirigenza Regionale delle Marche.
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<hr>
<br/>
<b>Nuova circolare</b>
<br/>
<br/>
E' stata diramata la circolare n. 005/2015, disponibile a <a href="http://guardianazionaleambientale.eu/stor_circol.aspx">questo indirizzo</a> (occorre accedere all'area riservata), relativa alla campagna del 5 x mille.
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>

<hr>
<br/>
<br/>
<b>Nuova circolare</b>
<br/>
<br/>
E' stata diramata la circolare n. 004/2015, disponibile a <a href="http://guardianazionaleambientale.eu/stor_circol.aspx">questo indirizzo</a> (occorre accedere all'area riservata), relativa alla riorganizzazione dell'ufficio stampa della Guardia Nazionale Ambientale.
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<b>Nuova circolare e sollecito</b>
<br/>
<br/>
E' stata diramata la circolare n. 003/2015, disponibile a <a href="http://guardianazionaleambientale.eu/stor_circol.aspx">questo indirizzo</a> (occorre accedere all'area riservata), relativa alle modifiche da apportare riguardo la gestione delle pagine Facebook della Guardia Nazionale Ambientale.
<br/>
<br/>
Si ricorda inoltre ai Dirigenti e Responsabili che rientra tra i loro compiti quello di tenersi regolarmente informati, e informare a loro volta quando necessario i soci iscritti nei Distaccamenti di loro competenza, riguardo tutto quanto viene comunicato dall'Ufficio di Presidenza, sia tramite il presente spazio news che tramite le email inviate agli indirizzi di servizio.<br/>
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<br/>
<b>Campagna 5 x mille</b>
<br/>
<br/>
Ricordiamo che è possibile, al momento della presentazione del modello 730, destinare il proprio 5 x mille alla Guardia Nazionale Ambientale. Per i Dirigenti e i Responsabili, è stata diramata a tal proposito la circolare n. 002/2015, disponibile a <a href="http://guardianazionaleambientale.eu/stor_circol.aspx">questo indirizzo</a> (occorre accedere all'area riservata); per gli associati e i simpatizzanti, è possibile scaricare l'apposito <a href="/img/5xmille.jpg">volantino</a>. Stiamo inoltre lavorando a una pagina dedicata, che sarà online nei prossimi giorni, al fine di ringraziare e dare la giusta visibilità a chi vorrà contribuire. <br/> 
<br/>
Invitiamo chiunque desideri a sostenere e pubblicizzare insieme a noi l'iniziativa, con l'obiettivo di darle la massima diffusione.<br/>
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<br/>
<b>Nuova circolare</b>
<br/>
<br/>
E' stata diramata la circolare n.001/2015, disponibile a <a href="http://guardianazionaleambientale.eu/stor_circol.aspx">questo indirizzo</a> (occorre accedere all'area riservata), riguardante il nuovo formulario per l'assegnazione degli equipaggiamenti individuali.<br/>
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<br/>
<hr>
<br/>
<b>Nuova circolare</b>
<br/>
<br/>
Si comunica che è stata diramata la circolare n. 009/2014, disponibile a <a href="http://guardianazionaleambientale.eu/stor_circol.aspx">questo indirizzo</a> (occorre accedere all'area riservata) e riguardante le disposizioni in merito alle assicurazioni degli automezzi di servizio.<br/>
<br/>
I Dirigenti e i Responsabili di Distaccamento sono caldamente invitati a prenderne visione.<br/>
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<br/>
<hr>
<br/>
<b>Comunicazione</b>
<br/>
<br>
Come la maggior parte di voi già saprà, il nostro Presidente e Dirigente Generale Superiore ha avuto un malore, con molta probabilità dovuto all'eccessivo carico di stress. E' ricoverato presso l'ospedale di Terni e ora è in piena ripresa; è probabile che venga dimesso nella giornata di <s>mercoledì o giovedì</s> (AGGIORNAMENTO: venerdì o sabato). <br/><br/>Chi volesse maggiori informazioni o le coordinate per fargli visita può telefonare al numero 0744 062106; chi vuole fargli un saluto può indirizzare una mail a segreteria@guardianazionaleambientale.eu.<br/>
<br/>
<div align="right"><i>La Segreteria di Presidenza</i></div>
<br/>
<hr>
<br/>
<b>Nuove circolari</b>
<br/>
<br>
Si comunica che sono state diramate le circolari n. 006/2014, 007/2014 e 008/2014, disponibili a <a href="http://guardianazionaleambientale.eu/stor_circol.aspx">questo indirizzo</a> (occorre accedere all'area riservata) e riguardanti la procedura di rinnovo iscrizione per l'anno 2015, la rideterminazione e redistribuzione delle quote associative alle sedi periferiche, e le nuove funzionalità dell'area riservata inerenti l'inserimento dei soci e la relativa documentazione.<br/>
<br/>
I Dirigenti e i Responsabili di Distaccamento sono caldamente invitati a prenderne visione.<br/>
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<a href="in_costruzione.aspx">Visualizza tutte le news</a>
<br/>
<br/>
<hr>
<br/>
<b>Chiusura segreteria per sciopero</b>
<br/>
<br/>
Nella giornata di venerdì 17 ottobre 2014 l'ufficio della Segreteria di Presidenza rimarrà chiuso, come forma di adesione allo sciopero generale indetto dalle segreterie sindacali della provincia di Terni al fine di evitare l'applicazione del Piano Industriale TyssenKrupp e la cancellazione della storia delle nostre acciaierie. Il forte ridimensionamento e la possibile futura chiusura avrebbero pesantissime ricadute occupazionali, causando ripercussioni economiche sull'intera nazione. <br/>
<br/>
La Guardia Nazionale Ambientale partecipa alla mobilitazione generale della comunità ternana in difesa del tessuto economico e produttivo e del lavoro di questa città e dell'Italia tutta, auspicando che questa iniziativa sia foriera di elementi positivi tali da salvare le 550 famiglie, le circa 3000 pesrone interessate, la grande eccellenza in campo internazionale della città di Terni, e confida nel sostegno e nella comprensione degli iscritti.<br/>
<br>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<br/>
<hr>
<br/>
<b>Iscrizione al Registro Regionale Generale delle ODV della Regione Siciliana</b>
<br/>
<br/>Si comunica il riconoscimento della nostra Organizzazione dalla Regione Siciliana con la conseguente iscrizione nel Registro Generale Regionale delle Organizzazioni di Volontariato istituito presso la medesima Regione.<br/> 
<br/>
Il raggiungimento di questo obiettivo, unito ai precedenti, conferma la bontà, correttezza, genuinità della nostra amata Guardia Nazionale Ambientale, ovvero l'assoluta aderenza alle Leggi e normative vigenti dell'operato della Classe Dirigente che ne sta alla guida e che mi onoro di rappresentare come massima espressione. Identico risultato è stato raggiunto, lo scorso luglio, nella Regione Umbria, che ha provveduto a reiscrivere la nostra Organizzazione nei Registri Regionali. Ambedue le procedure, attivate, seguite e sostenute da me personalmente, sono state gestite nella logica secondo la quale devono emergere i fatti concreti ancor prima delle parole e che quando si crede in un obiettivo e si sostiene umilmente ma con decisione, chiedendo supporto agli amici e confrontandosi serenamente con gli organi deliberanti, i risultati, prima o poi, si vedono!<br/>
<br/>
Rimango nella piena convinzione che i tra i pochi mesi che rimangono del corrente anno e quelli di inizio del prossimo si concretizzeranno ulteriori riconoscimenti in ambito regionale, nazionale e internazionale, perfezionando così i copiosi e, consentitemi il termine, "pachidermici" iter avviati e sostenuti in questi anni, completando tutta la rosa di autorizzazioni a cui un'Organizzazione come la nostra può ambire.<br/>
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<br/>
<hr>
<br/>
<b>Arrivederci Giovan Battista</b><br/><br/><div align="center"><img src="http://www.guardianazionaleambientale.eu/public/foto/cannizzaro%20giovanni.jpg"></div><br/><br/><b>Il Presidente e la Guardia Nazionale Ambientale tutta si uniscono al cordoglio per la perdita del carissimo Giovan Battista Cannizzaro, Assistente Capo della Guardia Nazionale Ambientale, ineguagliabile volontario della nostra Organizzazione, instancabile guardiano dei valori e della vita, più volte decorato per le plurime azioni di grandissimo valore sociale messe in campo. Mancherà moltissimo a tutti noi, e le nostre più sentite condoglianze vanno alla sua famiglia e a tutti i suoi cari.<br/><br/>Quanti volessero porgere condoglianze personali possono farlo alla mail distaccamento.ardea@guardianazionaleambientale.eu.<br/><br/>Le esequie avranno luogo ad Ardea, presso la chiesa di Tor San Lorenzo, nella giornata di domani 21 agosto 2014 alle ore 15.00, ove sarà presente una delegazione ufficiale della Guardia Nazionale Ambientale. Il Presidente invita tutti gli aderenti che ne abbiano la possibilità a presenziare in divisa e con l'auto di servizio al fine di onorare il nostro caro collega scomparso.<br/><br/> Giovan Battista, è stato un onore aver operato tutti questi anni insieme a te, il tuo ricordo rimarrà impresso nei nostri cuori, il Signore ti accolga fra le sue braccia. Un caro saluto.</b><br/>
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<hr>
<br/>
<b>Chiusura estiva segreteria</b><br/><br/>La Segreteria di Presidenza rimarrà chiusa dal 15 al 31 agosto, e riprenderà la sua normale attività lunedì 1 settembre. <br/><br/>Un augurio di buone vacanze e buon Ferragosto, agli iscritti come ai visitatori, dal Presidente e dal personale di segreteria tutto.<br/>
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div>
<br/>
<hr>
<br/>
<b>Sito in ristrutturazione</b><br/><br/>La nuova versione del sito della GNA è in fase di sviluppo. Nuove funzioni sono state introdotte nell'area riservata e stiamo testando la nuova grafica, che potete già visualizzare.<br/>
<br/>
Questa ristrutturazione si pone come obiettivo un miglioramento non soltanto in termini estetici, nonostante si sia cercato di ottenere un risultato apprezzabile anche in questo senso, ma soprattutto in termini di organizzazione dei contenuti e fruibilità degli stessi sia dagli utenti occasionali sia da quelli autorizzati. Abbiamo puntato anche sulla sicurezza di gestione dei dati e sulla rapidità e correttezza delle procedure, compresa quella relativa alla posizione degli associati.<br/>
<br/>
Il sistema gestionale che stiamo implementando consentirà all'utente di:<br/>
- visualizzare gli automezzi e gli equipaggiamenti individuali (divise, insegne di incarico, mostreggiatura, distintivi, ecc.) disponibili ed effettuare la relativa richiesta direttamente online<br/>
- stampare le proprie tessere, dotate di un sistema anticontraffazione<br/>
- gestire e programmare i servizi, rendendoli direttamente pubblici e specificandone date e luoghi, ed effettuare la redazione della relativa documentazione di servizio<br/>
<br/>
Fintanto che i lavori saranno ancora in corso potrebbero verificarsi dei disservizi e non tutto potrebbe funzionare correttamente. Vi invitiamo a consultare giornalmente il sito per restare aggiornati sull'implementazione delle nuove funzionalità, e a segnalarci eveventuali malfunzionamenti.<br/>
<br/>
Buon lavoro a tutti!<br/>
<br/>
<div align="right"><i>Il Presidente<br/>
Dr. Cav. Alberto Raggi</i></div> -->
			</div>
			</div>
            <div id="scopri-gna" class="border-radius">
                <h1>NEW AREA CORSI</h1>
                <iframe src="slideshowcorsi.aspx" width="300" height="450" style="border:none;overflow:auto"  />
                <%--<div id="scopri-gna-testo"><div id="fade-uno"><a href="#" id="link2"><img id="imgslidecorsi" alt="" src="slideshow/locandina1.jpg" /></a>
                    </div>

                    </div>
            </div>--%>
			<div id="scopri-gna" class="border-radius">
				<h1>SCOPRI LA GNA</h1>
				<div id="scopri-gna-testo"><div id="fade-uno"><img id="imageSlide" alt="" src="slideshow/home_0_1.jpg" /></div><div id="fade-due"><img id="imageSlide1" alt="" src="slideshow/home_1_1.jpg" /></div>L'Associazione "Guardia Nazionale Ambientale" nasce nel 2001 a Terni, con lo scopo di dare origine ad un organismo democratico con un duplice obiettivo: l'aggregazione di donne ed uomini che in forma democratica ed attenti ai dettami della Legge 266/1991, si confrontano e si uniscono per la salvaguardia dell'ambiente. Parimenti, un'organizzazione dotata di un organigramma di tipo piramidale, attenta al rispetto dei singoli ruoli, fatta di volontari che, liberamente e senza alcuna differenza, hanno scelto di dedicare una parte del proprio tempo libero agli altri e alla natura in tutte le sue espressioni.<br/><br/><a href="storia.aspx">Scopri di più sulla GNA</a></div>
			</div>
			<div id="controllo-tessere" class="border-radius">
			<h1>CONTROLLO TESSERINI</h1>
			In quest'area è possibile controllare l'autenticità dei tesserini dei funzionari GNA tramite l'inserimento del codice anticontraffazione univoco presente esclusivamente sui tesserini regolamentari. <br/>
<br/>
L'uso del sistema di controllo è riservato alle Forze dell'Ordine e ai dirigenti GNA. Qualsiasi uso non autorizzato sarà segnalato alle Autorità competenti.<br/>
<br/>
<a href="controllo_tesserini.aspx">Accedi all'area controllo tesserini</a>
			</div>
		</div>
	</div>
    </div>
    </div>
</asp:Content>



