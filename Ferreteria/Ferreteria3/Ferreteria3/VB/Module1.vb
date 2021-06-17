Imports System.Data
Imports System.Data.SqlClient
Module Module1
    Public conn As String = "Data Source=DESKTOP-TJJMO5G;Initial Catalog=Ferreteria;Integrated Security=True"
    Public sqlCon As SqlConnection
    Public tipoOper As Integer 'si la operación es un INSERT O UPDATE
    Public CamposOk As Boolean
End Module