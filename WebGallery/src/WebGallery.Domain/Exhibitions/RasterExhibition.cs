namespace WebGallery.Domain.Exhibitions;

public class RasterExhibition : Exhibition
{
    public RasterExhibition(Raster image)
    {
        MimeType = "image/"+image.ToString();
    }
}

public enum Raster
{
    Png,
    
    Gif,  
    
    Jpeg
}