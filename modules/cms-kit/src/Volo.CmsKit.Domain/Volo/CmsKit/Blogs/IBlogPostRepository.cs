﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Volo.CmsKit.Domain.Volo.CmsKit.Blogs
{
    public interface IBlogPostRepository : IBasicRepository<BlogPost, Guid>
    {
        Task<bool> SlugExistsAsync(string slug);

        Task<BlogPost> GetByUrlSlugAsync(string urlSlug);
    }
}
