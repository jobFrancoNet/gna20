﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Il codice è stato generato da uno strumento.
'     Versione runtime:4.0.30319.42000
'
'     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
'     il codice viene rigenerato.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Runtime.Serialization

Namespace VerificaCF
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0"),  _
     System.Runtime.Serialization.DataContractAttribute(Name:="DTOUserSocio", [Namespace]:="http://tempuri.org/"),  _
     System.SerializableAttribute()>  _
    Partial Public Class DTOUserSocio
        Inherits Object
        Implements System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
        
        <System.NonSerializedAttribute()>  _
        Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private NOMEField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private COGNOMEField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private CODICEFISCALEField As String
        
        Private MatricolaField As Integer
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private emailField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private email_srvField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private cellulareField As String
        
        <Global.System.ComponentModel.BrowsableAttribute(false)>  _
        Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set
                Me.extensionDataField = value
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false)>  _
        Public Property NOME() As String
            Get
                Return Me.NOMEField
            End Get
            Set
                If (Object.ReferenceEquals(Me.NOMEField, value) <> true) Then
                    Me.NOMEField = value
                    Me.RaisePropertyChanged("NOME")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=1)>  _
        Public Property COGNOME() As String
            Get
                Return Me.COGNOMEField
            End Get
            Set
                If (Object.ReferenceEquals(Me.COGNOMEField, value) <> true) Then
                    Me.COGNOMEField = value
                    Me.RaisePropertyChanged("COGNOME")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=2)>  _
        Public Property CODICEFISCALE() As String
            Get
                Return Me.CODICEFISCALEField
            End Get
            Set
                If (Object.ReferenceEquals(Me.CODICEFISCALEField, value) <> true) Then
                    Me.CODICEFISCALEField = value
                    Me.RaisePropertyChanged("CODICEFISCALE")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute(IsRequired:=true, Order:=3)>  _
        Public Property Matricola() As Integer
            Get
                Return Me.MatricolaField
            End Get
            Set
                If (Me.MatricolaField.Equals(value) <> true) Then
                    Me.MatricolaField = value
                    Me.RaisePropertyChanged("Matricola")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=4)>  _
        Public Property email() As String
            Get
                Return Me.emailField
            End Get
            Set
                If (Object.ReferenceEquals(Me.emailField, value) <> true) Then
                    Me.emailField = value
                    Me.RaisePropertyChanged("email")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=5)>  _
        Public Property email_srv() As String
            Get
                Return Me.email_srvField
            End Get
            Set
                If (Object.ReferenceEquals(Me.email_srvField, value) <> true) Then
                    Me.email_srvField = value
                    Me.RaisePropertyChanged("email_srv")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=6)>  _
        Public Property cellulare() As String
            Get
                Return Me.cellulareField
            End Get
            Set
                If (Object.ReferenceEquals(Me.cellulareField, value) <> true) Then
                    Me.cellulareField = value
                    Me.RaisePropertyChanged("cellulare")
                End If
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="VerificaCF.VerificaCodiceFiscale_iscrittoSoap")>  _
    Public Interface VerificaCodiceFiscale_iscrittoSoap
        
        'CODEGEN: Generazione di un contratto di messaggio perché il nome di elemento cf dallo spazio dei nomi http://tempuri.org/ non è contrassegnato come nillable
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/VerificaCodiceFiscaleIscritto", ReplyAction:="*")>  _
        Function VerificaCodiceFiscaleIscritto(ByVal request As VerificaCF.VerificaCodiceFiscaleIscrittoRequest) As VerificaCF.VerificaCodiceFiscaleIscrittoResponse
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/VerificaCodiceFiscaleIscritto", ReplyAction:="*")>  _
        Function VerificaCodiceFiscaleIscrittoAsync(ByVal request As VerificaCF.VerificaCodiceFiscaleIscrittoRequest) As System.Threading.Tasks.Task(Of VerificaCF.VerificaCodiceFiscaleIscrittoResponse)
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class VerificaCodiceFiscaleIscrittoRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="VerificaCodiceFiscaleIscritto", [Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public Body As VerificaCF.VerificaCodiceFiscaleIscrittoRequestBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As VerificaCF.VerificaCodiceFiscaleIscrittoRequestBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://tempuri.org/")>  _
    Partial Public Class VerificaCodiceFiscaleIscrittoRequestBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public cf As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal cf As String)
            MyBase.New
            Me.cf = cf
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class VerificaCodiceFiscaleIscrittoResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="VerificaCodiceFiscaleIscrittoResponse", [Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public Body As VerificaCF.VerificaCodiceFiscaleIscrittoResponseBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As VerificaCF.VerificaCodiceFiscaleIscrittoResponseBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://tempuri.org/")>  _
    Partial Public Class VerificaCodiceFiscaleIscrittoResponseBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public VerificaCodiceFiscaleIscrittoResult As VerificaCF.DTOUserSocio
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal VerificaCodiceFiscaleIscrittoResult As VerificaCF.DTOUserSocio)
            MyBase.New
            Me.VerificaCodiceFiscaleIscrittoResult = VerificaCodiceFiscaleIscrittoResult
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface VerificaCodiceFiscale_iscrittoSoapChannel
        Inherits VerificaCF.VerificaCodiceFiscale_iscrittoSoap, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class VerificaCodiceFiscale_iscrittoSoapClient
        Inherits System.ServiceModel.ClientBase(Of VerificaCF.VerificaCodiceFiscale_iscrittoSoap)
        Implements VerificaCF.VerificaCodiceFiscale_iscrittoSoap
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function VerificaCF_VerificaCodiceFiscale_iscrittoSoap_VerificaCodiceFiscaleIscritto(ByVal request As VerificaCF.VerificaCodiceFiscaleIscrittoRequest) As VerificaCF.VerificaCodiceFiscaleIscrittoResponse Implements VerificaCF.VerificaCodiceFiscale_iscrittoSoap.VerificaCodiceFiscaleIscritto
            Return MyBase.Channel.VerificaCodiceFiscaleIscritto(request)
        End Function
        
        Public Function VerificaCodiceFiscaleIscritto(ByVal cf As String) As VerificaCF.DTOUserSocio
            Dim inValue As VerificaCF.VerificaCodiceFiscaleIscrittoRequest = New VerificaCF.VerificaCodiceFiscaleIscrittoRequest()
            inValue.Body = New VerificaCF.VerificaCodiceFiscaleIscrittoRequestBody()
            inValue.Body.cf = cf
            Dim retVal As VerificaCF.VerificaCodiceFiscaleIscrittoResponse = CType(Me,VerificaCF.VerificaCodiceFiscale_iscrittoSoap).VerificaCodiceFiscaleIscritto(inValue)
            Return retVal.Body.VerificaCodiceFiscaleIscrittoResult
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function VerificaCF_VerificaCodiceFiscale_iscrittoSoap_VerificaCodiceFiscaleIscrittoAsync(ByVal request As VerificaCF.VerificaCodiceFiscaleIscrittoRequest) As System.Threading.Tasks.Task(Of VerificaCF.VerificaCodiceFiscaleIscrittoResponse) Implements VerificaCF.VerificaCodiceFiscale_iscrittoSoap.VerificaCodiceFiscaleIscrittoAsync
            Return MyBase.Channel.VerificaCodiceFiscaleIscrittoAsync(request)
        End Function
        
        Public Function VerificaCodiceFiscaleIscrittoAsync(ByVal cf As String) As System.Threading.Tasks.Task(Of VerificaCF.VerificaCodiceFiscaleIscrittoResponse)
            Dim inValue As VerificaCF.VerificaCodiceFiscaleIscrittoRequest = New VerificaCF.VerificaCodiceFiscaleIscrittoRequest()
            inValue.Body = New VerificaCF.VerificaCodiceFiscaleIscrittoRequestBody()
            inValue.Body.cf = cf
            Return CType(Me,VerificaCF.VerificaCodiceFiscale_iscrittoSoap).VerificaCodiceFiscaleIscrittoAsync(inValue)
        End Function
    End Class
End Namespace