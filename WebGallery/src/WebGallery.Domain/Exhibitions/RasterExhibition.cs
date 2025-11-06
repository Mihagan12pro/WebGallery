using WebGallery.Domain.Exhibitions.Enums;

namespace WebGallery.Domain.Exhibitions;

public class RasterExhibition : Exhibition
{
    public RasterExhibition(RasterExtension image)
    {
        MimeType = "image/"+image.ToString();
    }
}