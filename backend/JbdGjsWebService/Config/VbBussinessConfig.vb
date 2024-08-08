' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 
'
' 作成日　　: 2024.07.17
' 作成者　　: AIPlus
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.WebService

    Public Module VbBussinessConfig
        Private ReadOnly VBBUSSINESS_SERVICE_TYPES As IEnumerable(Of Type) = AppDomain.CurrentDomain.GetAssemblies().SelectMany(Function(assembly) assembly.GetTypes()).Where(Function(type) GetType(JbdGjsService.JBD.GJS.Service.CmServiceBase).IsAssignableFrom(type) AndAlso Not type.IsAbstract AndAlso Not String.IsNullOrEmpty(type.FullName))

        <Extension()>
        Public Sub ConfigureVbBussinessServiceGen(services As Microsoft.Extensions.DependencyInjection.IServiceCollection)
            services.AddSingleton(New JBD.GJS.WebService.ServiceFactory())
            For Each type In VBBUSSINESS_SERVICE_TYPES
                ' 単一インスタンスとして登録
                services.AddSingleton(type)
            Next
        End Sub

        Public Sub Configure(serviceProvider As IServiceProvider)
            Dim serviceFactory = serviceProvider.GetRequiredService(Of JBD.GJS.WebService.ServiceFactory)()
            For Each serviceType In VBBUSSINESS_SERVICE_TYPES
                Dim serviceInstance = serviceProvider.GetService(serviceType)
                If serviceInstance IsNot Nothing AndAlso Not String.IsNullOrEmpty(serviceType.FullName) Then
                    serviceFactory.AddService(serviceType.FullName, serviceInstance)
                End If
            Next
        End Sub
    End Module
End Namespace
