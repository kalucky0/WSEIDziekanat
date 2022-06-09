namespace WSEIDziekanat.Contracts.Services;

public interface IDataService<out T>
{
    T GetData();
}