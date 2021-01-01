Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class GestioneRecapito20
    Private _mobile_phone As String
    Private _mobile_ufficio As String
    Private _telefonoufficio As String
    Private _telefonoabitazione As String
    Private _email As String
    Private _emailufficio As String
    Private _idrecapito As Integer



    Public Property MobilePhone As String
        Get
            Return _mobile_phone
        End Get
        Set(value As String)
            _mobile_phone = value
        End Set
    End Property

    Public Property mobile_ufficio As String
        Get
            Return _mobile_ufficio
        End Get
        Set(value As String)
            _mobile_ufficio = value
        End Set
    End Property

    Public Property telefonoufficio As String
        Get
            Return _telefonoufficio
        End Get
        Set(value As String)
            _telefonoufficio = value
        End Set
    End Property

    Public Property telefonoabitazione As String
        Get
            Return _telefonoabitazione
        End Get
        Set(value As String)
            _telefonoabitazione = value
        End Set
    End Property

    Public Property email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property

    Public Property emailufficio As String
        Get
            Return _emailufficio
        End Get
        Set(value As String)
            _emailufficio = value
        End Set
    End Property

    Public Property IdRecapito As Integer
        Get
            Return _idrecapito
        End Get
        Set(value As Integer)
            _idrecapito = value
        End Set
    End Property

    Public Function SalvaRecapitoUtente(stringaconnessione As String) As Integer
        Dim risultato_query As Integer = 0
        Try
            Dim mysqlconn As New MySqlConnection(stringaconnessione)

            Dim mysqlcomm As New MySqlCommand()

            mysqlcomm.CommandText = "Insert into Anagrafica_recapiti(MobilePhone,MobileUfficio,Telefonoabitazione,TelefonoUfficio,Email,EmailUfficio) Values('"

            mysqlcomm.CommandText = mysqlcomm.CommandText & Me.MobilePhone & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.mobile_ufficio & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.telefonoabitazione & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.telefonoufficio & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.email & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.emailufficio & "')"
            mysqlcomm.Connection = mysqlconn

            mysqlconn.Open()

            risultato_query = mysqlcomm.ExecuteNonQuery()

            If (risultato_query = 1) Then
                'ottieni id recapito
                mysqlcomm.Dispose()
                IdRecapito = OttieniIdRecapito(mysqlconn)
                mysqlconn.Close()
                mysqlconn.Dispose()
            End If

        Catch ex As Exception

        End Try
        Return risultato_query
    End Function

    Private Function OttieniIdRecapito(mysqlconn As MySqlConnection) As Integer


        Try
            Dim mysqlcomm As New MySqlCommand()
            mysqlcomm.Connection = mysqlconn
            mysqlcomm.CommandText = "select IdRecapito as IdRecord from anagrafica_recapiti where MobilePhone='" & Me.MobilePhone & "' AND"
            mysqlcomm.CommandText = mysqlcomm.CommandText & " MobileUfficio='" & Me.mobile_ufficio & "' AND"
            mysqlcomm.CommandText = mysqlcomm.CommandText & " TelefonoAbitazione='" & Me.telefonoabitazione & "' AND"
            mysqlcomm.CommandText = mysqlcomm.CommandText & " TelefonoUfficio='" & Me.telefonoufficio & "' AND"
            mysqlcomm.CommandText = mysqlcomm.CommandText & " Email='" & Me.email & "' AND"
            mysqlcomm.CommandText = mysqlcomm.CommandText & " EmailUfficio='" & Me.emailufficio & "'"

            Dim mysqldata_reader = mysqlcomm.ExecuteReader()

            If (mysqldata_reader.HasRows) Then
                While (mysqldata_reader.Read)
                    _idrecapito = mysqldata_reader("IdRecord")
                End While
            End If
            mysqldata_reader.Close()

        Catch ex As Exception

        End Try

        OttieniIdRecapito = _idrecapito

    End Function
End Class
