﻿using AutoMapper;
using Enmeshed.BuildingBlocks.Application.Abstractions.Infrastructure.Persistence.BlobStorage;
using Enmeshed.BuildingBlocks.Application.Abstractions.Infrastructure.Persistence.Database;
using Enmeshed.BuildingBlocks.Application.Abstractions.Infrastructure.UserContext;
using Files.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Files.Application.Files.Commands.CreateFile
{
    public class Handler : IRequestHandler<CreateFileCommand, CreateFileResponse>
    {
        private readonly IBlobStorage _blobStorage;
        private readonly IDbContext _dbContext;
        private readonly ILogger<Handler> _logger;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        private CreateFileCommand _request;

        public Handler(IDbContext dbContext, IUserContext userContext, IMapper mapper, IBlobStorage blobStorage, ILogger<Handler> logger)
        {
            _dbContext = dbContext;
            _userContext = userContext;
            _mapper = mapper;
            _blobStorage = blobStorage;
            _logger = logger;
        }

        public async Task<CreateFileResponse> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            _request = request;

            var fileMetadata = await SaveFile(cancellationToken);

            var response = _mapper.Map<CreateFileResponse>(fileMetadata);

            return response;
        }

        private async Task<FileMetadata> SaveFile(CancellationToken cancellationToken)
        {
            var metadata = new FileMetadata(_userContext.GetAddress(), _userContext.GetDeviceId(), _request.Owner, _request.OwnerSignature, _request.CipherHash, _request.FileContent.LongLength, _request.ExpiresAt, _request.EncryptedProperties);

            await _dbContext.Set<FileMetadata>().AddAsync(metadata, cancellationToken);
            _blobStorage.Add(metadata.Id, _request.FileContent);

            await _blobStorage.SaveAsync();
            _logger.LogTrace("Successfully saved metadata.");

            await _dbContext.SaveChangesAsync(cancellationToken);
            _logger.LogTrace("Successfully saved content.");

            return metadata;
        }
    }
}
