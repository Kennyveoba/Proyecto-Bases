Imports System.Data
Imports System.Data.SqlClient
Module Module1
    Public conn As String = "Data Source=DESKTOP-8FRKRQA;Initial Catalog=Ferreteria;Integrated Security=True"
    Public sqlCon As SqlConnection
    Public tipoOper As Integer 'si la operación es un INSERT O UPDATE
    Public Sucursal As Integer 'Para cambiar de sucursales
    Public CamposOk As Boolean
    Public Tiendas As Integer
    Public Usuario As String

End Module