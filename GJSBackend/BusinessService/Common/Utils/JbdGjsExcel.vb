'*******************************************************************************
'*　　①　モジュール名　　　JbdGjsExcel
'*
'*　　②　機能概要　　　　　Excel出力用共通モジュール
'*
'*  　③　更新履歴　　　　　2009/11/04 JBD368　新規作成
'*                                             ※今回使用しない関数は動作未確認のため、コメントとします。
'*                                               使用する際に動作検証を行ったうえ、コンパイルしてください。
'*                                             
'*******************************************************************************
Option Strict Off
Option Explicit On



Public Class JbdGjsExcel

    '≪EXCEL≫
    Dim Xlapp As Object
    Dim XlBook As Object
    Dim XlSheet As Object
    Dim xlBooks As Object
    Dim xlSheets As Object

    Dim XlappRun As Boolean
    Dim setcell As String
    Dim SrcXlBook As Object
    Dim SrcXlSheet As Object

    Dim MgnL As String        '左マージン
    Dim MgnR As String        '右マージン
    Dim MgnT As String        '上マージン
    Dim MgnB As String        '下マージン
    Dim MgnH As String        'ヘッダマージン
    Dim MgnF As String        'フッタマージン

    Const PosL = 1   '左
    Const PosC = 2   '中央
    Const PosR = 3   '右

    Dim wCol() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
    Const Col_Cnt As Integer = 26
    Const WC_FUNC_NAME As String = "sImport"

    '************************************************************************************************
    '********************************* ≪　　　　エクセル　　　　≫ *********************************
    '************************************************************************************************
    '--------------------------------------------------------------
    'ｅｘｃｅｌ起動
    '--------------------------------------------------------------
    Public Function XlInitialize() As Boolean
        Try
            '≪EXCEL起動≫
            Xlapp = CreateObject("Excel.Application")
            '≪EXCEL表示≫
            Xlapp.Visible = False
            '≪EXCELワークブックOPEN（新規）≫
            XlBook = Xlapp.Workbooks.Add        '新しいブック ファイルを作成
            Xlapp.SheetsInNewWorkbook = 1     'ブックに含まれるワークシートの数
            XlSheet = XlBook.Worksheets(1)
            Xlapp.DisplayAlerts = True
            Return True
        Catch ex As Exception
            Throw New Exception("Ｅｘｃｅｌがセットアップされている必要があります。" & vbCrLf & "保存できませんでした。")
            Return False
        End Try
    End Function

    '--------------------------------------------------------------
    'ファイルを別名で保存
    '--------------------------------------------------------------
    Public Function XlSave(ByVal vNewValue As String, Optional ByVal vFormat As String = "") As Boolean
        Try

            Xlapp.DisplayAlerts = False     '保存時の問合せのダイアログを非表示に設定

            If Right(vNewValue, 4) <> ".xls" Then
                vNewValue = vNewValue & ".xls"
            End If

            If vFormat <> "" Then
                XlBook.SaveAs(FileName:=vNewValue, FileFormat:=vFormat)
            Else
                XlBook.SaveAs(FileName:=vNewValue)
            End If
            Return True
        Catch ex As Exception
            xlCloseComObject()       'エラー発生時、アプリケーションを終了処理をする。   2019/02/01 JBD368 ADD
            Throw New Exception(ex.Message)
        End Try
    End Function

    '2015/03/23 ADD
    '--------------------------------------------------------------
    'ファイルを別名で保存
    '--------------------------------------------------------------
    Public Function XlSave_xlsx(ByVal vNewValue As String, Optional ByVal vFormat As String = "") As Boolean
        Try

            Xlapp.DisplayAlerts = False     '保存時の問合せのダイアログを非表示に設定

            If Right(vNewValue, 5) <> ".xlsx" Then
                vNewValue = vNewValue & ".xlsx"
            End If

            If vFormat <> "" Then
                XlBook.SaveAs(FileName:=vNewValue, FileFormat:=vFormat)
            Else
                XlBook.SaveAs(FileName:=vNewValue)
            End If
            Return True
        Catch ex As Exception
            xlCloseComObject()       'エラー発生時、アプリケーションを終了処理をする。   2019/02/01 JBD368 ADD
            Throw New Exception(ex.Message)
        End Try
    End Function
    '2015/03/23 END


    '--------------------------------------------------------------
    'ｅｘｃｅｌ終了時の処理
    '--------------------------------------------------------------
    Public Sub XlClose()

        Try
            If Not Xlapp Is Nothing Then
                Xlapp.DisplayAlerts = False     '保存時の問合せのダイアログを非表示に設定
                Xlapp.Quit()
                XlSheet = Nothing
                XlBook = Nothing
                Xlapp = Nothing
            End If
            GC.Collect()
        Catch ex As Exception
            xlCloseComObject()       'エラー発生時、アプリケーションを終了処理をする。   2019/02/01 JBD368 ADD
            Throw New Exception(ex.Message)
        End Try

    End Sub

    '2015/03/23 START
    '-----------------------------------------------------------
    '概要：行のコピー
    '引数　  pos :  Row　（コピー行の範囲)  : String
    '-----------------------------------------------------------
    Public Sub SetRangeCopy(ByVal pos As String, ByVal rowCnt As Integer)

        Dim RangeToRow As Object
        Dim CopyRange As Object
        Dim iCnt As Integer

        RangeToRow = XlSheet.Rows
        CopyRange = Nothing

        CopyRange = RangeToRow(pos)
        CopyRange.Copy()
        For iCnt = 0 To rowCnt - 1
            CopyRange.Insert()
        Next

        MRComObject(RangeToRow)          'ReleaseComObjectで解放する処理
        'RangeToRow = Nothing
        MRComObject(CopyRange)
        'CopyRange = Nothing
    End Sub

    '-----------------------------------------------------------
    '概要：指定行の削除
    '引数　  pos :  Row　（削除行の範囲)  : String
    '-----------------------------------------------------------
    Public Sub SetRangeDelete(ByVal pos As String)
        Dim RangeToRow As Object
        Dim CopyRange As Object

        RangeToRow = XlSheet.Rows
        CopyRange = Nothing

        CopyRange = RangeToRow(pos)
        CopyRange.delete()

        MRComObject(RangeToRow)          'ReleaseComObjectで解放する処理
        'RangeToRow = Nothing
        MRComObject(CopyRange)
        'CopyRange = Nothing
    End Sub

    '-----------------------------------------------------------
    '概要：行設定
    '引数　  pos :  Row　（行の設定)  : String
    '-----------------------------------------------------------
    Public Sub SetOneRangeValue(ByVal row As Integer, ByVal col As Integer, ByVal val(,) As Object)
        Dim rngTarget As Object
        Dim rngFrom As Object
        Dim rngTo As Object
        Dim xlCells As Object

        xlCells = XlSheet.Cells

        '始点
        rngFrom = DirectCast(xlCells(row, 1), Object)
        '終点
        rngTo = DirectCast(xlCells(row, col), Object)
        'セル範囲
        rngTarget = XlSheet.Range(rngFrom, rngTo)
        '貼り付け
        rngTarget.Value = val


        MRComObject(rngTarget)          'ReleaseComObjectで解放する処理
        'rngTarget = Nothing
        MRComObject(rngFrom)
        'rngFrom = Nothing
        MRComObject(rngTo)
        'rngTo = Nothing
        MRComObject(xlCells)
        'xlCells = Nothing
    End Sub

    '-----------------------------------------------------------
    '概要：行設定
    '引数　  pos :  Row　（行の設定)  : String
    '-----------------------------------------------------------
    Public Sub SetRangeValue(ByVal startRow As Integer, ByVal EndRow As Integer, ByVal col As Integer, ByVal val(,) As Object)
        Dim rngTarget As Object
        Dim rngFrom As Object
        Dim rngTo As Object
        Dim xlCells As Object

        xlCells = XlSheet.Cells


        '始点
        rngFrom = DirectCast(xlCells(startRow, 1), Object)
        '終点
        rngTo = DirectCast(xlCells(EndRow, col), Object)
        'セル範囲
        rngTarget = XlSheet.Range(rngFrom, rngTo)
        '貼り付け
        rngTarget.Value = val


        MRComObject(rngTarget)          'ReleaseComObjectで解放する処理
        'rngTarget = Nothing
        MRComObject(rngFrom)
        'rngFrom = Nothing
        MRComObject(rngTo)
        'rngTo = Nothing
        MRComObject(xlCells)
        'xlCells = Nothing
    End Sub
    '2015/03/23 END



    '-----------------------------------------------------------
    '概要：特定のセルに値をセットする
    '引数　  r   :  Row　（セルの行番号)  : Integer
    '　　　　c   :  Cell （セルの列番号)  : Integer
    '　　　　d   :  セットする内容        : Object
    '-----------------------------------------------------------
    Public Sub SetdataCell(ByVal r As Integer, ByVal c As Integer, ByVal d As Object)
        SetdataCell(r, c, d, -1)
    End Sub
    Public Sub SetdataCell(ByVal r As Integer, ByVal c As Integer, ByVal d As Object, ByVal FontColorIndex As Integer)
        Dim xlCells As Object
        Dim xlCell As Object
        xlCells = XlSheet.Cells
        xlCell = XlSheet.Cells(r, c)
        xlCell.Value = d
        If FontColorIndex <> -1 Then
            xlCell.font.ColorIndex = FontColorIndex
        End If
        MRComObject(xlCell)
        MRComObject(xlCells)
    End Sub

    '-----------------------------------------------------------
    '概要：ファイル存在確認、テンプレートファイルコピー
    '引数   TempFName   :   テンプレートファイル名    : String
    '　　   SaveFName   :   新規作成ファイル名        : String
    '-----------------------------------------------------------
    Public Function SetExcelFile(ByVal TempFName As String, ByVal SaveFName As String) As Boolean

        Try
            Dim xlSavePath As String

            If Left(TempFName, 1) <> "\" Then
                TempFName = "\" & TempFName
            End If
            If Right(TempFName, 4) = ".xls" Then
                TempFName = TempFName
            Else
                TempFName += ".xls"
            End If

            If Right(SaveFName, 4) = ".xls" Then
                xlSavePath = SaveFName
            Else
                xlSavePath = SaveFName & ".xls"
            End If

            Dim xlFilePath As String = System.IO.Directory.GetCurrentDirectory & TempFName
            If Not System.IO.File.Exists(xlFilePath) Then Throw New Exception("テンプレートファイルが存在しません。")
            If System.IO.File.Exists(xlSavePath) Then
                'If MessageBox.Show("この場所に '" & xlSavePath & "'という名前のファイルが既にあります。置き換えますか？", _
                '                        "上書き確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.No Then
                '    Return False
                'Else
                System.IO.File.Delete(xlSavePath)
                'End If
            End If
            System.IO.File.Copy(xlFilePath, xlSavePath)

            Return True

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try


    End Function

    '2015/03/23 START
    '-----------------------------------------------------------
    '概要：ファイル存在確認、テンプレートファイルコピー(xlsx)
    '引数   TempFName   :   テンプレートファイル名    : String
    '　　   SaveFName   :   新規作成ファイル名        : String
    '-----------------------------------------------------------
    Public Function SetExcelFile_xlsx(ByVal TempFName As String, ByVal SaveFName As String) As Boolean

        Try
            Dim xlSavePath As String

            If Left(TempFName, 1) <> "\" Then
                TempFName = "\" & TempFName
            End If
            If Right(TempFName, 5) = ".xlsx" Then
                TempFName = TempFName
            Else
                TempFName += ".xlsx"
            End If

            If Right(SaveFName, 5) = ".xlsx" Then
                xlSavePath = SaveFName
            Else
                xlSavePath = SaveFName & ".xlsx"
            End If
            Dim myTEMPLATE_EXCEL_PATH
            'Dim xlFilePath As String = System.IO.Directory.GetCurrentDirectory & TempFName
            '2015/10/06　修正開始
            'INIファイルのTEMPLATE_EXCEL_PATHの最後が\のとき、エラーとなるのを修正
            If Right(myTEMPLATE_EXCEL_PATH, 1) = "\" Then
                myTEMPLATE_EXCEL_PATH = Mid(myTEMPLATE_EXCEL_PATH, 1, myTEMPLATE_EXCEL_PATH.Length - 1)
            End If
            '2015/10/06　修正開始
            Dim xlFilePath As String = myTEMPLATE_EXCEL_PATH & TempFName


            If Not System.IO.File.Exists(xlFilePath) Then Throw New Exception("テンプレートファイルが存在しません。")
            If System.IO.File.Exists(xlSavePath) Then
                'If MessageBox.Show("この場所に '" & xlSavePath & "'という名前のファイルが既にあります。置き換えますか？", _
                '                        "上書き確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.No Then
                '    Return False
                'Else
                System.IO.File.Delete(xlSavePath)
                'End If
            End If
            System.IO.File.Copy(xlFilePath, xlSavePath)

            Return True

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    '2015/03/23 END



    '-----------------------------------------------------------
    '概要： 保存処理(WorkBookへの変更保存)
    '       
    '-----------------------------------------------------------
    Public Function xlSaveWorkBook(ByVal FName As String) As Boolean

        Try
            Xlapp.DisplayAlerts = False     '保存時の問合せのダイアログを非表示に設定

            Dim xlOpenFName As String
            If Right(FName, 4) = ".xls" Then
                xlOpenFName = FName
            Else
                xlOpenFName = FName & ".xls"
            End If

            XlBook.Worksheets(1).Activate()            '先頭シートをアクティブにします
            XlBook.SaveAs(FileName:=xlOpenFName)       'ブックを引数のファイル名で保存

            Return True
        Catch ex As Exception
            xlCloseComObject()
            Throw New Exception(ex.Message)
        End Try
    End Function

    '-----------------------------------------------------------
    '概要： 保存処理(WorkSheetへの変更保存)
    '       
    '-----------------------------------------------------------
    Public Function xlSaveWorkSheet(ByVal FName As String) As Boolean

        Try
            Xlapp.DisplayAlerts = False     '保存時の問合せのダイアログを非表示に設定

            Dim xlOpenFName As String
            If Right(FName, 4) = ".xls" Then
                xlOpenFName = FName
            Else
                xlOpenFName = FName & ".xls"
            End If

            XlSheet.SaveAs(FileName:=xlOpenFName)       'シートを引数のファイル名で保存

            Return True
        Catch ex As Exception
            xlCloseComObject()
            Throw New Exception(ex.Message)
        End Try
    End Function

    '-----------------------------------------------------------
    '概要： 終了処理(COMオブジェクト解放)
    '-----------------------------------------------------------
    Public Function xlCloseComObject() As Boolean

        Try

            MRComObject(XlSheet)
            MRComObject(xlSheets)
            XlBook.close(False)         'False: 保存確認しない
            MRComObject(XlBook)
            xlBooks.Close()
            MRComObject(xlBooks)
            Xlapp.Quit()                 'Excelを閉じる    
            MRComObject(Xlapp)

            System.GC.Collect()
            'System.Windows.Forms.Application.DoEvents()

            'メモリを解放します
            ' Call s_GC_Dispose()

            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    '-----------------------------------------------------------
    '概要：起動(テンプレートを使用してオープン)
    '引数    :  OpenName   : オープンするファイル名
    '　　    :  SheetName  : シート名
    '戻り値  :  Boolean(True:正常終了　False:エラー)
    '-----------------------------------------------------------
    Public Function XlOpen(ByVal OpenFName As String, ByVal SheetName As String) As Boolean

        Try
            Dim s As String
            If Right(OpenFName, 4) = ".xls" Then
                s = OpenFName
            Else
                s = OpenFName & ".xls"
            End If

            '≪EXCEL起動≫
            Xlapp = CreateObject("Excel.Application")
            '≪EXCELワークブックOPEN（既存）≫
            xlBooks = Xlapp.WorkBooks
            XlBook = xlBooks.Open(s)
            xlSheets = XlBook.Worksheets
            XlSheet = xlSheets(SheetName)

            '≪EXCEL表示≫
            Xlapp.Visible = False        'Excelを非表示
            Xlapp.DisplayAlerts = True

            Return True

        Catch ex As Exception
            Throw New Exception("Ｅｘｃｅｌがセットアップされている必要があります。" & vbCrLf & "保存できませんでした。")
            Return False
        End Try

    End Function

    '2015/03/23 START
    '-----------------------------------------------------------
    '概要：起動(テンプレートを使用してオープン)(xlsx)
    '引数    :  OpenName   : オープンするファイル名
    '　　    :  SheetName  : シート名
    '戻り値  :  Boolean(True:正常終了　False:エラー)
    '-----------------------------------------------------------
    Public Function XlOpen_xlsx(ByVal OpenFName As String, ByVal SheetName As String) As Boolean

        Try
            Dim s As String
            If Right(OpenFName, 5) = ".xlsx" Then
                s = OpenFName
            Else
                s = OpenFName & ".xlsx"
            End If

            '≪EXCEL起動≫
            Xlapp = CreateObject("Excel.Application")
            '≪EXCELワークブックOPEN（既存）≫
            xlBooks = Xlapp.WorkBooks
            XlBook = xlBooks.Open(s)
            xlSheets = XlBook.Worksheets
            XlSheet = xlSheets(SheetName)

            '≪EXCEL表示≫
            Xlapp.Visible = False        'Excelを非表示
            Xlapp.DisplayAlerts = True

            Return True

        Catch ex As Exception
            Throw New Exception("Ｅｘｃｅｌがセットアップされている必要があります。" & vbCrLf & "保存できませんでした。")
            Return False
        End Try
    End Function
    '2015/03/23 END

    '--------------------------------------------------------------------
    'COM オブジェクトの使用後、明示的に COM オブジェクトへの参照を解放する
    '引数   objCom  :   解放するオブジェクト  : Object
    '--------------------------------------------------------------------
    Public Sub MRComObject(ByRef objCom As Object)

        Try
            '提供されたランタイム呼び出し可能ラッパーの参照カウントをデクリメントします
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objCom)

        Catch
        Finally
            '参照を解除する
            objCom = Nothing
        End Try
    End Sub

    '--------------------------------------------------------------------
    'TemplateSheetCopy     テンプレートシートをコピーし名前をつける
    '引数   SheetName  :   対象シート名
    '--------------------------------------------------------------------
    Public Sub TemplateSheetCopy(ByVal SheetName As String)
        Try

            '同じワークシート名がないか確認します。
            For Each myWS As Object In XlBook.Sheets
                If myWS.Name = SheetName Then
                    Throw New Exception("シート名:" & SheetName & " は既に使われています。")
                End If
            Next

            '先頭のワークシートをコピーし一番後ろに貼り付けます。
            XlBook.Worksheets(1).Activate()
            XlBook.ActiveSheet.Copy(After:=XlBook.Worksheets(XlBook.Worksheets.count))

            '対象のワークシートに名前を付けます。
            XlBook.ActiveSheet.Name = SheetName
            XlSheet = xlSheets(SheetName)

        Catch ex As Exception
            xlCloseComObject()       'エラー発生時、アプリケーションを終了処理をする。   2019/02/01 JBD368 ADD
            Throw New Exception(ex.Message)
        End Try

    End Sub

    '--------------------------------------------------------------------
    'WorkSheetDelete       対象シートを削除する
    '引数   IndexSheet  :  対象シートINDEX番号
    '--------------------------------------------------------------------
    Public Sub WorkSheetDelete(ByVal IndexSheet As Integer)
        Try

            Xlapp.DisplayAlerts = False    '---警告メッセージ非表示

            '対象シートをアクティブシートにする
            XlBook.Worksheets(IndexSheet).Activate()
            '対象シートを削除
            XlBook.ActiveSheet.Delete()

        Catch ex As Exception
            xlCloseComObject()       'エラー発生時、アプリケーションを終了処理をする。   2019/02/01 JBD368 ADD
            Throw New Exception(ex.Message)
        End Try

    End Sub
    '--------------------------------------------------------
    '概要：罫線の描画
    '引数： xlCells     :  描画する範囲　例)"A1","A1:C3"
    '　　   xlIndex     :  描画する場所　例)下端 = 9
    '　　   xlLineStyle :  線の種類      例)実線 = 1
    '　　   xlWeight    :  線の太さ      例)極細線  = 1
    '--------------------------------------------------------
    Public Sub SetLineRange(ByVal xlCells As String, ByVal xlIndex As Integer, ByVal xlLineStyle As Integer, ByVal xlWeight As Integer)
        'Dim objCells As Object
        'objCells = xlsheet.Cells

        XlSheet.Range(xlCells).Borders(xlIndex).LineStyle = xlLineStyle      '下線
        XlSheet.Range(xlCells).Borders(xlIndex).Weight = xlWeight

        'MRComObject(objCells)


    End Sub
    '******************************************************************************
    '使用目的:指定された文字列が""の時代替文字列に置き換えます。
    '関数名　:F_Mid_Word
    '引数　　:P_str :文字列を指定します。
    '引数　　:R_str :代替文字列を指定します。
    '******************************************************************************
    Private Shared Function Nz(ByVal P_str As String, ByVal R_str As String) As String
        If P_str = Nothing Or Trim(P_str) = "" Then
            Return R_str
        Else
            Return Trim(P_str)
        End If
    End Function
    '/
    '******************************************************************************
    '使用目的:指定された文字列が""の時、DBNULL.Valueに置き換えます。
    '関数名　:DbNullVal
    '引数　　:P_str :文字列を指定します。
    '******************************************************************************
    Private Function DbNullVal(ByVal P_str As String) As Object

        If P_str = Nothing Or P_str = "" Then
            Return DBNull.Value
        Else
            Return P_str
        End If

    End Function
    '/
    '******************************************************************************
    '使用目的:指定されたＤＢ文字列がNullの時代替文字列に置き換えます。
    '関数名　:F_Mid_Word
    '引数　　:P_str :文字列を指定します。
    '引数　　:R_str :代替文字列を指定します。
    '******************************************************************************
    Private Shared Function DbNz(ByVal Obj As Object, ByVal R_str As String) As String

        If IsDBNull(Obj) Then
            Return R_str
        Else
            Return Obj
        End If

    End Function

