﻿Imports System.Data.SqlClient

Public Class FormularioPrincipal

    Private _dataTable As DataTable

    Public Sub ConectarBaseDeDatos()
        Dim cadena As String = "Server=tcp:sqlprogra2azure.database.windows.net,1433;Initial Catalog=SQLprogra2Azure;Persist Security Info=False;User ID=sqladmin;Password=12345abC;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

        Dim conexion = New SqlConnection(cadena)

        Dim comando = conexion.CreateCommand
        comando.CommandText = "SELECT Nombre, PrimerApellido FROM Clientes"

        'Abrir la conexion
        conexion.Open()

        Dim adaptador As SqlDataAdapter = New SqlDataAdapter(comando)

        ' Llenado offline con DataTable para uso posterior en 1 sola llamada
        _dataTable = New DataTable()
        adaptador.Fill(_dataTable)

        Dim lector = comando.ExecuteReader()

        Do While lector.Read()
            Dim resultado = lector.GetString(0) & " " & lector.GetString(1) & vbLf

            Console.WriteLine(resultado)
        Loop

        lector.Close()
        conexion.Close()

    End Sub

    Private Sub botonConectar_Click(sender As Object, e As EventArgs) Handles botonConectar.Click
        ConectarBaseDeDatos()

        CargarInterfazGrafica()
    End Sub

    Private Sub CargarInterfazGrafica()
        ListBoxDatos.DisplayMember = "PrimerApellido"
        ListBoxDatos.DataSource = _dataTable
    End Sub
End Class