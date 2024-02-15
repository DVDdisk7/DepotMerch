
namespace DepotMerch.Services
{
    public class Image
    {
        public static bool CheckImage(string imageUrl)
        {
            if (imageUrl.Contains(".jpg") || imageUrl.Contains(".png") || imageUrl.Contains(".jpeg"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
