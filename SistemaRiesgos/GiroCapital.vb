Partial Class GiroCapital
    Partial Class EVALUACIONGIROCAPITALDataTable

        Private Sub EVALUACIONGIROCAPITALDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.__SUCURSAL_Column.ColumnName) Then
                'Agregar código de usuario aquí
            End If

        End Sub

    End Class

    Partial Class MOVIMIENTODataTable

    End Class

    Partial Class SOLICITUD_PENDIENTESDataTable

        'Private Sub SOLICITUD_PENDIENTESDataTable_SOLICITUD_PENDIENTESRowChanging(ByVal sender As System.Object, ByVal e As SOLICITUD_PENDIENTESRowChangeEvent) Handles Me.SOLICITUD_PENDIENTESRowChanging

        '  End Sub

        '  Private Sub SOLICITUD_PENDIENTESDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
        ' If (e.Column.ColumnName = Me.ID_SOLICITUD2Column.ColumnName) Then
        'Agregar código de usuario aquí
        ' End If

        ' End Sub

    End Class

End Class
