' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: メッセージ定義
'             
'作成日　　 : 2024.07.17
'作成者　　 : AIPlus
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service

    Public Class SessionContext
        Public Connection As OracleConnection

        Private _CommandTimeout As Integer

        Public Property CommandTimeout As Integer
            Get
                Return If(_CommandTimeout <= 0, _CommandTimeout, _CommandTimeout)
            End Get
            Set(value As Integer)
                _CommandTimeout = value
            End Set
        End Property

        Public Property DbContext As Object

        Public Property Unit As Object

        Public Property UserID As Object

        Public Property SessionData As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()


        Public Sub New()
        End Sub

        Public Sub New(connStr As String)
            Connection = New DaOraDbContext(DaGlobal.ConnectionString).Connection
        End Sub

        'Public Function GetDataTable(sql As String) As DataTable
        '    Return AiGlobal.DbApi.GetDataTableBySql(Me, sql)
        'End Function

        'Public Function GetDataTable(sql As String, paraNames As String(), paraValues As Object()) As DataTable
        '    Dim aiSqlHelper As AiSqlHelper = New AiSqlHelper(Me, sql)
        '    For i = 0 To paraNames.Length - 1
        '        If sql.Contains("@" & paraNames(i)) Then
        '            aiSqlHelper.AddParameter(paraNames(i), paraValues(i))
        '        End If
        '    Next

        '    Return aiSqlHelper.GetDataTable()
        'End Function

        'Public Function MakeWorkTable(sql As String, paraNames As String(), paraValues As Object?()) As Integer
        '    Dim aiSqlHelper As AiSqlHelper = New AiSqlHelper(Me, sql)
        '    For i = 0 To paraNames.Length - 1
        '        If sql.Contains("@" & paraNames(i)) Then
        '            aiSqlHelper.AddParameter(paraNames(i), paraValues(i))
        '        End If
        '    Next

        '    Return aiSqlHelper.Execute()
        'End Function

        'Public Function Execute(sql As String) As Integer
        '    Return AiGlobal.DbApi.RunSql(Me, sql)
        'End Function

        'Public Function Execute(sql As String, paraList As List(Of AiKeyValue)) As Integer
        '    Dim paraNames As String() = paraList.[Select](Function(e) e.Key).ToArray()
        '    Dim paraValues As Object() = paraList.[Select](Function(e) e.Value).ToArray()
        '    Return Me.Execute(sql, paraNames, paraValues)
        'End Function

        'Public Function Execute(sql As String, paraNames As String(), paraValues As Object?()) As Integer
        '    Dim aiSqlHelper As AiSqlHelper = New AiSqlHelper(Me, sql)
        '    For i = 0 To paraNames.Length - 1
        '        aiSqlHelper.AddParameter(paraNames(i), paraValues(i))
        '    Next

        '    Return aiSqlHelper.Execute()
        'End Function

'        Public Function GetDtoListByItemList(Of DTO)(itemNames As String(), valueList As List(Of Object?())) As List(Of DTO)
'            Dim stringBuilder As StringBuilder = New StringBuilder()
'            Dim name = GetType(DTO).Name
'            name = name.Substring(0, name.Length - 3)
'            Dim num = itemNames.Length
'Dim list As List(Of String) = New List(Of String)()
'            Dim list2 As List(Of AiFieldInfo) = New List(Of AiFieldInfo)()
'            For Each value As Object() In valueList
'                Dim list3 As List(Of String) = New List(Of String)()
'                If list2.Count = 0 Then
'                    For i = 0 To num - 1
'                        Dim nm = itemNames(i)
'                        Dim tableInfo = AiGlobal.DbInfoProvider.GetTableInfo(Me, name)
'                        Dim item = tableInfo.FieldList.Find(Function(e) Equals(e.FieldName, nm))
'                        list2.Add(item)
'                    Next
'                End If

'                For j = 0 To num - 1
'                    Dim text = itemNames(j)
'                    Dim obj = value(j)
'                    Dim aiFieldInfo = list2(j)
'                    If obj Is Nothing Then
'                        list3.Add(text & " IS NULL")
'                        Continue For
'                    End If

'                    Dim parameterString = AiGlobal.DbApi.GetParameterString(aiFieldInfo.DbType, obj)
'                    list3.Add(text & " = " & parameterString)
'                Next

'                list.Add(String.Join(" AND ", list3))
'            Next

'            Dim text2 = "SELECT * FROM " & name & vbLf
'            text2 += "WHERE" & vbLf
'            text2 += String.Join(" OR ", list)
'            Dim connection As IDbConnection = Me.Connection
'            AiDbUtil.OpenConnection(connection)
'            Dim command = AiGlobal.DbApi.GetCommand(connection, text2)
'            Dim dataReader As IDataReader = command.ExecuteReader()
'            Dim list4 = GetList(Of DTO)(dataReader)
'            While dataReader.NextResult()
'            End While