#Region "コメントにした関数 ※使用する場合は動作検証後、上へ移動してください。"
    ''***************************************************************************
    '' 概要    : クリップボード内容の貼り付け
    ''
    '' ﾊﾟﾗﾒｰﾀ  : 変数名  ,IO ,型 ,説明
    ''         :         ,I  ,   ,設定先対象範囲(開始:行)
    ''         :         ,I  ,   ,設定先対象範囲(開始:列)
    ''         :         ,I  ,   ,設定先対象範囲(終了:行)
    ''         :         ,I  ,   ,設定先対象範囲(終了:列)
    ''         : 戻り値  ,   ,   ,True:正常 False:異常
    ''
    '' 説明    : 任意の範囲
    ''
    ''***************************************************************************
    ''Public Overloads Function XlPaste( _
    ''        ByVal vPlngDstStartRow As Long, _
    ''        ByVal vPlngDstStartCol As Long, _
    ''        ByVal vPlngDstEndRow As Long, _
    ''        ByVal vPlngDstEndCol As Long _
    ''    ) As Boolean

    'Public Overloads Function XlPaste( _
    '        ByVal vPlngDstStartRow As Integer, _
    '        ByVal vPlngDstStartCol As Integer, _
    '        ByVal vPlngDstEndRow As Integer, _
    '        ByVal vPlngDstEndCol As Integer _
    '    ) As Boolean

    '    Try
    '        '貼り付け(全て)
    '        With XlSheet
    '            .Range(.Cells(vPlngDstStartRow, vPlngDstStartCol), _
    '                   .Cells(vPlngDstEndRow, vPlngDstEndCol)).PasteSpecial()
    '        End With

    '        Return True
    '    Catch ex As Exception
    '        '---- Sub_ErrorWrite(ex.ToString,Sql文)---User名・Active画面名・日付：時刻等はﾓｼﾞｭｰﾙ内で取得する。
    '        MsgBox(ex.ToString)
    '        'Fnc_Msg(ex.ToString, 9, "[EXCEL：クリップボード内容の貼り付け(sPaste)]")
    '        Return False
    '    End Try

    'End Function

    ''***************************************************************************
    '' 概要    : クリップボード内容の貼り付け
    ''
    '' ﾊﾟﾗﾒｰﾀ  : 変数名  ,IO ,型 ,説明
    ''         : 戻り値  ,   ,   ,True:正常 False:異常
    ''***************************************************************************
    'Public Overloads Function XlPaste() As Boolean

    '    Try
    '        'Excelシート以外からの貼り付け(値のみ)
    '        'XlSheet.PasteSpecial(Format:="テキスト", Link:=False, DisplayAsIcon:=False)
    '        XlSheet.PasteSpecial()

    '        Return True
    '    Catch ex As Exception
    '        '---- Sub_ErrorWrite(ex.ToString,Sql文)---User名・Active画面名・日付：時刻等はﾓｼﾞｭｰﾙ内で取得する。
    '        MsgBox(ex.ToString)
    '        'Fnc_Msg(ex.ToString, 9, "[EXCEL：クリップボード内容の貼り付け(sPaste)]")
    '        Return False
    '    End Try

    'End Function

    ''***************************************************************************
    '' 概要    : 位置指定
    ''
    '' ﾊﾟﾗﾒｰﾀ  : 変数名  ,IO ,型 ,説明
    ''         :         ,I  ,   ,設定先行
    ''         : 戻り値  ,   ,   ,True:正常 False:異常
    ''
    '' 説明    : 任意の範囲
    ''
    ''***************************************************************************
    ''Public Overloads Function XlRange(ByVal vPlngDstStartRow As Long) As Boolean
    'Public Overloads Function XlRange(ByVal vPlngDstStartRow As Integer) As Boolean

    '    Try
    '        '位置付け
    '        With XlSheet
    '            .Range("A" & vPlngDstStartRow & ":A" & vPlngDstStartRow).Select()
    '        End With

    '        Return True
    '    Catch ex As Exception
    '        '---- Sub_ErrorWrite(ex.ToString,Sql文)---User名・Active画面名・日付：時刻等はﾓｼﾞｭｰﾙ内で取得する。
    '        MsgBox(ex.ToString)
    '        'Fnc_Msg(ex.ToString, 9, "[EXCEL：位置指定(XlRange)]")
    '        Return False
    '    End Try

    'End Function
    ''=======================================================================================
    ''=     機　　能 : データセットよりExcelへ転送する
    ''=     引　　数 : ARG1 - データテーブル
    ''=     引　　数 : ARG3 - ヘッダータイトル名
    ''=     引　　数 : ARG4 - 表示可否
    ''=     引　　数 : ARG5 - 表示位置 (0: 1: 2: 3: 4: )
    ''=     引　　数 : ARG6 - 書式
    ''=======================================================================================
    'Public Overloads Sub Sub_ExcelViewC1(ByVal MyDt As DataTable, _
    '                                     ByVal NameAry() As String, ByVal ClmAry() As Byte, _
    '                                     ByVal AlignAry() As Byte, ByVal FormatAry() As Byte)
    '    Dim MyCol As DataColumn
    '    Dim iCol As Integer
    '    Dim iRow As Integer
    '    Dim w_Range As String
    '    Dim i As Integer

    '    Try
    '        '---- Excel起動
    '        Call XlInitialize()

    '        iRow = 1
    '        iCol = 0
    '        '---- タイトル部
    '        For i = 0 To MyDt.Columns.Count - 1
    '            MyCol = MyDt.Columns(i)
    '            If ClmAry(i) = 1 Then
    '                iCol += 1
    '                w_Range = Fnc_XlColCnv(iCol) & CStr(iRow)
    '                XlSheet.Range(w_Range).Value = NZ(NameAry(i), MyCol.Caption)
    '            End If
    '        Next

    '        Call XlFormat(FormatAry, ClmAry)
    '        Call XlAlignAry(AlignAry, ClmAry)

    '        For iRow = 0 To MyDt.Rows.Count - 1
    '            iCol = 0
    '            For i = 0 To MyDt.Columns.Count - 1
    '                If ClmAry(i) = 1 Then
    '                    iCol += 1
    '                    w_Range = Fnc_XlColCnv(iCol) & CStr(iRow + 2)
    '                    If FormatAry(i) = 1 Then
    '                        XlSheet.Range(w_Range).Value = "'" & DbNz(MyDt.Rows(iRow).Item(i), "")
    '                    Else
    '                        XlSheet.Range(w_Range).Value = DbNz(MyDt.Rows(iRow).Item(i), "")
    '                    End If
    '                End If
    '            Next
    '        Next
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Public Function Fnc_XlColCnv(ByVal vPlngDstCol As Integer) As String

    '    Dim s As String
    '    Dim i As Integer

    '    Try
    '        '位置付け
    '        If vPlngDstCol > Col_Cnt Then
    '            i = Fix(CSng(vPlngDstCol / Col_Cnt)) '2005/09/22 jbd202 Update 
    '            s = wCol(i - 1)
    '            i = vPlngDstCol - Col_Cnt * i
    '            s = s & wCol(i - 1)
    '        Else
    '            s = wCol(vPlngDstCol - 1)
    '        End If

    '        Return s
    '    Catch ex As Exception
    '        Return ""
    '    End Try

    'End Function
    ''***************************************************************************
    '' 概要    : データの取り込み
    ''
    '' ﾊﾟﾗﾒｰﾀ  : 変数名  ,IO ,型 ,説明
    ''         :         ,I  ,   ,データファイル名
    ''         : 戻り値  ,   ,   ,True:正常 False:異常
    ''
    '' 説明    :
    ''
    ''    定数 説明 
    ''1 xlGeneralFormat 一般 
    ''2 xlTextFormat テキスト 
    ''xlSkipColumn スキップ列 
    ''xlDMYFormat DMY (日月年) 形式の日付 
    ''xlDYMFormat DYM (日年月) 形式の日付 
    ''xlEMDFormat EMD (台湾年月日) 形式の日付 
    ''xlMDYFormat MDY (月日年) 形式の日付 
    ''xlMYDFormat MYD (月年日) 形式の日付 
    ''xlYDMFormat YDM (年日月) 形式の日付 
    ''xlYMDFormat YMD (年月日) 形式の日付 

    ''***************************************************************************
    'Public Function sImport(ByVal vPstrFilename As String, _
    '                        ByVal vFormatAry As Array) As Boolean

    '    Try
    '        With XlSheet.QueryTables.Add(Connection:="TEXT;" & vPstrFilename, _
    '            Destination:=XlSheet.Range("A1"))
    '            .Name = XlSheet.Name
    '            .FieldNames = True
    '            .RowNumbers = False
    '            .FillAdjacentFormulas = False
    '            .PreserveFormatting = True
    '            .RefreshOnFileOpen = False
    '            .RefreshStyle = 0           'xlOverwriteCells
    '            .SavePassword = False
    '            .SaveData = False
    '            .AdjustColumnWidth = True
    '            .RefreshPeriod = 0
    '            .TextFilePromptOnRefresh = False
    '            .TextFilePlatform = 2       'xlWindows
    '            .TextFileStartRow = 1
    '            .TextFileParseType = 1      'xlDelimited(区切り文字によってファイルが区切られます)
    '            .TextFileTextQualifier = 1  'xlTextQualifierDoubleQuote
    '            .TextFileConsecutiveDelimiter = False
    '            .TextFileTabDelimiter = True
    '            .TextFileSemicolonDelimiter = False
    '            .TextFileCommaDelimiter = True
    '            .TextFileSpaceDelimiter = False
    '            '.TextFileColumnDataTypes = Array(2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, _
    '            '    1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)
    '            .TextFileColumnDataTypes = vFormatAry
    '            .Refresh(BackgroundQuery:=False)
    '        End With

    '        'CSVダミーファイルを削除します
    '        If Right(vPstrFilename, 4) = ".xls" Then
    '            vPstrFilename = Mid(vPstrFilename, 1, Len(vPstrFilename) - 4)
    '        End If

    '        If System.IO.File.Exists(vPstrFilename) Then
    '            System.IO.File.Delete(vPstrFilename)
    '        End If

    '        Return True
    '    Catch ex As Exception
    '        XlClose()
    '        MessageBox.Show(ex.ToString, "[Excel:CSVﾃﾞｰﾀ取込処理(sImport)]", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Return False
    '    End Try

    'End Function

    ''***************************************************************************
    '' 概要    : データ書込み
    ''
    '' ﾊﾟﾗﾒｰﾀ  : 変数名  ,IO ,型 ,説明
    ''         :         ,I  ,   ,テーブル
    ''         :         ,I  ,   ,出力可否（1:出力）
    ''         :         ,I  ,   ,項目名称
    ''         :         ,I  ,   ,出力ファイル（形式 "D:\Project\JBD\aaa.xls" ）
    ''         : 戻り値  ,   ,   ,True:正常 False:異常
    ''***************************************************************************
    'Public Function FileIns(ByVal tbl As DataTable, ByVal ClmAry As Array, ByVal NameAry As Array, ByVal sFilNm As String) As Boolean

    '    Dim MyStr As String = String.Empty
    '    Dim iRow As Integer = 0
    '    Dim iCol As Integer = 0
    '    Dim iFr As Short



    '    Try
    '        Dim sXlsFileNm As String
    '        If Right(sFilNm, 4) <> ".xls" Then
    '            sXlsFileNm = sFilNm & ".xls"
    '        Else
    '            sXlsFileNm = sFilNm
    '        End If

    '        If System.IO.File.Exists(sXlsFileNm) Then
    '            If MessageBox.Show("この場所に '" & sXlsFileNm & "'という名前のファイルが既にあります。置き換えますか？", _
    '                                    "上書き確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.No Then
    '                XlClose()
    '                Return False
    '            Else
    '                System.IO.File.Delete(sXlsFileNm)
    '            End If
    '        End If

    '        iFr = FreeFile()
    '        FileOpen(iFr, sFilNm, OpenMode.Output)
    '        'ヘッダー部作成
    '        For iCol = 0 To tbl.Columns.Count - 1
    '            If ClmAry.GetLength(0) - 1 < iCol Then
    '                Exit For
    '            End If
    '            If ClmAry(iCol) = 1 Then
    '                If MyStr <> "" Then
    '                    MyStr &= vbTab
    '                End If
    '                If NameAry.GetLength(0) - 1 < iCol Then
    '                    MyStr &= ""
    '                Else
    '                    MyStr &= NameAry(iCol)
    '                End If
    '            End If
    '        Next
    '        MyStr &= vbCrLf
    '        Print(iFr, MyStr)
    '        '明細部作成
    '        For iRow = 0 To tbl.Rows.Count - 1
    '            MyStr = ""
    '            For iCol = 0 To tbl.Columns.Count - 1
    '                If ClmAry.GetLength(0) - 1 < iCol Then
    '                    Exit For
    '                End If
    '                If ClmAry(iCol) = 1 Then
    '                    If MyStr <> "" Then
    '                        MyStr &= vbTab
    '                    End If
    '                    If tbl.Rows(iRow)(iCol) Is DBNull.Value Then
    '                        MyStr &= ""
    '                    Else
    '                        MyStr &= tbl.Rows(iRow)(iCol)
    '                    End If
    '                End If
    '            Next
    '            MyStr &= vbCrLf
    '            Print(iFr, MyStr)
    '        Next
    '        FileClose(iFr)

    '        Return True
    '    Catch ex As Exception
    '        XlClose()
    '        MessageBox.Show(ex.Message)
    '        'Fnc_Msg(ex.ToString, 9, "[Excel:データ書込み(FileIns)]")
    '        Return False
    '    End Try

    'End Function

    ''***************************************************************************
    '' 概要    : Ｅｘｃｅｌシート書式設定
    ''
    '' ﾊﾟﾗﾒｰﾀ  : 変数名  ,IO ,型 ,説明
    ''         :         ,I  ,   ,設定先対象範囲(開始:行)
    ''         :         ,I  ,   ,０:標準 １:文字型 
    ''         :         ,I  ,   ,２:金額（カンマ編集・小数無し）３:金額（カンマ編集・小数２桁）
    ''         :         ,I  ,   ,４:金額（カンマ編集・小数６桁）５:金額（カンマ編集・小数10桁）
    ''         :         ,I  ,   ,６:％（少数無し） ７:％（少数２桁）
    ''         :         ,I  ,   ,８:％（小数４桁） ９:％（少数６桁）
    ''         : 戻り値  ,   ,   ,True:正常 False:異常
    ''
    '' 説明    : 任意の範囲
    ''
    ''***************************************************************************
    'Public Overloads Sub XlFormat(ByVal DtType() As Byte)
    '    Dim i As Integer
    '    Dim iCol As Integer = 0

    '    For i = 0 To DtType.GetLength(0) - 1
    '        Select Case DtType(i)
    '            Case 1      '文字型
    '                XlSheet.Columns(i + 1).NumberFormatLocal = "@"
    '            Case 2      '金額（カンマ編集、小数無し）
    '                XlSheet.Columns(i + 1).NumberFormatLocal = "#,##0_ "
    '            Case 3      '金額（カンマ編集、小数点2桁指定）
    '                XlSheet.Columns(i + 1).NumberFormatLocal = "#,##0.00_ "
    '            Case 4      '金額（カンマ編集、小数点6桁指定）
    '                XlSheet.Columns(i + 1).NumberFormatLocal = "#,##0.000000_ "
    '            Case 5      '金額（カンマ編集、小数点10桁指定）
    '                XlSheet.Columns(i + 1).NumberFormatLocal = "#,##0.0000000000_ "
    '            Case 6      '％（小数無し）
    '                XlSheet.Columns(i + 1).NumberFormatLocal = "0%"
    '            Case 7      '％（小数点2桁指定）
    '                XlSheet.Columns(i + 1).NumberFormatLocal = "0.00%"
    '            Case 8      '％（小数点4桁指定）
    '                XlSheet.Columns(i + 1).NumberFormatLocal = "0.0000%"
    '            Case 9      '％（小数点6桁指定）
    '                XlSheet.Columns(i + 1).NumberFormatLocal = "0.000000%"
    '        End Select
    '    Next

    'End Sub
    'Public Overloads Sub XlFormat(ByVal DtType() As Byte, ByVal ClmAry() As Byte)
    '    Dim i As Integer
    '    Dim iCol As Integer = 0

    '    For i = 0 To DtType.GetLength(0) - 1
    '        If ClmAry(i) = 1 Then
    '            iCol += 1
    '            Select Case DtType(i)
    '                Case 1      '文字型
    '                    XlSheet.Columns(iCol).NumberFormatLocal = "@"
    '                Case 2      '金額（カンマ編集、小数無し）
    '                    XlSheet.Columns(iCol).NumberFormatLocal = "#,##0_ "
    '                Case 3      '金額（カンマ編集、小数点2桁指定）
    '                    XlSheet.Columns(iCol).NumberFormatLocal = "#,##0.00_ "
    '                Case 4      '金額（カンマ編集、小数点6桁指定）
    '                    XlSheet.Columns(iCol).NumberFormatLocal = "#,##0.000000_ "
    '                Case 5      '金額（カンマ編集、小数点10桁指定）
    '                    XlSheet.Columns(iCol).NumberFormatLocal = "#,##0.0000000000_ "
    '                Case 6      '％（小数無し）
    '                    XlSheet.Columns(iCol).NumberFormatLocal = "0%"
    '                Case 7      '％（小数点2桁指定）
    '                    XlSheet.Columns(iCol).NumberFormatLocal = "0.00%"
    '                Case 8      '％（小数点4桁指定）
    '                    XlSheet.Columns(iCol).NumberFormatLocal = "0.0000%"
    '                Case 9      '％（小数点6桁指定）
    '                    XlSheet.Columns(iCol).NumberFormatLocal = "0.000000%"
    '            End Select
    '        End If
    '    Next

    'End Sub

    ''***************************************************************************
    '' 概要    : ＥｘｃｅｌシートAlignAry
    ''
    '' ﾊﾟﾗﾒｰﾀ  : 変数名  ,IO ,型 ,説明
    ''         :         ,I  ,   ,０:標準 １:左詰め 
    ''         :         ,I  ,   ,２:中央 ３:右詰め
    ''
    ''***************************************************************************
    'Public Overloads Sub XlAlignAry(ByVal DtType() As Byte)
    '    Dim i As Integer

    '    For i = 0 To DtType.GetLength(0) - 1
    '        Select Case DtType(i)
    '            Case 1      '左詰め
    '                XlSheet.Columns(i + 1).HorizontalAlignment = -4131 'xlLeft
    '                XlSheet.Columns(i + 1).VerticalAlignment = -4108  'xlCenter
    '            Case 2      '中央
    '                XlSheet.Columns(i + 1).HorizontalAlignment = -4108 'xlCenter
    '                XlSheet.Columns(i + 1).VerticalAlignment = -4108  'xlCenter
    '            Case 3      '右詰め
    '                XlSheet.Columns(i + 1).HorizontalAlignment = -4152 'xlRight
    '                XlSheet.Columns(i + 1).VerticalAlignment = -4108  'xlCenter
    '        End Select
    '    Next

    'End Sub

    'Public Overloads Sub XlAlignAry(ByVal DtType() As Byte, ByVal ClmAry() As Byte)
    '    Dim i As Integer
    '    Dim iCol As Integer = 0

    '    For i = 0 To DtType.GetLength(0) - 1
    '        If ClmAry(i) = 1 Then
    '            iCol += 1
    '            Select Case DtType(i)
    '                Case 1      '左詰め
    '                    XlSheet.Columns(iCol).HorizontalAlignment = -4131  'xlLeft
    '                    XlSheet.Columns(iCol).VerticalAlignment = -4108    'xlCenter
    '                Case 2      '中央
    '                    XlSheet.Columns(iCol).HorizontalAlignment = -4108  'xlCenter
    '                    XlSheet.Columns(iCol).VerticalAlignment = -4108    'xlCenter
    '                Case 3      '右詰め
    '                    XlSheet.Columns(iCol).HorizontalAlignment = -4152  'xlRight
    '                    XlSheet.Columns(iCol).VerticalAlignment = -4108    'xlCenter
    '            End Select
    '        End If
    '    Next

    'End Sub

    'Public Overloads Sub XlAlignAry(ByVal DtType As Byte, ByVal iRow As Integer, ByVal iCol As Integer)

    '    Select Case DtType
    '        Case 1      '左詰め
    '            XlSheet.Rows(iRow).Columns(iCol).HorizontalAlignment = -4131  'xlLeft
    '            XlSheet.Rows(iRow).Columns(iCol).VerticalAlignment = -4108    'xlCenter
    '        Case 2      '中央
    '            XlSheet.Rows(iRow).Columns(iCol).HorizontalAlignment = -4108  'xlCenter
    '            XlSheet.Rows(iRow).Columns(iCol).VerticalAlignment = -4108    'xlCenter
    '        Case 3      '右詰め
    '            XlSheet.Rows(iRow).Columns(iCol).HorizontalAlignment = -4152  'xlRight
    '            XlSheet.Rows(iRow).Columns(iCol).VerticalAlignment = -4108    'xlCenter
    '    End Select

    'End Sub

    'Public Overloads Sub XlAutoFit(ByVal stRow As Integer, ByVal stCol As Integer, ByVal edRow As Integer, ByVal edCol As Integer)

    '    With XlSheet
    '        .Range(.Cells(stRow, stCol), _
    '               .Cells(edRow, edCol)).EntireColumn.AutoFit()
    '        .Range(.Cells(stRow, stCol), _
    '               .Cells(stRow, stRow)).Select()
    '    End With

    'End Sub

    '' 概要    : クリップボード コピー＆ペースト
    'Public Overloads Function fgClipboard(ByVal tb As DataTable, ByVal NMarray As Array) As Boolean
    '    Dim i As Integer = 0
    '    Dim j As Integer = 0
    '    Dim Str As String = String.Empty
    '    Try
    '        'Excel出力用ヘッダータイトル設定
    '        For j = 0 To tb.Columns.Count - 1
    '            If NMarray(j) <> "" Then
    '                Str = Str & """" & NMarray(j) & """" & vbTab
    '            End If
    '        Next
    '        Str = Str & vbCrLf

    '        'Excel出力用明細設定
    '        For i = 0 To tb.Rows.Count - 1
    '            For j = 0 To tb.Columns.Count - 1
    '                If NMarray(j) <> "" Then
    '                    If tb.Rows(i)(j) Is DBNull.Value Then
    '                        Str = Str & """" & "" & """" & vbTab
    '                    Else
    '                        Str = Str & """" & tb.Rows(i)(j) & """" & vbTab
    '                    End If
    '                End If
    '            Next
    '            Str = Str & vbCrLf
    '        Next

    '        Clipboard.SetDataObject(Str, True)

    '    Catch ex As Exception
    '        Throw ex
    '        Return False
    '    End Try

    'End Function

#End Region

End Class
