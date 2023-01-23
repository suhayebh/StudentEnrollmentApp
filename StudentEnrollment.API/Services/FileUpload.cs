namespace StudentEnrollment.API.Services
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _contextAccessor;
        public FileUpload(IWebHostEnvironment environment, IHttpContextAccessor contextAccessor)
        {
            _environment = environment;
            _contextAccessor = contextAccessor;
        }

        public string UploadFile(byte[] file, string imageName)
        {
            if(file == null)
            {
                return string.Empty; // place holder image is good here
            }

            var folderPath = "somepictures";
            var url = _contextAccessor.HttpContext?.Request.Host.Value;
            var ext = Path.GetExtension(imageName);
            var fileName = $"{Guid.NewGuid()}{ext}";

            var path = $"{_environment.WebRootPath}\\{folderPath}\\{fileName}";
            UploadImage(file, path);
            return $"https://{url}/{folderPath}/{fileName}";

        }

        private void UploadImage(byte[] bytes, string path)
        {
            FileInfo file = new(path);
            file?.Directory.Create(); // if directory exist, this do nothing

            var fileStream = file?.Create();
            fileStream?.Write(bytes, 0, bytes.Length);
            fileStream?.Close();  
        }
    }
}
