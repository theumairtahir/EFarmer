﻿using System.Threading.Tasks;
using ImageWriter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageUploader
{
    public interface IImageHandler
    {
        Task<IActionResult> UploadImage(IFormFile file);
        Task<string> UploadImage(IFormFile file, string s);
    }

    public class ImageHandler : IImageHandler
    {
        private readonly IImageWriter _imageWriter;
        public ImageHandler(IImageWriter imageWriter)
        {
            _imageWriter = imageWriter;
        }

        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            var result = await _imageWriter.UploadImage(file);
            return new ObjectResult(result);
        }
        public async Task<string> UploadImage(IFormFile file, string s)
        {
            var result = await _imageWriter.UploadImage(file);
            return result;
        }
    }
}




