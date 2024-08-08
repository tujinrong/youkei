' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ベースロジック
'             サービス処理
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service
    Public Class CmServiceBase

        Private _currentMethod As System.Reflection.MethodBase

        Protected Property currentMethod As MethodBase
            Get
                Return _currentMethod
            End Get
            Private Set(value As MethodBase)
                _currentMethod = value
            End Set
        End Property
  

        ''' <summary>
        ''' トランザクション処理（NoLock）NEW
        ''' </summary>
        <DebuggerStepThrough()>
        Public Shared  Function Nolock(Of R As DaResponseBase)(req As DaRequestBase, f As Func(Of DaDbContext, R)) As R
            Dim currentMethod = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod()
            Using db = New DaDbContext(req)
                ' トランザクション
                Using tran = db.Session.Connection.BeginTransaction()
                    Try
                        ' サービス名とメソッド名を取得する
                        req.SetMethodInfo(currentMethod)

                        ' 前処理
                        BeforeAction(db, req)
                        Dim res = f(db)

                        ' 後処理
                        AfterAction(db, res)
                        tran.Commit()
                        Return res
                    Catch ex As Exception
                        tran.Rollback()
                        Return GetExcetionResponse(Of R)(db, ex, currentMethod.Name)
                    End Try
                End Using
            End Using
        End Function


        ''' <summary>
        ''' トランザクション NEW
        ''' </summary>
        <DebuggerStepThrough()>
        Public Function Transction(Of R As DaResponseBase)(req As DaRequestBase, f As Func(Of DaDbContext, R)) As R
            currentMethod = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod()
             Using db = New DaDbContext(req)
                ' トランザクション
                Using tran = db.Session.Connection.BeginTransaction()
                    Try
                        ' サービス名とメソッド名を取得する
                        req.SetMethodInfo(currentMethod)

                        ' 前処理
                        BeforeAction(db, req)
                        Dim res = f(db)

                        ' 後処理
                        AfterAction(db, res)
                        tran.Commit()
                        Return res
                    Catch ex As Exception
                        tran.Rollback()
                        Return GetExcetionResponse(Of R)(db, ex, currentMethod.Name)
                    End Try
                End Using
            End Using
        End Function


        ''' <summary>
        ''' 処理前処理 NEW
        ''' </summary>
        Public Shared Sub BeforeAction(db As DaDbContext, req As DaRequestBase)
            db.Session.SessionData(DaConst.SessionID) = req.sessionid
            If String.IsNullOrEmpty(req.USER_ID) Then
                req.USER_ID = req.sessionid.ToString()
                If Not String.IsNullOrEmpty(req.token) Then
                    Dim userIdStr = JbdGjsTokenService.GetTokenUDGjs(req.token, "gjs", "gjs")
                    Dim userId = userIdStr.Split("|")
                    db.Session.UserID = userId(0)
                End If
            End If
            DaDbLogService.WriteDbMessage(db, "Begin Service")
        End Sub


        Public Shared  Sub AfterAction(db As DaDbContext, res As DaResponseBase)
            DaDbLogService.WriteDbMessage(db, "End Service")
        End Sub


       Public Shared Function GetExcetionResponse(Of R)(db As DaDbContext, ex As Exception, method As String) As R
            Dim res As R = Activator.CreateInstance(Of R)()
            DaDbLogService.WriteDbException(db, ex)
            DaLogService.WriteException(method, ex)
            Return res
        End Function

    End Class

End Namespace
