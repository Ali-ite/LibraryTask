using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibraryTask.Enums.Enum;

namespace LibraryTask.Domain.Attachments
{
    public class AttachmentManager : DomainService, IAttachmentManager
    {
        private readonly IRepository<Attachment, long> _repository;
        private readonly string _appBaseUrl;

        public AttachmentManager(IRepository<Attachment, long> repository, IConfiguration configuration)

        {
            _repository = repository;
            _appBaseUrl = configuration[LibraryTaskConsts.AppServerRootAddressKey] ?? "/";
            LocalizationSourceName = LibraryTaskConsts.LocalizationSourceName;
        }

        public async Task<Attachment> GetByIdAsync(long id)
        {
            var attachment = await _repository.FirstOrDefaultAsync(id);

            if (attachment == null)
                throw new UserFriendlyException(L("AttachmentIsNotFound"), $"Id: {id}");

            return attachment;
        }

        public async Task<Attachment> GetAndCheckAsync(long id, AttachmentRefType refType)
        {
            var attachment = await GetByIdAsync(id);

            if (attachment.RefType != refType)
                throw new UserFriendlyException(L("InvalidAttachmentRefType"),
                    $"Id: {id}, RefType: {attachment.RefType} and should be {(byte)refType}");

            return attachment;
        }

        public string GetUrl(Attachment attachment)
        {
            var baseUri = new Uri(_appBaseUrl);
            return (new Uri(baseUri, attachment.RelativePath)).AbsoluteUri;
        }
        public async Task UpdateRefIdAsync(Attachment attachment, long refId)
        {
            if (attachment.RefId != null)
                throw new UserFriendlyException(L("AttachmentAlreadyRelatedToEntity"),
                    $"Id: {attachment.Id}, RefType: {attachment.RefType}");

            attachment.RefId = refId;
            await _repository.UpdateAsync(attachment);
        }

        public async Task<Attachment> CheckAndUpdateRefIdAsync(long id, AttachmentRefType refType, long refId)
        {
            //Check if type is correct and update refId
            var attachment = await GetAndCheckAsync(id, refType);
            await UpdateRefIdAsync(attachment, refId);

            return attachment;
        }

        public async Task DeleteRefIdAsync(Attachment attachment)
        {
            attachment.RefId = null;
            await _repository.UpdateAsync(attachment);
        }

        public async Task DeleteAllRefIdAsync(long refId, AttachmentRefType refType)
        {
            foreach (var attachment in await GetByRefAsync(refId, refType))
            {
                attachment.RefId = null;
                await _repository.UpdateAsync(attachment);
            }
        }

        public void CheckAttachmentRefType(AttachmentRefType refType, AttachmentType fileType)
        {
            if (!AcceptedTypesFor(refType).Contains(fileType))
                throw new UserFriendlyException(L("FileTypeIncompatibleWithRefType"),
                    $"Type:{fileType.ToString()}, RefType:{refType.ToString()}");
        }

        public async Task<List<Attachment>> GetByRefAsync(long refId, AttachmentRefType refType)
        {
            var refTypeString = ((byte)refType).ToString();
            return await _repository.GetAllListAsync(x => x.RefId == refId && x.RefType == refType);
        }


        private static IEnumerable<AttachmentType> AcceptedTypesFor(AttachmentRefType refType)
        {
            switch (refType)
            {
                case AttachmentRefType.Book:
                    return AllAcceptedTypes;
              

            }

            return new AttachmentType[] { };
        }



        public Task<bool> CreateAttachments(List<Attachment> attachments)
        {
            try
            {
                foreach (var attachment in attachments)
                {
                    _repository.InsertAsync(attachment);
                }
                return Task.FromResult(true);
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(L("ErrorOnInsertingAttachments"));
            }
        }

        public async Task<Attachment> CreateAttachment(Attachment attachment)
        {
            try
            {
                var attachmentResult = await _repository.InsertAsync(attachment);
                await CurrentUnitOfWork.SaveChangesAsync();
                return attachmentResult;
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(L("ErrorOnInsertingAttachment"));
            }
        }

        public async Task<Attachment> GetElementByRefAsync(long refId, AttachmentRefType refType)
        {
            var refTypeString = ((byte)refType).ToString();
            return await _repository.FirstOrDefaultAsync(x => x.RefId == refId && x.RefType == refType);

        }

        private static readonly AttachmentType[] AllAcceptedTypes =
            { AttachmentType.JPEG, AttachmentType.JPG, AttachmentType.PDF, AttachmentType.PNG, AttachmentType.WORD };

        private static readonly AttachmentType[] ImagesAcceptedTypes =
            { AttachmentType.JPEG, AttachmentType.JPG, AttachmentType.PNG };

    
    }
}
