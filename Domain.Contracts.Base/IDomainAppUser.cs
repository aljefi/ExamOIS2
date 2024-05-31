using Microsoft.AspNetCore.Identity;

namespace Domain.Contracts.Base;

public interface IDomainAppUser<TUser> : IDomainAppUser<Guid, TUser>
    where TUser : IdentityUser<Guid>
{
}

public interface IDomainAppUser<TKey, TUser> : IDomainAppUserId<TKey>
    where TKey : IEquatable<TKey>
    where TUser : IdentityUser<TKey>
{
    public TUser? AppUser { get; set; }
}