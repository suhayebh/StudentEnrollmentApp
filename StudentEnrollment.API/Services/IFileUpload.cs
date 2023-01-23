namespace StudentEnrollment.API.Services
{
    public interface IFileUpload
    {
        string UploadFile(byte[] file, string imageName);
    }
}
