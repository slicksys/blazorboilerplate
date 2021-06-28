namespace SSDCPortal.Shared.Interfaces
{
    public interface IDynamicComponent
    {
        string IntoComponent { get; }
        int Order { get; }
    }
}
