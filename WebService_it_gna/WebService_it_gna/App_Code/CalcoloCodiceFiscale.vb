Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Web.Configuration

' Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Public Class CalcoloCodiceFiscale
    Inherits System.Web.Services.WebService
    Public strConn As String = WebConfigurationManager.ConnectionStrings("GNATEST_ConnectionString").ConnectionString
    Public Sub GetCodiceEstero(ByVal comune As String, ByRef codice As String)
        Dim strsql As String = "Select Codice from comuni_esteri where comune='" & comune & "'"
        Try
            Dim mysqlconn As New MySqlConnection(strConn)
            mysqlconn.Open()
            Dim dtset As DataSet = New DataSet()
            Dim adapt As New MySqlDataAdapter()
            Dim comando As New MySqlCommand()
            comando.CommandText = strsql
            comando.Connection = mysqlconn
            adapt.SelectCommand = comando
            adapt.Fill(dtset, "codice")
            If (dtset.Tables(0).Rows.Count > 0) Then
                codice = dtset.Tables(0).Rows(0).Field(Of String)("Codice")
                mysqlconn.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function GetLetteraControllo(ByVal codicefiscale As String) As String
        Dim letteracontrollo_old As String = codicefiscale(15)
        Dim letteracontrollo_new As String = String.Empty
        'REF ARTICOLO http://www.dotnethell.it/articles/CalcoloCodiceFiscale.aspx
        'algoritmo caloclo lettera di controllo
        Dim s_pari As Integer
        Dim s_dispari As Integer
        Dim carattere_pari As String
        For i = 1 To 16 - 1
            If (i Mod 2) = 0 Then
                carattere_pari = codicefiscale(i - 1)
                If (carattere_pari = "0") Then
                    s_pari = s_pari + 0
                End If
                If (carattere_pari = "1") Then
                    s_pari = s_pari + 1
                End If
                If (carattere_pari = "2") Then
                    s_pari = s_pari + 2
                End If
                If (carattere_pari = "3") Then
                    s_pari = s_pari + 3
                End If
                If (carattere_pari = "4") Then
                    s_pari = s_pari + 4
                End If
                If (carattere_pari = "5") Then
                    s_pari = s_pari + 5
                End If
                If (carattere_pari = "6") Then
                    s_pari = s_pari + 6
                End If
                If (carattere_pari = "7") Then
                    s_pari = s_pari + 7
                End If
                If (carattere_pari = "8") Then
                    s_pari = s_pari + 8
                End If
                If (carattere_pari = "9") Then
                    s_pari = s_pari + 9
                End If
                If (carattere_pari = "A") Then
                    s_pari = s_pari + 0

                End If
                If (carattere_pari = "B") Then
                    s_pari = s_pari + 1
                End If
                If (carattere_pari = "C") Then
                    s_pari = s_pari + 2
                End If
                If (carattere_pari = "D") Then
                    s_pari = s_pari + 3
                End If
                If (carattere_pari = "E") Then
                    s_pari = s_pari + 4
                End If
                If (carattere_pari = "F") Then
                    s_pari = s_pari + 5
                End If
                If (carattere_pari = "G") Then
                    s_pari = s_pari + 6
                End If
                If (carattere_pari = "H") Then
                    s_pari = s_pari + 7
                End If
                If (carattere_pari = "I") Then
                    s_pari = s_pari + 8
                End If
                If (carattere_pari = "J") Then
                    s_pari = s_pari + 9
                End If
                If (carattere_pari = "K") Then
                    s_pari = s_pari + 10
                End If
                If (carattere_pari = "L") Then
                    s_pari = s_pari + 11

                End If
                If (carattere_pari = "M") Then
                    s_pari = s_pari + 12
                End If
                If (carattere_pari = "N") Then
                    s_pari = s_pari + 13
                End If
                If (carattere_pari = "O") Then
                    s_pari = s_pari + 14
                End If
                If (carattere_pari = "P") Then
                    s_pari = s_pari + 15
                End If
                If (carattere_pari = "Q") Then
                    s_pari = s_pari + 16
                End If
                If (carattere_pari = "R") Then
                    s_pari = s_pari + 17
                End If
                If (carattere_pari = "S") Then
                    s_pari = s_pari + 18
                End If
                If (carattere_pari = "T") Then
                    s_pari = s_pari + 19
                End If
                If (carattere_pari = "U") Then
                    s_pari = s_pari + 20
                End If
                If (carattere_pari = "V") Then
                    s_pari = s_pari + 21
                End If
                If (carattere_pari = "W") Then
                    s_pari = s_pari + 22

                End If
                If (carattere_pari = "X") Then
                    s_pari = s_pari + 23
                End If
                If (carattere_pari = "Y") Then
                    s_pari = s_pari + 24

                End If
                If (carattere_pari = "Z") Then
                    s_pari = s_pari + 25
                End If
            End If

            If (i Mod 2) = 1 Then
                Dim carattere_dispari = codicefiscale(i - 1)
                If (carattere_dispari = "0") Then
                    s_dispari = s_dispari + 1
                End If
                If (carattere_dispari = "1") Then
                    s_dispari = s_dispari + 0
                End If
                If (carattere_dispari = "2") Then
                    s_dispari = s_dispari + 5
                End If
                If (carattere_dispari = "3") Then
                    s_dispari = s_dispari + 7
                End If
                If (carattere_dispari = "4") Then
                    s_dispari = s_dispari + 9
                End If
                If (carattere_dispari = "5") Then
                    s_dispari = s_dispari + 13
                End If
                If (carattere_dispari = "6") Then
                    s_dispari = s_dispari + 15
                End If
                If (carattere_dispari = "7") Then
                    s_dispari = s_dispari + 17
                End If
                If (carattere_dispari = "8") Then
                    s_dispari = s_dispari + 19
                End If
                If (carattere_dispari = "9") Then
                    s_dispari = s_dispari + 21
                End If
                If (carattere_dispari = "A") Then
                    s_dispari = s_dispari + 1

                End If
                If (carattere_dispari = "B") Then
                    s_dispari = s_dispari + 0
                End If
                If (carattere_dispari = "C") Then
                    s_dispari = s_dispari + 5
                End If
                If (carattere_dispari = "D") Then
                    s_dispari = s_dispari + 7
                End If
                If (carattere_dispari = "E") Then
                    s_dispari = s_dispari + 9
                End If
                If (carattere_dispari = "F") Then
                    s_dispari = s_dispari + 13
                End If
                If (carattere_dispari = "G") Then
                    s_dispari = s_dispari + 15
                End If
                If (carattere_dispari = "H") Then
                    s_dispari = s_dispari + 17
                End If
                If (carattere_dispari = "I") Then
                    s_dispari = s_dispari + 19
                End If
                If (carattere_dispari = "J") Then
                    s_dispari = s_dispari + 21
                End If
                If (carattere_dispari = "K") Then
                    s_dispari = s_dispari + 2
                End If
                If (carattere_dispari = "L") Then
                    s_dispari = s_dispari + 4

                End If
                If (carattere_dispari = "M") Then
                    s_dispari = s_dispari + 18
                End If
                If (carattere_dispari = "N") Then
                    s_dispari = s_dispari + 20
                End If
                If (carattere_dispari = "O") Then
                    s_dispari = s_dispari + 11
                End If
                If (carattere_dispari = "P") Then
                    s_dispari = s_dispari + 3
                End If
                If (carattere_dispari = "Q") Then
                    s_dispari = s_dispari + 6
                End If
                If (carattere_dispari = "R") Then
                    s_dispari = s_dispari + 8
                End If
                If (carattere_dispari = "S") Then
                    s_dispari = s_dispari + 12
                End If
                If (carattere_dispari = "T") Then
                    s_dispari = s_dispari + 14
                End If
                If (carattere_dispari = "U") Then
                    s_dispari = s_dispari + 16
                End If
                If (carattere_dispari = "V") Then
                    s_dispari = s_dispari + 10
                End If
                If (carattere_dispari = "W") Then
                    s_dispari = s_dispari + 22

                End If
                If (carattere_dispari = "X") Then
                    s_dispari = s_dispari + 25
                End If
                If (carattere_dispari = "Y") Then
                    s_dispari = s_dispari + 24

                End If
                If (carattere_dispari = "Z") Then
                    s_dispari = s_dispari + 23
                End If
            End If
        Next
        Dim somma_totale = s_pari + s_dispari
        Dim resto As Integer = somma_totale Mod 26
        If (resto = 0) Then
            letteracontrollo_new = "A"
        End If
        If (resto = 1) Then
            letteracontrollo_new = "B"
        End If

        If (resto = 2) Then
            letteracontrollo_new = "C"
        End If

        If (resto = 3) Then
            letteracontrollo_new = "D"
        End If

        If (resto = 4) Then
            letteracontrollo_new = "E"
        End If

        If (resto = 5) Then
            letteracontrollo_new = "F"
        End If

        If (resto = 6) Then
            letteracontrollo_new = "G"
        End If

        If (resto = 7) Then
            letteracontrollo_new = "H"
        End If

        If (resto = 8) Then
            letteracontrollo_new = "I"
        End If

        If (resto = 9) Then
            letteracontrollo_new = "J"
        End If

        If (resto = 10) Then
            letteracontrollo_new = "K"
        End If

        If (resto = 11) Then
            letteracontrollo_new = "L"
        End If

        If (resto = 12) Then
            letteracontrollo_new = "M"
        End If

        If (resto = 13) Then
            letteracontrollo_new = "N"
        End If

        If (resto = 14) Then
            letteracontrollo_new = "O"
        End If

        If (resto = 15) Then
            letteracontrollo_new = "P"
        End If
        If (resto = 16) Then
            letteracontrollo_new = "Q"
        End If

        If (resto = 17) Then
            letteracontrollo_new = "R"
        End If

        If (resto = 18) Then
            letteracontrollo_new = "S"
        End If

        If (resto = 19) Then
            letteracontrollo_new = "T"
        End If

        If (resto = 20) Then
            letteracontrollo_new = "U"
        End If

        If (resto = 21) Then
            letteracontrollo_new = "V"
        End If

        If (resto = 22) Then
            letteracontrollo_new = "W"
        End If

        If (resto = 23) Then
            letteracontrollo_new = "X"
        End If

        If (resto = 24) Then
            letteracontrollo_new = "Y"
        End If

        If (resto = 25) Then
            letteracontrollo_new = "Z"
        End If

        Dim CODICEFISCALE_NEW As String = String.Empty

        For I = 0 To 14
            CODICEFISCALE_NEW = CODICEFISCALE_NEW + codicefiscale(I)
        Next

        CODICEFISCALE_NEW = CODICEFISCALE_NEW + letteracontrollo_new

        Return CODICEFISCALE_NEW
    End Function

    <WebMethod()>
    Public Function calcolocodicefiscaleV2(nome As String, cognome As String, datanascita As String, comunenascita As String, sesso As String) As codfisc
        Dim objservice As New WebService.codicefiscale.CodiceFiscale
        Dim cf = objservice.CalcolaCodiceFiscale(nome, cognome, comunenascita, datanascita, sesso)
        Dim codfiscclass As New codfisc
        If Not cf.Equals("Il comune di nascita è inesistente!") Then
            codfiscclass.codiceestero = ""
            codfiscclass.codicefiscale = cf

        End If
        If (cf.Equals("Il comune di nascita è inesistente!")) Then
            Dim codiceestero As String = String.Empty
            GetCodiceEstero(comunenascita, codiceestero)

            If Not String.IsNullOrEmpty(codiceestero) Then
                codfiscclass.codiceestero = codiceestero
                objservice = New WebService.codicefiscale.CodiceFiscale()
                codfiscclass.codicefiscale = objservice.CalcolaCodiceFiscale(nome, cognome, "Bari", datanascita, sesso)
                codfiscclass.codicefiscale = codfiscclass.codicefiscale.Replace("A662", codiceestero)
                codfiscclass.codicefiscale = GetLetteraControllo(codfiscclass.codicefiscale)
                Return codfiscclass
            Else
                Return codfiscclass
            End If
            Return codfiscclass
        End If
        Return codfiscclass
    End Function

End Class