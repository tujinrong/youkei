' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ロジック共通関数
'
' 作成日　　: 2024.07.16
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service

    Public Class JbdGjsDataSetUtil

        Public Shared Function GetDateTable(tableInfo As AiTableInfo) As DataTable
            Dim dt = New DataTable()
            dt.TableName = tableInfo.TableName

            For Each field In tableInfo.FieldList
                Dim col = New DataColumn()
                col.ColumnName = field.FieldName
                col.Caption = field.FieldDesc
                col.DataType = AiGlobal.DbInfoProvider.GetFieldType(field.DbType)
                dt.Columns.Add(col)
            Next
            Return dt
        End Function


        ''' <summary>
        ''' ���f�����X�g��Dictionary��擾����B
        ''' </summary>
        Public Shared Function GetDataDic(Of K As notnull)(dt As DataTable) As Dictionary(Of K, List(Of DataRow))
            Dim dic = New Dictionary(Of K, List(Of DataRow))()
            For Each dr As DataRow In dt.Rows
                Dim key = Conversions.ToGenericParameter(Of K)(dr(0))
                If dic.ContainsKey(key) Then
                    dic(key).Add(dr)
                Else
                    dic.Add(key, New List(Of DataRow)())
                    dic(key).Add(dr)
                End If
            Next
            Return dic
        End Function
        Public Shared Function GetKeyList(dt As DataTable, keyInfoList As List(Of AiFieldInfo)) As List(Of Object())
            Dim list = New List(Of Object())()
            If dt Is Nothing Then Return list
            If dt.Rows.Count = 0 Then Return list

            For Each row As DataRow In dt.Rows
                Dim keys = keyInfoList.[Select](Function(e) row(e.FieldName)).ToArray()
                list.Add(keys)
            Next

            Return list
        End Function

        Public Shared Function NewDataTable(dt As DataTable) As DataTable
            Dim newdt = dt.Copy()
            newdt.Rows.Clear()
            Return newdt
        End Function

        Public Shared Sub CopyRow(dr1 As DataRow, dr2 As DataRow)
            For i = 0 To dr1.Table.Columns.Count - 1
                dr2(i) = dr1(i)
            Next
        End Sub

        'public static string ToStr(DataRow dr, string item)
        '{
        '    object value = (object)dr[item];
        '    return value.ToString();
        '}

    End Class
    Friend Class DaExtension

        <Extension()>
        Public Function ToStr(Me dr As DataRow, name As String) As String
            Dim obj = dr(name)
            Return If(obj.ToString(), "")
        End Function

        <Extension()>
        Public Function ToBool(Me dr As DataRow, name As String) As Boolean
            Dim obj As Object? = dr(name)
            Return Convert.ToBoolean(obj)
        End Function

        <Extension()>
        Public Function ToInt(Me dr As DataRow, name As String) As Integer
            Dim obj = dr(name)
            Dim column = dr.Table.Columns(name)
            If obj Is Nothing Then
                Return 0
            ElseIf obj.GetType() Is GetType(DBNull) Then
                Return 0
            Else
                Return Conversions.ToInteger(obj)
            End If
        End Function

        <Extension()>
        Public Function ToIntNullable(Me dr As DataRow, name As String) As Integer?
            Dim obj = dr(name)
            Dim column = dr.Table.Columns(name)
            If obj Is Nothing Then
                Return Nothing
            ElseIf obj.GetType() Is GetType(DBNull) Then
                Return Nothing
            Else
                Return Conversions.ToInteger(obj)
            End If
        End Function

        <Extension()>
        Public Function ToDecimal(Me dr As DataRow, name As String) As Decimal
            Dim obj = dr(name)
            Dim column = dr.Table.Columns(name)
            If obj Is Nothing Then
                Return 0D
            ElseIf obj.GetType() Is GetType(DBNull) Then
                Return 0D
            Else
                Return Conversions.ToDecimal(obj)
            End If
        End Function

        <Extension()>
        Public Function ToDecimalNullable(Me dr As DataRow, name As String) As Decimal?
            Dim obj = dr(name)
            Dim column = dr.Table.Columns(name)
            If obj Is Nothing Then
                Return Nothing
            ElseIf obj.GetType() Is GetType(DBNull) Then
                Return Nothing
            Else
                Return Conversions.ToDecimal(obj)
            End If
        End Function

        <Extension()>
        Public Function ToDate(Me dr As DataRow, name As String) As Date
            Dim obj = dr(name)
            Dim column = dr.Table.Columns(name)
            If obj Is Nothing Then
                Return Nothing
            ElseIf obj.GetType() Is GetType(DBNull) Then
                Return Nothing
            Else
                Dim d = Conversions.ToDate(obj)
                Return New DateTime(d.Year, d.Month, d.Day)
            End If
        End Function

        <Extension()>
        Public Function ToDateNullable(Me dr As DataRow, name As String) As Date?
            Dim obj = dr(name)
            Dim column = dr.Table.Columns(name)
            If obj Is Nothing Then
                Return Nothing
            ElseIf obj.GetType() Is GetType(DBNull) Then
                Return Nothing
            Else
                Dim d = Conversions.ToDate(obj)
                Return New DateTime(d.Year, d.Month, d.Day)
            End If
        End Function

        <Extension()>
        Public Function ToDateTimeNullable(Me dr As DataRow, name As String) As Date?
            Dim obj = dr(name)
            Dim column = dr.Table.Columns(name)
            If obj Is Nothing Then
                Return Nothing
            ElseIf obj.GetType() Is GetType(DBNull) Then
                Return Nothing
            Else
                Return Conversions.ToDate(obj)
            End If
        End Function

        Private Function GetDateStr(value As Date, name As String) As String
            If name.Contains("����") Then
                Return value.ToString("yyyy/MM/dd HH:mm:ss")
            Else
                Return value.ToString("yyyy/MM/dd")
            End If
        End Function

        <Extension()>
        Public Function ToDateStr(Me dr As DataRow, name As String, fmt As String) As String
            Dim obj = dr(name)
            Dim column = dr.Table.Columns(name)
            If obj Is Nothing Then
                Return String.Empty
            ElseIf obj.GetType() Is GetType(DBNull) Then
                Return String.Empty
            Else
                Return Format(obj, fmt)
            End If
        End Function

    End Class
End Namespace
