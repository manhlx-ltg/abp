﻿using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using Volo.CmsKit.Domain.Volo.CmsKit.Blogs;

namespace Volo.CmsKit.MongoDB.Blogs
{
    public class BlogPostMongoRepository : MongoDbRepository<CmsKitMongoDbContext, BlogPost, Guid>, IBlogPostRepository
    {
        public BlogPostMongoRepository(IMongoDbContextProvider<CmsKitMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public Task<BlogPost> GetByUrlSlugAsync(string urlSlug)
        {
            return GetAsync(x => x.UrlSlug.ToLower() == urlSlug);
        }

        public async Task<bool> SlugExistsAsync(string slug)
        {
            var queryable = await GetQueryableAsync();

            return await AsyncExecuter.AnyAsync(queryable, x => x.UrlSlug.ToLower() == slug);
        }
    }
}
