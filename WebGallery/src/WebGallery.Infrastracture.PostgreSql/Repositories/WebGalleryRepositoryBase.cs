namespace WebGallery.Infrastracture.PostgreSql.Repositories
{
    internal abstract class WebGalleryRepositoryBase
    {
        protected readonly WebGalleryContext webGalleryContext;

        public WebGalleryRepositoryBase(WebGalleryContext context)
        {
            webGalleryContext = context;
        }
    }
}
