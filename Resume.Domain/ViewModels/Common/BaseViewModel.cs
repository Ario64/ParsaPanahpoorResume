namespace Resume.Domain.ViewModels.Common;

public abstract class BaseViewModel<T>
{
    public T Id { get; set; }
}