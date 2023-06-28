namespace StreamProgress.Models.Interfaces
{
    public interface IFile
    {
        int Length { get; }
        int BytesSent { get; }
    }
}
