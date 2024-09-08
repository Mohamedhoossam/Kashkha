using Microsoft.AspNetCore.Http;

namespace Kashkha.BL
{
    public static class DocumentSettings
    {
      
        public static string UploadFile(IFormFile file)
        {
            //1 get folder path

            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images");

            //2 unique file name

            string fileName = $"{Guid.NewGuid()}{file.FileName}";

            //3 file path
            string filePath = Path.Combine(folderPath, fileName);



            using (var fs = new FileStream(filePath, FileMode.Create)) 

            file.CopyTo(fs);
            return fileName;
        }
        public static void DeleteFile(string file)
        {
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", file);
		

            if (File.Exists(filePath))
            {
               File.Delete(filePath);
            }
             
        }
    
    }
}
