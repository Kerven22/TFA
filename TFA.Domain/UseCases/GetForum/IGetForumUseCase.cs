﻿using TFA.Domain.Models;

namespace TFA.Domain.UseCases.GetForum
{
    public interface IGetForumUseCase
    {
        public Task<IEnumerable<ForumDto>> Execute(CancellationToken cancellationToken);
    }
}
