﻿using Abp.Dependency;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using LibraryTask.Domain.Attachments;
using static LibraryTask.Enums.Enum;

namespace LibraryTask.FileUploadService
{
    public interface IFileUploadService : ITransientDependency
    {
        /// <summary>
        /// Save file to Attachments folder (wwwroot\Attachments\).
        /// </summary>
        /// <param name="file">uploaded file</param>
        /// <returns>AttachmentType and Path of saved file relative to wwwroot folder</returns>
        Task<UploadedFileInfo> SaveAttachmentAsync(IFormFile file);

        /// <summary>
        /// Save file to Images folder (wwwroot\Images\).
        /// </summary>
        /// <param name="file">uploaded file</param>
        /// <returns>Image Type and Path of saved file relative to wwwroot folder</returns>
        Task<UploadedImageInfo> SaveImageAsync(IFormFile file);

        /// <summary>
        /// Delete Attachment
        /// </summary>
        /// <param name="fileRelativePath"></param>
        void DeleteAttachment(string fileRelativePath);

        /// <summary>
        /// Check File Size Async
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task CheckFileSizeAsync(IFormFile file);
        /// <summary>
        ///  Get And Check File Type
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        AttachmentType GetAndCheckFileType(IFormFile file);
        /// <summary>
        /// Generate Path To Save
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        UploadedImageInfo GeneratePathToSave(string fileName);
    }

    /// <summary>
    /// Uploaded File Info
    /// </summary>
    public class UploadedFileInfo
    {
        /// <summary>
        /// AttachmentType
        /// </summary>
        public AttachmentType Type { get; set; }
        /// <summary>
        /// RelativePath
        /// </summary>
        public string RelativePath { get; set; }
    }
    /// <summary>
    /// Uploaded Image Info
    /// </summary>
    public class UploadedImageInfo
    {
        /// <summary>
        /// ImageType
        /// </summary>
        public ImageType Type { get; set; }
        /// <summary>
        /// RelativePath
        /// </summary>
        public string RelativePath { get; set; }
        /// <summary>
        /// PathToSave
        /// </summary>
        public string PathToSave { get; set; }
    }
}
