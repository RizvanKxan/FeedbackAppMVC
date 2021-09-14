using FeedbackApp.BLL.VMs.Feedback;
using FeedbackApp.BLL.VMs.MediaFile;
using FeedbackApp.BLL.VMs.Product;
using FeedbackApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedbackApp.BLL.Interfaces
{
    public interface IMediaFileService
    {
        Task<Guid> CreateMediaFileAsync(CreateMediaFile mediaFile);  //вернем ID 
        List<CreateMediaFile> FindMediaFilesByFunc(Func<MediaFile, bool> func);
    }
}
