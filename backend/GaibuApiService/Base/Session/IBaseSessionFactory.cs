namespace GaibuApiService.Base.Session;

public interface IBaseSessionFactory<T> where T : IBaseSession
{
    T OpenSession();
}