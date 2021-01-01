<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="contenuto_moduloA3.aspx.vb" Inherits="GNAVBMForm.contenuto_moduloA3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script type="text/javascript">
    function caricamoduloreg(code)
    {
     
        var url = "registrazionedroni.aspx?Code=" + code;
     
        window.open(url, "_blank");
    }
</script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-family: "Century Gothic";
        }
        .auto-style2 {
            font-size: small;
        }
        .auto-style3 {
            font-family: "Century Gothic";
            font-size: small;
        }
        .auto-style4 {
            text-align: justify;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style4">
            <span class="auto-style3">Corso BASICO finalizzato al conseguimento dell’Attestato di Pilota APR per operazioni NON critiche per multicotteri very light (VL / Mc) (peso max al decollo inferiore a 4kg).
            <br />
            </span>
            <br class="auto-style3" />
            <span class="auto-style1"><span class="auto-style2">Prima Parte Teorica che si sostanzia nell’erogazione agli allievi di sedici (16) ore di didattica frontale cui consegue un esame di profitto, il cui superamento rappresenta condizione necessaria per l’erogazione della Seconda Parte Pratica del Corso Basico, come previsto dalla normativa vigente (cfr. ENAC_All. A della LIC-15, pag.20).
            <br />
            L’Esame di Profitto si sostanzia in un test a risposta multipla di ventiquattro (24) domande al quale saranno sottoposti gli allievi al termine della Prima Parte Teorica del Corso Basico Il test si intenderà positivamente superato dagli allievi che: risponderanno correttamente ad almeno diciotto (18) domande sulle ventiquattro (24) alle quali saranno sottoposti.
            <br />
            Seconda Parte Pratica che si sostanzia nell’ affiancamento di ciascun allievo, da parte di un pilota istruttore APR afferente ad ACCADEMIA del DRONE, durante la conduzione di un numero minimo di trenta (30) voli individuali. Al termine dei trenta (30) voli ogni allievo dovrà superare uno “skill test” concernente un volo individuale di dieci (10) minuti da effettuarsi alla presenza dell’istruttore preposto alla vigilanza ed alla valutazione dell’operato dell’allievo (cfr. ENAC_Art. 5.3 della LIC-15 pag. 6) per poter frequentare il Corso BASICO ciascun allievo deve essere in possesso dei seguenti requisiti:<br />
            1. avere un’età minima di diciotto (18) anni
            <br />
            2. aver conseguito il diploma di scuola media inferiore
            <br />
            3. aver ottenuto un certificato medico di 2° classe che attesti l’idoneità psicofisica, rilasciato da un Aeronautical Medical Examiner (AME) secondo i dettami del Regolamento (UE) n. 1178/2011 e contestualizzando l’applicabilità delle AMC Part-MED (Section 4) alla esclusiva condotta di APR.
            <br />
            L’elenco dei medici certificati AME Classe 2, su tutto il territorio nazionale è disponibile sul sito ENAC all’indirizzo:<br />
            <br />
            <a href="https://www.enac.gov.it/sicurezza-aerea/certificazione-del-personale/medicina-aeronautica/ame-aemc-elenco-medici" target="_parent">https://www.enac.gov.it/sicurezza-aerea/certificazione-del-personale/medicina-aeronautica/ame-aemc-elenco-medici</a><br />
            </span><a href="https://www.enac.gov.it/sites/default/files/allegati/2019-Gen/Elenco_AME_Classe2_20190118.pdf" target="_parent"><span class="auto-style2">AME Classe 2 - Elenco Medici</span></a><span class="auto-style2">
            <br />
            <br />
            Corso Critico (CRO) finalizzato al conseguimento dell’Attestato di Pilota APR per operazioni critiche<br />
            <br />
            Prima Parte Teorica: che si sostanzia nell’erogazione agli allievi di dodici (12) ore di didattica frontale cui consegue un esame di profitto, il cui superamento rappresenta condizione necessaria per l’erogazione della Seconda Parte Pratica del Corso Critico come previsto dalla normativa vigente (cfr. ENAC_All. B della LIC-15, pag.21).<br />
            L’esame di profitto, si sostanzia in un test a risposta multipla di venti (20) domande al quale saranno sottoposti gli allievi al termine della Prima Parte Teorica del Corso Critico. Il test si intenderà positivamente superato dagli allievi che risponderanno correttamente ad almeno quindici (15) domande sulle venti (20) alle quali saranno sottoposti.
            <br />
            Seconda Parte Pratica: che si sostanzia nell’affiancamento di ciascun allievo, da parte di un pilota istruttore APR afferente ad ACCADEMIA del DRONE, durante la conduzione di un numero minimo di trentasei (36) voli individuali.
            <br />
            Al termine dei trentasei (36) voli ogni allievo dovrà superare uno “skill test” concernente un volo individuale di dieci (10) minuti da effettuarsi alla presenza dell’istruttore preposto alla vigilanza ed alla valutazione dell’operato dell’allievo (cfr. ENAC_Art. 6.1 della LIC-15, pag. 8).
            <br />
            Per poter frequentare il corso Critico ciascun allievo deve essere in possesso dei seguenti requisiti:
            <br />
            1. aver conseguito un Attestato di Pilota di APR;
            <br />
            2. aver ottenuto da ENAC l’Autorizzazione come Operatore, oppure avere un accordo/contratto con un Operatore aver svolto precedentemente almeno trentasei (36) missioni, pari ad almeno sei (6) ore di volo complessive come pilota responsabile.<br />
            </span></span>
            <br />
             <asp:ImageButton ID="btn_registrati" runat="server" ImageUrl="/img/pulsante-registrati.png" OnClientClick="javascript:caricamoduloreg(3);" />
        </div>
    </form>
</body>
</html>
