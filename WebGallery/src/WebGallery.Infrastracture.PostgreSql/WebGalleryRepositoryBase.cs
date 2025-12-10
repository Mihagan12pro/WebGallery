using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGallery.Infrastracture.PostgreSql
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
