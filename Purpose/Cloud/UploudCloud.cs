using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Purpose.Cloud
{
    public class UploudCloud
    {
        Cloudinary cloudinary;
        public UploudCloud()
        {
            Account account = new Account(
            "boola98",
            "914541695534158",
            "zwamf_cagDU1I0kEGiWtpky4Th8"
            );

            cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;
        }

        public string Upload(string str)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(str)
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            return uploadResult.SecureUrl.ToString();
        }
    }
}
