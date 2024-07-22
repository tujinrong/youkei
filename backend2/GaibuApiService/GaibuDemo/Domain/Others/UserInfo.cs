namespace GaibuApiService.GaibuDemo.Domain.Others;

public class UserInfo
{
    public string userid { get; set; } //ユーザID
    public string usernm { get; set; } //ユーザー名
    public string syozokunm { get; set; } //所属名
    public bool kanrisyaflg { get; set; } //管理者フラグ
}