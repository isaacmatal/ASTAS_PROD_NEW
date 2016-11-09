Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Cafeteria_Reportes_Catalogo_Menu
    Dim c_data As New cmbFill
    Dim c_data2 As New jarsClass

    Dim MensajeString As String
    Dim dtareader As SqlDataReader

    Dim Rpts As New frmReportes_Ver
    Private Sub Cafeteria_Reportes_Catalogo_Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        c_data.CargaCompa�ia(Me.cmbCOMPA�IA)
        c_data2.CargaBodegas(Compa�ia, Me.cmbBodega, 10)
        Iniciando = False
    End Sub
    Private Sub btnVerBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerBC.Click
        If MsgBox("�Est� seguro(a) que desea emitir el reporte?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Me.Label.Visible = True
            Rpts.CargaMenuRecetas(Me.cmbCOMPA�IA.SelectedValue, Me.cmbBodega.SelectedValue, Val(Me.txtProducto1.Text), Val(Me.txtProducto2.Text))
            Rpts.ShowDialog()
            Me.Label.Visible = False
            Limpiar1()
            Limpiar2()
        End If
    End Sub
    Private Sub TxtProducto1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProducto1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Try
                Me.txtDESCRIPCION1.Text = c_data2.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPA�IA=" & Me.cmbCOMPA�IA.SelectedValue & ", @BODEGA=" & Me.cmbBodega.SelectedValue & ", @PRODUCTO=" & Me.txtProducto1.Text & ", @BANDERA=1", 1)
                Me.txtMedida1.Text = c_data2.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPA�IA=" & Me.cmbCOMPA�IA.SelectedValue & ", @BODEGA=" & Me.cmbBodega.SelectedValue & ", @PRODUCTO=" & Me.txtProducto1.Text & ", @BANDERA=1", 2)
                Me.txtProducto2.Focus()
            Catch ex As Exception
                Limpiar1()
                MsgBox("El c�digo debe ser num�rico", MsgBoxStyle.Information)
            End Try
        End If
    End Sub
    Private Sub TxtProducto2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProducto2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Try
                Me.txtDESCRIPCION2.Text = c_data2.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPA�IA=" & Me.cmbCOMPA�IA.SelectedValue & ", @BODEGA=" & Me.cmbBodega.SelectedValue & ", @PRODUCTO=" & Val(Me.txtProducto2.Text) & ", @BANDERA=1", 1)
                Me.txtMedida2.Text = c_data2.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPA�IA=" & Me.cmbCOMPA�IA.SelectedValue & ", @BODEGA=" & Me.cmbBodega.SelectedValue & ", @PRODUCTO=" & Val(Me.txtProducto2.Text) & ", @BANDERA=1", 2)
                Me.btnVerBC.Focus()
            Catch ex As Exception
                Limpiar2()
                MsgBox("El c�digo debe ser num�rico", MsgBoxStyle.Information)
            End Try
        End If
    End Sub
#Region "Busqueda Productos"

    Private Sub btnBuscarProducto1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto1.Click
        Limpiar1()
        Dim Frm_Busqueda As New Cafeteria_Busqueda_Recetas_por_Bodega
        Frm_Busqueda.Iniciando = True
        Frm_Busqueda.TxtCompa�ia.Text = Me.cmbCOMPA�IA.Text
        Frm_Busqueda.TxtCompa�ia_cod.Text = Me.cmbCOMPA�IA.SelectedValue
        Frm_Busqueda.TxtBodega.Text = Me.cmbBodega.Text
        Frm_Busqueda.TxtBodega_cod.Text = Me.cmbBodega.SelectedValue
        Frm_Busqueda.Iniciando = False
        Frm_Busqueda.ShowDialog()
        Me.txtProducto1.Text = CodigoProducto
        Me.txtDESCRIPCION1.Text = Descripcion_Producto
        Me.txtMedida1.Text = unidades
    End Sub
    Private Sub btnBuscarProducto2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto2.Click
        Limpiar2()
        Dim Frm_Busqueda As New Cafeteria_Busqueda_Recetas_por_Bodega
        Frm_Busqueda.Iniciando = True
        Frm_Busqueda.TxtCompa�ia.Text = Me.cmbCOMPA�IA.Text
        Frm_Busqueda.TxtCompa�ia_cod.Text = Me.cmbCOMPA�IA.SelectedValue
        Frm_Busqueda.TxtBodega.Text = Me.cmbBodega.Text
        Frm_Busqueda.TxtBodega_cod.Text = Me.cmbBodega.SelectedValue
        Frm_Busqueda.Iniciando = False
        Frm_Busqueda.ShowDialog()
        Me.txtProducto2.Text = CodigoProducto
        Me.txtDESCRIPCION2.Text = Descripcion_Producto
        Me.txtMedida2.Text = unidades
    End Sub
#End Region
    Sub Limpiar1()
        Me.txtProducto1.Clear()
        Me.txtDESCRIPCION1.Clear()
        Me.txtMedida1.Clear()
    End Sub
    Sub Limpiar2()
        Me.txtProducto2.Clear()
        Me.txtDESCRIPCION2.Clear()
        Me.txtMedida2.Clear()
    End Sub
End Class