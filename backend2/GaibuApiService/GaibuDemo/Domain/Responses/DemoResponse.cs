using System.Text.Json.Serialization;
using GaibuApiService.GaibuDemo.Domain.Others;

namespace GaibuApiService.GaibuDemo.Domain.Responses;

public class DemoResponse
{
    public string token { get; set; } //トークン(ベースロジック)
    public UserInfo userinfo { get; set; } //ユーザー情報(共通)
    [JsonPropertyName("sisyolist")] 
    public List<Sisyo> sisyos { get; set; } //支所リスト(登録支所選択用)
    public bool pwdmsgflg { get; set; } //警告フラグ true:警告メッセージが出る(通知範囲以内の場合)
    public int returncode { get; set; } //レスポンス状態区別
    public string message { get; set; } //メッセージ
    public string? rsaprivatekey { get; set; } //秘密キー(復号化用)
}