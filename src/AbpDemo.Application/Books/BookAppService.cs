using System;
using AbpDemo.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace AbpDemo.Books;

public class BookAppService :
    CrudAppService<Book,
        BookDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateBookDto>,
    IBookAppService
{
    public BookAppService(IRepository<Book, Guid> repository) : base(repository)
    {
        GetPolicyName = AbpDemoPermissions.Books.Default;
        GetListPolicyName = AbpDemoPermissions.Books.Default;
        CreatePolicyName = AbpDemoPermissions.Books.Create;
        UpdatePolicyName = AbpDemoPermissions.Books.Edit;
        DeletePolicyName = AbpDemoPermissions.Books.Delete;
    }
}