'            Return list4
'        End Function

        'Public Function Query(Of T)(sql As String, ParamArray paraValues As Object?()) As List(Of T)
        '    Dim connection As IDbConnection = Me.Connection
        '    AiDbUtil.OpenConnection(connection)
        '    Dim command = AiGlobal.DbApi.GetCommand(connection, sql)
        '    Dim dataReader As IDataReader = command.ExecuteReader()
        '    Dim list = GetList(Of T)(dataReader)
        '    While dataReader.NextResult()
        '    End While

        '    Return list
        'End Function

        'Public Function Query(Of T1, T2)(sql As String, ParamArray paraValues As Object?()) As (List(Of T1), List(Of T2))
        '    Dim connection As IDbConnection = Me.Connection
        '    AiDbUtil.OpenConnection(connection)
        '    Dim command = AiGlobal.DbApi.GetCommand(connection, sql)
        '    Dim dataReader As IDataReader = command.ExecuteReader()
        '    Dim list = GetList(Of T1)(dataReader)
        '    dataReader.NextResult()
        '    Dim list2 = GetList(Of T2)(dataReader)
        '    While dataReader.NextResult()
        '    End While

        '    Return (list, list2)
        'End Function

        'Public Function Query(Of T1, T2, T3)(sql As String, ParamArray paraValues As Object?()) As (List(Of T1), List(Of T2), List(Of T3))
        '    Dim connection As IDbConnection = Me.Connection
        '    AiDbUtil.OpenConnection(connection)
        '    Dim command = AiGlobal.DbApi.GetCommand(connection, sql)
        '    Dim dataReader As IDataReader = command.ExecuteReader()
        '    Dim list = GetList(Of T1)(dataReader)
        '    dataReader.NextResult()
        '    Dim list2 = GetList(Of T2)(dataReader)
        '    dataReader.NextResult()
        '    Dim list3 = GetList(Of T3)(dataReader)
        '    While dataReader.NextResult()
        '    End While

        '    Return (list, list2, list3)
        'End Function

        'Public Function Query(Of T1, T2, T3, T4)(sql As String, ParamArray paraValues As Object?()) As (List(Of T1), List(Of T2), List(Of T3), List(Of T4))
        '    Dim connection As IDbConnection = Me.Connection
        '    AiDbUtil.OpenConnection(connection)
        '    Dim command = AiGlobal.DbApi.GetCommand(connection, sql)
        '    Dim dataReader As IDataReader = command.ExecuteReader()
        '    Dim list = GetList(Of T1)(dataReader)
        '    dataReader.NextResult()
        '    Dim list2 = GetList(Of T2)(dataReader)
        '    dataReader.NextResult()
        '    Dim list3 = GetList(Of T3)(dataReader)
        '    dataReader.NextResult()
        '    Dim list4 = GetList(Of T4)(dataReader)
        '    While dataReader.NextResult()
        '    End While

        '    Return (list, list2, list3, list4)
        'End Function

        'Public Function Query(Of T1, T2, T3, T4, T5)(sql As String, ParamArray paraValues As Object?()) As (List(Of T1), List(Of T2), List(Of T3), List(Of T4), List(Of T5))
        '    Dim connection As IDbConnection = Me.Connection
        '    AiDbUtil.OpenConnection(connection)
        '    Dim command = AiGlobal.DbApi.GetCommand(connection, sql)
        '    Dim dataReader As IDataReader = command.ExecuteReader()
        '    Dim list = GetList(Of T1)(dataReader)
        '    dataReader.NextResult()
        '    Dim list2 = GetList(Of T2)(dataReader)
        '    dataReader.NextResult()
        '    Dim list3 = GetList(Of T3)(dataReader)
        '    dataReader.NextResult()
        '    Dim list4 = GetList(Of T4)(dataReader)
        '    dataReader.NextResult()
        '    Dim list5 = GetList(Of T5)(dataReader)
        '    While dataReader.NextResult()
        '    End While

        '    Return (list, list2, list3, list4, list5)
        'End Function

        'Public Function Query(Of T1, T2, T3, T4, T5, T6)(sql As String, ParamArray paraValues As Object?()) As (List(Of T1), List(Of T2), List(Of T3), List(Of T4), List(Of T5), List(Of T6))
        '    Dim connection As IDbConnection = Me.Connection
        '    AiDbUtil.OpenConnection(connection)
        '    Dim command = AiGlobal.DbApi.GetCommand(connection, sql)
        '    Dim dataReader As IDataReader = command.ExecuteReader()
        '    Dim list = GetList(Of T1)(dataReader)
        '    dataReader.NextResult()
        '    Dim list2 = GetList(Of T2)(dataReader)
        '    dataReader.NextResult()
        '    Dim list3 = GetList(Of T3)(dataReader)
        '    dataReader.NextResult()
        '    Dim list4 = GetList(Of T4)(dataReader)
        '    dataReader.NextResult()
        '    Dim list5 = GetList(Of T5)(dataReader)
        '    dataReader.NextResult()
        '    Dim list6 = GetList(Of T6)(dataReader)
        '    While dataReader.NextResult()
        '    End While

        '    Return (list, list2, list3, list4, list5, list6)
        'End Function

        'Public Function Query(Of T1, T2, T3, T4, T5, T6, T7)(sql As String, ParamArray paraValues As Object?()) As (List(Of T1), List(Of T2), List(Of T3), List(Of T4), List(Of T5), List(Of T6), List(Of T7))
        '    Dim connection As IDbConnection = Me.Connection
        '    AiDbUtil.OpenConnection(connection)
        '    Dim command = AiGlobal.DbApi.GetCommand(connection, sql)
        '    Dim dataReader As IDataReader = command.ExecuteReader()
        '    Dim list = GetList(Of T1)(dataReader)
        '    dataReader.NextResult()
        '    Dim list2 = GetList(Of T2)(dataReader)
        '    dataReader.NextResult()
        '    Dim list3 = GetList(Of T3)(dataReader)
        '    dataReader.NextResult()
        '    Dim list4 = GetList(Of T4)(dataReader)
        '    dataReader.NextResult()
        '    Dim list5 = GetList(Of T5)(dataReader)
        '    dataReader.NextResult()
        '    Dim list6 = GetList(Of T6)(dataReader)
        '    dataReader.NextResult()
        '    Dim list7 = GetList(Of T7)(dataReader)
        '    While dataReader.NextResult()
        '    End While

        '    Return (list, list2, list3, list4, list5, list6, list7)
        'End Function

        'Public Function GetValueList(sql As String) As List(Of Object?)
        '    Dim connection As IDbConnection = Me.Connection
        '    AiDbUtil.OpenConnection(connection)
        '    Dim command = AiGlobal.DbApi.GetCommand(connection, sql)
        '    Dim dataReader As IDataReader = command.ExecuteReader()
        '    Dim list As List(Of Object) = New List(Of Object)()
        '    While dataReader.Read()
        '        Dim obj = dataReader.GetValue(0)
        '        If obj Is DBNull.Value Then
        '            obj = Nothing
        '        End If

        '        list.Add(obj)
        '        If Not dataReader.NextResult() Then
        '            Return list
        '        End If
        '    End While

        '    While dataReader.NextResult()
        '    End While

        '    Return list
        'End Function

        'Private Function GetList(Of T)(reader As IDataReader) As List(Of T)
        '    Dim typeFromHandle = GetType(T)
        '    Dim properties As PropertyInfo() = typeFromHandle.GetProperties()
        '    Dim dictionary = properties.ToDictionary(Function(e) e.Name, Function(e) e)
        '    Dim list As List(Of T) = New List(Of T)()
        '    While reader.Read()
        '        If GetType(T) Is GetType(String) OrElse GetType(T) Is GetType(Integer) OrElse GetType(T) Is GetType(Single) OrElse GetType(T) Is GetType(Double) OrElse GetType(T) Is GetType(Decimal) Then
        '            Dim value = reader.GetValue(0)
        '            list.Add(value
        '                     )
        '            Continue While
        '        End If

        '        Dim val As T = Activator.CreateInstance(Of T)()
        '        For i = 0 To reader.FieldCount - 1
        '            Dim obj = reader.GetValue(i)
        '            Dim name = reader.GetName(i)
        '            If Not dictionary.ContainsKey(name) Then
        '                Continue For
        '            End If

        '            Dim propertyInfo = dictionary(name)
        '            If obj IsNot Convert.DBNull Then
        '                If propertyInfo.PropertyType.IsEnum AndAlso TypeOf obj Is String Then
        '                    obj = Convert.ToInt32(obj)
        '                End If

        '                If Nullable.GetUnderlyingType(propertyInfo.PropertyType) Is GetType(Integer) AndAlso obj.GetType() Is GetType(Short) Then
        '                    obj = Convert.ToInt32(obj)
        '                End If

        '                propertyInfo.SetValue(val, obj)
        '            End If
        '        Next

        '        list.Add(val)
        '    End While

        '    Return list
        'End Function

'        Public Function GetAllValueList(sql As String) As List(Of Object?)
'            Dim connection As IDbConnection = Me.Connection
'            AiDbUtil.OpenConnection(connection)
'            Dim command = AiGlobal.DbApi.GetCommand(connection, sql)
'            Dim dataReader As IDataReader = command.ExecuteReader()
'            Dim list As List(Of Object) = New List(Of Object)()
'            Do
'                Dim obj As Object = Nothing
'                While dataReader.Read()
'                    obj = dataReader.GetValue(0)
'                    If obj Is DBNull.Value Then
'                        obj = Nothing
'                    End If
'                End While

'                list.Add(obj)
'            Loop While dataReader.NextResult()
'Return list
'        End Function

        Public Sub Dispose() 
            If Connection IsNot Nothing Then
                Connection.Close()
                Connection.Dispose()
                Connection = Nothing
            End If
        End Sub
    End Class
End Namespace
