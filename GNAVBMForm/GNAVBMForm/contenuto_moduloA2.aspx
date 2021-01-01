<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="contenuto_moduloA2.aspx.vb" Inherits="GNAVBMForm.contenuto_moduloA2" %>

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
        .auto-style4 {
            text-align: justify;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style4">
            <span class="auto-style1"><span class="auto-style2">Corso Critico (CRO) finalizzato al conseguimento dell’Attestato di Pilota APR per operazioni critiche<br />
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
            2. aver ottenuto da ENAC l’Autorizzazione come Operatore, oppure avere un accordo/contratto con un Operatore aver svolto precedentemente almeno trentasei (36) missioni, pari ad almeno sei (6) ore di volo complessive come pilota responsabile. 
            <br />
            <br />
            <a href="https://www.enac.gov.it/sicurezza-aerea/certificazione-del-personale/medicina-aeronautica/ame-aemc-elenco-medici" target="_parent">https://www.enac.gov.it/sicurezza-aerea/certificazione-del-personale/medicina-aeronautica/ame-aemc-elenco-medici</a><br />
            <a href="https://www.enac.gov.it/sites/default/files/allegati/2019-Gen/Elenco_AME_Classe2_20190118.pdf" target="_parent">AME Classe 2 - Elenco Medici</a>
            <br />
            </span></span>
            <br />
             <asp:ImageButton ID="btn_registrati" runat="server" ImageUrl="/img/pulsante-registrati.png" OnClientClick="javascript:caricamoduloreg(2);" />
        </div>
    </form>
</body>
</html>
