using Abp.Application.Services.Dto;

namespace LibraryTask
{
    /// <summary>
    /// 
    /// </summary>
    public class LiteAttachmentDto : EntityDto<long>
    {
        public string Url { get; set; }
    }
}
