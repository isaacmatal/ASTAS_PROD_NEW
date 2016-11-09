Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Cafeteria_Reporte_Promedio_Semanal_Costo
    Dim Rpts As New frmReportes_Ver
    Dim jasr_fill As New jarsClass

    Dim Iniciando As Boolean
    Private Sub Cafeteria_Reporte_Promedio_Semanal_Costo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        jasr_fill.CargaBodegas(Compa�ia, Me.cmbBODEGA, 7)
        Iniciando = False
    End Sub
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If MsgBox("�Est� seguro que desea Imprimir el Promedio Semanal de Costos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Rpts.GetReportePromedio_Semanal_Costo(Compa�ia, Me.cmbBODEGA.SelectedValue, Format(Me.txtFechaI.Value, "dd-MM-yyyy"), Format(Me.txtFechaF.Value, "dd-MM-yyyy"), "Y")
            If Hay_Datos = True Then
                Rpts.ShowDialog()
            End If
        End If
    End Sub
End Class